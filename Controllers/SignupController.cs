using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CJCProjectEstimatorMVC.Models;


namespace CJCProjectEstimatorMVC.Controllers
{
    public class SignupController : BaseController
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
        public ActionResult Index(SignupViewModel user)
        {


            DBContext db = new DBContext();

            if (db.AppUsers.Where(a => a.UserName == user.AppUserVM.UserName).FirstOrDefault() != null)
            {
                ModelState.AddModelError("UserName", "User Name \"" + user.AppUserVM.UserName + "\" is already being used");
            }

            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();

                appUser.FirstName = user.AppUserVM.FirstName;
                appUser.LastName = user.AppUserVM.LastName;
                appUser.UserName = user.AppUserVM.UserName;
                appUser.CompanyName = user.AppUserVM.CompanyName;
                appUser.PasswordSalt = DateTime.Now.ToString();
                appUser.PasswordHash = Hash.getHashSha256(user.AppUserVM.Password + appUser.PasswordSalt);

                
                db.AppUsers.Add(appUser);
                db.SaveChanges();

                setLoggedIn(appUser.Id);

                return Redirect("~/ProjectHome");
            }
            else
            {
                return View(user);
            }
            
        }


    }
}
