using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobOA.Controllers
{
    public class AdminTaskController : Controller
    {
        public int MyProperty { get; set; }
        //
        // GET: /AdminTask/

        public ActionResult Index()
        {
            //查找所有项目

            //查找所有部门
            //按分页、项目、部门和模糊任务名查找主任务
            return View();
        }

    }
}
