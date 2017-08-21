using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobOA.BLL;
using Ninject;
using JobOA.Model;
using System.Text;

namespace JobOA.Controllers
{
    /// <summary>
    /// 开始工作管理主页的控制器
    /// </summary>
    public class AdminHomeController : Controller
    {
        /// <summary>
        /// 依赖注入员工信息管理对象
        /// </summary>
        [Inject]
        public IEmployeeManager EmployeeManager { get; set; }

        /// <summary>
        /// 依赖注入系统界面信息管理对象
        /// </summary>
        [Inject]
        public IOAUiManager OAUiManager { get; set; }
        //
        // GET: /AdminHome/
        /// <summary>
        /// GET请求进入后台开始工作首页
        /// </summary>
        /// <returns>开始工作首页视图</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取所有员工的在线状态信息
        /// </summary>
        /// <returns>所有员工的在线状态信息json</returns>
        [AllowAnonymous]
        public JsonResult GetOnlineState()
        {
            List<Employee> employeeList = EmployeeManager.SearchAllEmployee();
            List<Employee> onLineEmp = new List<Employee>();//在线员工
            List<Employee> offLineEmp = new List<Employee>();//离线员工
            employeeList.ForEach(emp =>
            {
                string[] pictures=emp.HeadPicture.Split(',');
                if (pictures.Length > 0)
                {
                    emp.HeadPicture = pictures[0];
                }
                if (emp.OnlineState == (int)OnlineState.onLine)
                {
                    onLineEmp.Add(emp);
                }
                else
                {
                    offLineEmp.Add(emp);
                }
            });
            return Json(new { online = onLineEmp, offline = offLineEmp });
        }

        [AllowAnonymous]
        [HttpGet]
        public MvcHtmlString LoadRemark()
        {
            //获取系统界面信息
            List<OAUi> noticeOauiList = OAUiManager.SearchOauiByType("joboa_System_Notice",6);
            StringBuilder htmlContent =new StringBuilder();
            //传递给界面显示
            if (noticeOauiList != null)
            {
                foreach (var oaui in noticeOauiList)
                {
                    htmlContent.AppendFormat("<div class=\"am-panel am-panel-default admin-sidebar-panel\"><div class=\"am-panel-bd\"><p><span class=\"am-icon-bookmark\"></span> &nbsp;{0}</p><p>{1}</p></div></div>",
                        oaui.UiTitle,oaui.UiMess);
                }
            }else{
                htmlContent.Append("<div class=\"am-panel am-panel-default admin-sidebar-panel\"><div class=\"am-panel-bd\"><p><span class=\"am-icon-bookmark\"></span> &nbsp;公告</p><p>时光静好，与君语；细水流年，与君同。—— Amaze UI</p></div></div>");
            }
            MvcHtmlString htmlString = new MvcHtmlString(htmlContent.ToString());
            return htmlString;
        }
    }
}
