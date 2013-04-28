﻿using System;
using System.Web;
using System.Web.Mvc;

namespace CJCProjectEstimatorMVC.Controllers
{
    [CustomAuthorize]
    public class ProjectHomeController : BaseController
    {
        //
        // GET: /ProjectHome/

        public ActionResult Index()
        {
            return View();
        }

    }
}
