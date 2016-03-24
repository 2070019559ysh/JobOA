using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobOA.BLL;
using JobOA.Model;
using Ninject;
using System.IO;
using JobOA.Common;
using JobOA.Models;
using JobOA.Auxiliary;

namespace JobOA.Controllers
{
    public class PersonalInfoController : Controller
    {
        [Inject]
        public IEmployeeManager EmployeeManager { get; set; }

        [Inject]
        public IDepartmentManager DepartmentManager { get; set; }

        [Inject]
        public IOAUiManager oaUiManager { get; set; }

        [Inject]
        public IOAMessageManager oaMessManager { get; set; }

        /// <summary>
        /// 实例化一个ajax请求权限确认对象
        /// </summary>
        AjaxPermission ajaxPerm = new AjaxPermission();

        //
        // GET: /PersonalInfo/
        [ActionName("Information")]
        public ActionResult Index()
        {
            string userName=User.Identity.Name;
            Employee employee=EmployeeManager.SearchEmployeeByUserName(userName);
            List<Department> departmentList=DepartmentManager.SearchAllDepartment();
            ViewData["list"] = new SelectList(departmentList, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        /// <summary>
        /// 员工上传自己的头像图片
        /// </summary>
        /// <param name="file">图片</param>
        /// <returns>是否上传成功</returns>
        [AllowAnonymous]
        public JsonResult UploadImg(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string userImg = Server.MapPath("~/Content/images/userImg/");//用户上传图片路径
                string fileName;
                if (System.IO.File.Exists(userImg + file.FileName))
                {
                    string extension = Path.GetExtension(file.FileName);//上传文件的拓展名
                    //如果存在同名文件则使用Guid生成的名字
                    fileName = Guid.NewGuid().ToString() + extension;
                }
                else
                {
                    fileName = file.FileName;
                }
                Session["user"]=EmployeeManager.AddHeadPicture(User.Identity.Name, fileName);//更新员工头像信息
                file.SaveAs(userImg + fileName);//保存上传的图片
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        /// <summary>
        /// 删除员工的一个头像图片
        /// </summary>
        /// <param name="src">要删除的头像名</param>
        /// <returns>是否删除成功</returns>
        [AllowAnonymous]
        public ActionResult DelHeadPicture(string src)
        {
            Employee emp = EmployeeManager.RemoveHeadPicture(User.Identity.Name, Server.MapPath("~/"), src);
            if (emp != null)
            {
                Session["user"] = emp;
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        /// <summary>
        /// 获取当前员工头像信息
        /// </summary>
        /// <returns>头像信息</returns>
        [AllowAnonymous]
        public JsonResult GetHeadPicture()
        {
            Employee emp = Session["user"] as Employee;
            string[] headPicture=emp.HeadPicture.Split(',');
            return Json(headPicture,JsonRequestBehavior.DenyGet);
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
            byte[] imgByte = verificateCode.CreateValidateGraphic(code);
            return File(imgByte, "image/jpg");
        }

        /// <summary>
        /// 正式发送验证码前验证验证码图片输入
        /// </summary>
        /// <param name="vaildCode">针对验证码图片输入的验证码</param>
        /// <returns>验证结果json</returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult CheckVerificationCode(string vaildCode)
        {
            string code = TempData["code"] as string;
            if (vaildCode == null) return Json(new { result = false }, JsonRequestBehavior.DenyGet);
            if (vaildCode.ToUpper().Equals(code))
            {
                return Json(new { result = true }, JsonRequestBehavior.DenyGet);
            }
            else
            {
                TempData["code"] = code;//验证错误，继续保存验证
                return Json(new { result = false }, JsonRequestBehavior.DenyGet);
            }
        }

        /// <summary>
        /// 请求发送验证码到手机或邮箱
        /// </summary>
        /// <returns>是否发送成功</returns>
        [AllowAnonymous]
        [HttpPost]
        public JsonResult GetVerificationCode(string num, string type)
        {
            if (num == null || type == null) return Json(new { result = false }, JsonRequestBehavior.DenyGet);
            VerificationCode verificateCode = new VerificationCode();
            string code = verificateCode.CreateRandomCode(6);
            bool isSuccess = true;//标志是否成功发送验证码
            if (type.Equals("phone"))
            {
                TempData["phoneCode"] = code;
                isSuccess = oaUiManager.SendSms(num, "您正在修改员工账号，如非本人操作，请忽略本短信。您的验证码是：" + code);
            }
            else
            {
                TempData["emailCode"] = code;
                isSuccess = oaUiManager.SendEmail(num, "JoaOA系统的员工注册", "您正在修改员工账号，如非本人操作，请忽略本邮件。您的验证码是：" + code);
            }
            return Json(new { result = isSuccess }, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 修改员工信息，由于密码等信息是不修改的，模型绑定使用自定义模型绑定
        /// </summary>
        /// <param name="employee">新的员工信息</param>
        /// <returns>修改员工信息页面</returns>
        [HttpPost]
        public ActionResult UpdateEmployeeInfo([ModelBinder(typeof(EmployeeBinder))]Employee employee,string phoneCheck,string emailCheck)
        {
            Employee emp=Session["user"] as Employee;
            if (!emp.UserName.Equals(employee.UserName))
            {
                string phoneCode = TempData["phoneCode"] as string;
                if (!phoneCode.Equals(phoneCheck))
                {
                    ModelState.AddModelError("phoneCheck", "手机号验证错误");
                    TempData["phoneCode"] = phoneCheck;
                    ViewBag.validate = true;//告知界面是验证码有效时间
                }            
            }
            if (!(String.IsNullOrEmpty(employee.Email)||emp.Email.Equals(employee.Email)))
            {
                string emailCode = TempData["emailCode"] as string;
                if (!emailCode.Equals(emailCheck))
                {
                    ModelState.AddModelError("emailCheck", "邮箱验证错误");
                    TempData["phoneCode"] = emailCode;
                    ViewBag.validate = true;
                }
            }
            if (ModelState.IsValid)
            {
                if (EmployeeManager.UpdateEmployee(employee))
                {
                    Session["user"] = employee;//修改session信息
                    ViewBag.mess = "修改信息成功。";
                }
                else
                {
                    ViewBag.mess = "修改信息失败！请稍后再试。";
                }
            }
            List<Department> departmentList = DepartmentManager.SearchAllDepartment();
            ViewData["list"] = new SelectList(departmentList, "Id", "Name", employee.DepartmentId);
            return View("Information", employee);
        }

        /// <summary>
        /// 进入个人收件箱
        /// </summary>
        /// <param name="id">员工Id</param>
        /// <returns>个人收件箱页面</returns>
        public ActionResult Inbox(int id)
        {
            //获取收件箱中写消息应显示的收件人信息
            ViewBag.ToEmp = EmployeeManager.SearchEmployeeById(id);
            return View();
        }

        /// <summary>
        /// 获取指定UserName的员工信息
        /// </summary>
        /// <param name="id">UserName</param>
        /// <returns>员工信息</returns>
        [HttpPost]
        [AllowAnonymous]
        public JsonResult EmployeeMess(string id)
        {
            if (Request.IsAuthenticated)
            {
                //获取指定员工信息
                Employee emp = EmployeeManager.SearchEmployeeByUserName(id);
                return Json(emp, JsonRequestBehavior.DenyGet);
            }
            return Json("No Permission!", JsonRequestBehavior.DenyGet);
        }

        //todo:处理界面获取到的消息信息，存储在数据库并发送消息，每次获取在线时同时
        [AllowAnonymous]
        public JsonResult SendMess(OAMessage oamess,string messtype)
        {
            string result=ajaxPerm.IsAuthenticated(HttpContext);
            if (result.Equals("true", StringComparison.CurrentCultureIgnoreCase))
            {
                switch (messtype)
                {
                    case "sms":
                        break;
                    case "email":
                        break;
                    default: break;
                }
                
            }
            return Json(result);
        }
    }
}
