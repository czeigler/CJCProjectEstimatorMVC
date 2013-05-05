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


            List<Project> Projects = db.Projects.Where(p => p.AppUserId == currentUserId).ToList<Project>();

            var projects = from p in Projects
                           join pl in db.ProjectLaborItems on p.ProjectId equals pl.ProjectId into plg
                           join pm in db.ProjectMaterials on p.ProjectId equals pm.ProjectId into pmg
                           select new
                           {
                               Name = p.Name,
                               CountLabor = plg.Select(a => a.ProjectId).Count(),
                               CountMaterial = pmg.Select(a => a.ProjectId).Count(),
                               CostMaterial = pmg.Select(a => (Double?)(a.Cost == null ? 0 : a.Cost) * (a.Number == null ? 0 : a.Number)).Sum(),
                               CostLabor = plg.Select(a => (Double?)(a.CostPerHour == null ? 0 : a.CostPerHour) * (a.Hours == null ? 0 : a.Hours)).Sum()
                           };


            foreach (var project in projects)
            {
                ProjectReportLineViewModel ProjectReportLineItem = new ProjectReportLineViewModel();
                ProjectReportLineItem.Name = project.Name;
                ProjectReportLineItem.QuantityOfMaterials = project.CountMaterial;
                ProjectReportLineItem.QuantityOfTasks = project.CountLabor;
                ProjectReportLineItem.TotalLaborCost = project.CostLabor == null ? 0D : (Double) project.CostLabor;
                ProjectReportLineItem.TotalMaterialCost = project.CostMaterial == null ? 0D : (Double) project.CostMaterial;
                ProjectReportLineItem.TotalCost = ProjectReportLineItem.TotalLaborCost + ProjectReportLineItem.TotalMaterialCost;
                projectReportViewModel.Projects.Add(ProjectReportLineItem);
                ++projectReportViewModel.numProjects;
                projectReportViewModel.totalProjectCost += ProjectReportLineItem.TotalCost;

            }
            if (projectReportViewModel.numProjects > 0) {
                projectReportViewModel.avgProjectCost = projectReportViewModel.totalProjectCost / projectReportViewModel.numProjects;
            } else {
                projectReportViewModel.avgProjectCost = 0;
            }

            return View(projectReportViewModel);


        }

    }
}
