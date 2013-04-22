using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CJCProjectEstimatorMVC.Models;
using System.Data.Objects;

namespace CJCProjectEstimatorMVC.Controllers
{
    public class ProjectListController : BaseController
    {
        //
        // GET: /ProjectList/

        [HttpGet]
        public ActionResult Index()
        {
            DBContext db = new DBContext();

            ProjectListViewModel projectListViewModel = new ProjectListViewModel();

            projectListViewModel.Projects = db.Projects.ToList();

            return View(projectListViewModel);
        }

    }
}
