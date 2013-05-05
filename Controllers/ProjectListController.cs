using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CJCProjectEstimatorMVC.Models;
using System.Data.Objects;

namespace CJCProjectEstimatorMVC.Controllers
{
    [CustomAuthorize]
    public class ProjectListController : BaseController
    {
        //
        // GET: /ProjectList/

        [HttpGet]
        public ActionResult Index(String projectName)
        {
            DBContext db = new DBContext();

            ProjectListViewModel projectListViewModel = new ProjectListViewModel();
            Int32 currentUserId = (Int32)getCurrentUserId() + 0;
            if (projectName != null && projectName.Length > 0)
            {
                projectListViewModel.Projects = db.Projects.Where(p => p.AppUserId == currentUserId).Where(p => p.Name.Contains(projectName)).ToList<Project>();
            }
            else
            {
                projectListViewModel.Projects = db.Projects.Where(p => p.AppUserId == currentUserId).ToList<Project>();
            }

            return View(projectListViewModel);
        }

    }
}
