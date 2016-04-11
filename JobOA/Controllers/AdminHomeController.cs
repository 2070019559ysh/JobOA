using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobOA.BLL;
using Ninject;
using JobOA.Model;

namespace JobOA.Controllers
{
    /// <summary>
    /// 开始工作管理主页的控制器
    /// </summary>
    public class AdminHomeController : Controller
    {
        [Inject]
        public IEmployeeManager EmployeeManager { get; set; }
        //
        // GET: /AdminHome/

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
    }
}
