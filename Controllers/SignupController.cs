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

        public ActionResult SignUp(appuser app)
        {

            EstimationToolDBEntities db = new EstimationToolDBEntities();
            db.appusers.AddObject(app);
            db.SaveChanges();
            return View();
            
        }


    }
}
