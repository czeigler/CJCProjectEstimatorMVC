using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CJCProjectEstimatorMVC.Models;


namespace CJCProjectEstimatorMVC.Controllers
{
    public class SignupController : Controller
    {
        //
        // GET: /Signup/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(AppUser app)
        {

            AppUserDBContext db = new AppUserDBContext();
            db.AppUsers.Add(app);
            db.SaveChanges();
            return View();
            
        }


    }
}
