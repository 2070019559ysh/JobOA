using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobOA.Controllers
{
    public class ErrorCatchController : Controller
    {
        //
        // GET: /ErrorCatch/
        [AllowAnonymous]
        public ActionResult Error()
        {
            return View();
        }

        [AllowAnonymous]
        public ViewResult FileNotFound()
        {
            return View();
        }

        [AllowAnonymous]
        public ViewResult NoPermission()
        {
            return View();
        }
    }
}
