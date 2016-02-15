using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobOA.Controllers
{
    public class PersonalInfoController : Controller
    {
        //
        // GET: /PersonalInfo/
        [ActionName("Information")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
