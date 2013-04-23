using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CJCProjectEstimatorMVC.Models;

namespace CJCProjectEstimatorMVC.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(BaseViewModel viewModel)
        {
            DBContext db = new DBContext();

            AppUser appUser = db.AppUsers.Where(a => a.UserName == viewModel.AppUserVM.UserName).FirstOrDefault();

            if (appUser == null)
            {
                ModelState.AddModelError("UserName", "User Name or Password is incorrect");
                return View();
            }
            else
            {
                String passwordHash = Hash.getHashSha256(viewModel.AppUserVM.Password + appUser.PasswordSalt);

                if (passwordHash == appUser.PasswordHash)
                {
                    setLoggedIn(appUser.Id);
                    return RedirectToAction("Index", "ProjectHome");
                }
                else
                {
                    ModelState.AddModelError("UserName", "User Name or Password is incorrect");
                    return View();
                }
            }
        }

        [HttpPost]
        public ActionResult Logout()
        {
            setLoggedOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
