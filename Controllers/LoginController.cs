using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CJCProjectEstimatorMVC.Models;

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
        public String Login(User user)
        {
            return user.UserName + "<br />" + user.Password;
            //return RedirectToAction("Index", "ProjectHome");
        }

        [HttpPost]
        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
