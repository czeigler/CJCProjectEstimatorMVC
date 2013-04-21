using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CJCProjectEstimatorMVC.Models;

namespace CJCProjectEstimatorMVC.Controllers
{
    public class ProjectEditController : Controller
    {
        //
        // GET: /ProjectEdit/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Project project)
        {

            DBContext db = new DBContext();

            if (db.Projects.Where(p => p.Name == project.Name).FirstOrDefault() != null)
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

                setLoggedIn(appUser.Id);

                return Redirect("~/Signup/Thankyou");
            }
            else
            {
                return View(user);
            }
            
        }

        }



    }
}
