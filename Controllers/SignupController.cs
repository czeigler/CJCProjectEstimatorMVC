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

        public ActionResult Thankyou()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AppUserViewModel user)
        {


            AppUserDBContext db = new AppUserDBContext();

            if (db.AppUsers.Where(a => a.UserName == user.UserName).FirstOrDefault() != null)
            {
                ModelState.AddModelError("UserName", "User Name \"" + user.UserName  + "\" is already being used");
            }

            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();

                appUser.FirstName = user.FirstName;
                appUser.LastName = user.LastName;
                appUser.UserName = user.UserName;
                appUser.CompanyName = user.CompanyName;
                appUser.PasswordSalt = DateTime.Now.ToString();
                appUser.PasswordHash = Hash.getHashSha256(user.Password + appUser.PasswordSalt);

                
                db.AppUsers.Add(appUser);
                db.SaveChanges();
                return Redirect("~/Signup/Thankyou");
            }
            else
            {
                return View(user);
            }
            
        }


    }
}
