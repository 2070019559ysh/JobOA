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

        [Inject]
        public IOAUiManager OAUiManager { get; set; }

        //
        // GET: /Home/
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            //获取系统界面信息
            List<OAUi> pictureOauiList=OAUiManager.SearchOauiByType("joboa_System_PictureCarousel");
            List<OAUi> infoOauiList = OAUiManager.SearchOauiByType("joboa_System_InfoList",20);
            List<OAUi> footHeadOauiList = OAUiManager.SearchOauiByType("joboa_System_FootHead",5);
            List<OAUi> footContentOauiList = OAUiManager.SearchOauiByType("joboa_System_FootContent", 6);
            //传递给界面显示
            ViewBag.PictureOauiList = pictureOauiList;
            ViewBag.infoOauiList = infoOauiList;
            ViewBag.footHeadOauiList = footHeadOauiList;
            ViewBag.footContentOauiList = footContentOauiList;
            return View();
        }

    }
}
