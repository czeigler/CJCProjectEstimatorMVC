﻿using System;
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
        public ActionResult Index(AppUserViewModel user)
        {
            AppUserDBContext db = new AppUserDBContext();

            AppUser appUser = db.AppUsers.Where(a => a.UserName == user.UserName).FirstOrDefault();

            if (appUser == null)
            {
                ModelState.AddModelError("UserName", "User Name or Password is incorrect");
            }

            String passwordHash = Hash.getHashSha256(user.Password + appUser.PasswordSalt);

            if (passwordHash == appUser.PasswordHash)
            {
                setLoggedIn(appUser.Id);
                return RedirectToAction("Index", "ProjectHome");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
