using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CJCProjectEstimatorMVC.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login()
        {
            return RedirectToAction("Index", "ProjectHome");
        }

        [HttpPost]
        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
