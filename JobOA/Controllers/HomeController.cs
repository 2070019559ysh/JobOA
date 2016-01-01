using JobOA.BLL;
using JobOA.Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobOA.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public IEmployeeManager EmployeeManager { get; set; }
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                Employee employee=EmployeeManager.SearchEmployeeByUserName(User.Identity.Name);
                if (String.IsNullOrEmpty(employee.HeadPicture))
                {
                    //没有头像，使用默认头像
                    employee.HeadPicture = "/Content/images/oaui/default.jpg";
                }
                else
                {
                    employee.HeadPicture = "/Content/images/userImg/" + employee.HeadPicture;
                }
                ViewBag.Employee = employee;
            }
            return View();
        }

    }
}
