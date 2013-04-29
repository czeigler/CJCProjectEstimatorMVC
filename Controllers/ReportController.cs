using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CJCProjectEstimatorMVC.Models;

namespace CJCProjectEstimatorMVC.Controllers
{
    [CustomAuthorize]
    public class ReportController : BaseController
    {
        //
        // GET: /Report/

        public ActionResult Index()
        {
            DBContext db = new DBContext();

            ProjectReportViewModel projectReportViewModel = new ProjectReportViewModel();
            Int32 currentUserId = (Int32)getCurrentUserId() + 0;
            Double totalCost = 0;




            String query = "select p.* from Projects p join ProjectMaterials pm on p.ProjectId = pm.ProjectId where AppUserId = " + currentUserId;

            List<Project> Projects = db.Projects.ToList<Project>();

            var projects = from p in Projects where p.AppUserId == currentUserId select p;


            foreach (Project project in projects)
            {
                ProjectReportLineViewModel ProjectReportLineItem = new ProjectReportLineViewModel();
                ProjectReportLineItem.Name = project.Name;
                ProjectReportLineItem.QuantityOfMaterials = 0;
                ProjectReportLineItem.QuantityOfTasks = 0;
                projectReportViewModel.Projects.Add(ProjectReportLineItem);

                 //totalCost += 
                

            }

            return View(projectReportViewModel);


        }

    }
}
