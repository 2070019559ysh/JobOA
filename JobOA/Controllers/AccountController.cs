using JobOA.Auxiliary;
using JobOA.BLL;
using JobOA.Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using JobOA.Common;
using JobOA.Common.Model;
using System.Web.Security;
using System.Security.Principal;

namespace JobOA.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        /// <summary>
        /// Ninject注入的部门信息业务管理接口
        /// </summary>
        [Inject]
        public IDepartmentManager DepartmentManager { get; set; }

        /// <summary>
        /// Ninject注入的角色信息业务管理接口
        /// </summary>
        [Inject]
        public IRoleManager RoleManager { get; set; }

        [Inject]
        public IEmployeeManager EmployeeManager { get; set; }

        [Inject]
        public IOAUiManager oaUiManager { get; set; }
        //
        // GET: /Account/

        /// <summary>
        /// 进入登录界面
        /// </summary>
        /// <returns>登录界面</returns>
        [HttpGet]
        public ViewResult Index()
        {
            return View("Login");
        }

        /// <summary>
        /// 进入员工注册页面
        /// </summary>
        /// <returns>员工注册页面</returns>
        [HttpGet]
        public ViewResult Register()
        {
            //获取所有部门信息，界面要显示
            ViewData["department"]=DepartmentManager.SearchAllDepartment();
            //获取所有角色信息，界面要显示
            ViewData["role"] = RoleManager.SearchAllRole();
            return View();
        }

        /// <summary>
        /// 员工注册操作
        /// </summary>
        /// <param name="employee">员工提交的信息</param>
        /// <returns>注册界面</returns>
        [HttpPost]
        public ViewResult Register(Employee employee, HttpPostedFileBase headPictureFile, string phoneCheck,string emailCheck)
        {
            if (headPictureFile!=null&&!headPictureFile.ContentType.Contains("image"))
            {
                ModelState.AddModelError("headPictureFile", "头像格式暂不支持");
            }
            string phoneCode = TempData["phoneCode"] as string;
            string emailCode = TempData["emailCode"] as string;
            ViewData["phoneCode"] = phoneCode;
            ViewData["emailCode"] = emailCode;
            if (String.IsNullOrWhiteSpace(phoneCheck)||!phoneCheck.ToUpper().Equals(phoneCode))
            {
                TempData["phoneCode"] = phoneCode;
                ModelState.AddModelError("phoneCheck", "手机号有效性确认不通过");
            }
            if (employee.Email != null)
            {
                //用户输入了邮箱，要验证邮箱
                if (String.IsNullOrWhiteSpace(emailCheck))
                {
                    if (emailCode != null) TempData["emailCode"] = emailCode;
                    ModelState.AddModelError("emailCheck", "邮箱有效性确认不通过");
                }
                else if (!emailCheck.ToUpper().Equals(emailCode))
                {
                    TempData["emailCode"] = emailCode;
                    ModelState.AddModelError("emailCheck", "邮箱有效性确认不通过");
                }
            }
            if (ModelState.IsValid)
            {
                string userImg = Server.MapPath("~/Content/images/userImg/");//用户上传图片路径
                if (headPictureFile == null)
                {
                    employee.HeadPicture = null;
                }
                else if (System.IO.File.Exists(userImg+ employee.HeadPicture))
                {
                    string extension = Path.GetExtension(headPictureFile.FileName);//上传文件的拓展名
                    //如果存在同名文件则使用Guid生成的名字
                    employee.HeadPicture = Guid.NewGuid().ToString() + extension;
                }
                bool registerSuccess = EmployeeManager.AddEmployee(employee);
                if (registerSuccess)
                {
                    if(employee.HeadPicture!=null)
                        headPictureFile.SaveAs(userImg + employee.HeadPicture);//保存上传的图片
                    ViewData["mess"] = "注册成功！";
                }
                else
                {
                    ViewData["mess"] = "注册失败！";
                }
            }
            //获取所有部门信息，界面要显示
            ViewData["department"] = DepartmentManager.SearchAllDepartment();
            //获取所有角色信息，界面要显示
            ViewData["role"] = RoleManager.SearchAllRole();
            return View();
        }

        /// <summary>
        /// 进入登录界面
        /// </summary>
        /// <returns>登录界面</returns>
        [HttpGet]
        [AllowAnonymous]
        public ViewResult Login()
        {
            return View();
        }

        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="userName">用户名/手机号</param>
        /// <param name="password">密码</param>
        /// <returns>登录是否成功的json</returns>
        [AllowAnonymous]
        [HttpPost]
        public JsonResult Login(string userName, string password, string remember)
        {
            Employee employee=EmployeeManager.CheckEmployeeLogin(userName, password);
            if (employee!=null)
            {
                employee.OnlineState = (int)OnlineState.onLine;
                employee.LastLoginTime = DateTime.Now;//记录最近登录时间
                EmployeeManager.UpdateEmployee(employee);
                //创建身份验证票证
                bool isRemember = !String.IsNullOrEmpty(remember);
                FormsAuthentication.SetAuthCookie(employee.UserName, isRemember);
                FormsAuthenticationTicket authenticationTicket = new FormsAuthenticationTicket(
                    1, //身份验证票据版本号
                    employee.UserName,//关联的用户名
                    DateTime.Now,//发表时间
                    DateTime.Now.AddMonths(1),//过期时间
                    true,//存储在持久性cookie中
                    employee.RoleIds//用户的角色 每个以“,”分割
                    );
                string ticketContent=FormsAuthentication.Encrypt(authenticationTicket);//为了安全，进行加密

                Session["user"] = employee;//记录用户信息 并修改对应客户端cookie的有效时间
                HttpCookie sessionCookie = new HttpCookie("ASP.NET_SessionId");
                sessionCookie.HttpOnly = false;
                sessionCookie.Value=Request.Cookies["ASP.NET_SessionId"].Value;
                sessionCookie.Expires = DateTime.Now.AddMonths(1);
                Response.Cookies.Add(sessionCookie);

                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketContent);
                if(isRemember)cookie.Expires = DateTime.Now.AddMonths(1);
                cookie.HttpOnly = false;//客户端js不需要读取到这个Cookie，只允许服务器端读取
                Response.Cookies.Add(cookie);//响应给客户端

                string[] roleIds=new string[0];
                if (employee.RoleIds != null)
                {
                    roleIds = employee.RoleIds.Split(',');//角色Id分割
                }
                HttpContext.User = new GenericPrincipal(User.Identity, roleIds);//给用户身份记录值
                return Json(new { result = true,headPicture=employee.HeadPicture,name=employee.RealName });
            }
            else
            {
                return Json(new { result = false });
            }
        }

        /// <summary>
        /// 请求发送验证码到手机或邮箱
        /// </summary>
        /// <returns>是否发送成功</returns>
        [AllowAnonymous]
        [HttpPost]
        public JsonResult GetVerificationCode(string num,string type)
        {
            if (num == null || type == null) return Json(new { result = false }, JsonRequestBehavior.DenyGet);
            VerificationCode verificateCode = new VerificationCode();
            string code = verificateCode.CreateRandomCode(6);
            bool isSuccess = true;//标志是否成功发送验证码
            if (type.Equals("phone"))
            {
                TempData["phoneCode"] = code;
                isSuccess = oaUiManager.SendSms(num, "您正在注册员工账号，如非被人操作，请忽略本短信。您的验证码是：" + code);
            }
            else
            {
                TempData["emailCode"] = code;
                isSuccess = oaUiManager.SendEmail(num, "JoaOA系统的员工注册", "您正在注册员工账号，如非被人操作，请忽略本邮件。您的验证码是：" + code);
            }
            return Json(new { result = isSuccess },JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 响应客户端获取验证码图片
        /// </summary>
        /// <returns>验证码图片</returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetVerificationImg()
        {
            VerificationCode verificateCode = new VerificationCode();
            string code = verificateCode.CreateRandomCode(6);
            TempData["code"] = code;
            byte[] imgByte=verificateCode.CreateValidateGraphic(code);
            return File(imgByte, "image/jpg");
        }

        /// <summary>
        /// 正式发送验证码前验证验证码图片输入
        /// </summary>
        /// <param name="vaildCode">针对验证码图片输入的验证码</param>
        /// <returns>验证结果json</returns>
        [HttpPost]
        public ActionResult CheckVerificationCode(string vaildCode)
        {
            string code = TempData["code"] as string;
            if (vaildCode == null) return Json(new { result = false }, JsonRequestBehavior.DenyGet);
            if (vaildCode.ToUpper().Equals(code))
            {
                return Json(new { result = true },JsonRequestBehavior.DenyGet);
            }
            else
            {
                TempData["code"] = code;//验证错误，继续保存验证
                return Json(new { result = false }, JsonRequestBehavior.DenyGet);
            }
        }

        /// <summary>
        /// 验证用户输入的手机号用户名是否还是唯一，即没人注册过
        /// </summary>
        /// <param name="userName">手机号用户名</param>
        /// <returns>json结果</returns>
        [HttpPost]
        public ActionResult CheckUserNameUnique(string userName)
        {
            Employee employee=EmployeeManager.SearchEmployeeByUserName(userName);
            bool unique = (employee == null);
            return Json(new { isUnique = unique }, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 显示员工登录信息
        /// </summary>
        /// <returns>员工登录信息</returns>
        [AllowAnonymous]
        [HttpPost]
        public JsonResult EmployeeMess()
        {
            Employee employee=EmployeeManager.SearchEmployeeByUserName(User.Identity.Name);
            return Json(employee, JsonRequestBehavior.DenyGet);
        }
    }
}
