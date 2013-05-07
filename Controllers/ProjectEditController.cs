using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CJCProjectEstimatorMVC.Models;

namespace CJCProjectEstimatorMVC.Controllers
{
    [CustomAuthorize]
    public class ProjectEditController : BaseController
    {

        private ProjectEditViewModel load(Int32? ProjectId)
        {
            ProjectEditViewModel projectEditVM = new ProjectEditViewModel();
            ProjectReportLineViewModel ProjectReportLineItem = new ProjectReportLineViewModel();
            DBContext db = new DBContext();
            Project project = new Project();
            ProjectLaborItem projectLaborItem = new ProjectLaborItem();
            ProjectMaterial projectMaterial = new ProjectMaterial();
            List<ProjectLaborItem> projectLaborItems = new List<ProjectLaborItem>();
            List<ProjectMaterial> projectMaterials = new List<ProjectMaterial>();
            List<ProjectMaterialViewModel> projectMaterialViewModels = new List<ProjectMaterialViewModel>();

            if (ProjectId != null && ProjectId > 0)
            {
                projectLaborItem.ProjectId = (Int32)ProjectId;
                projectMaterial.ProjectId = (Int32)ProjectId;
                project = db.Projects.Where(p => p.ProjectId == ProjectId).FirstOrDefault();
                projectLaborItems = db.ProjectLaborItems.Where(p => p.ProjectId == project.ProjectId).ToList<ProjectLaborItem>();
                projectMaterials = db.ProjectMaterials.Where(p => p.ProjectId == project.ProjectId).ToList<ProjectMaterial>();
                foreach (ProjectMaterial pm in projectMaterials)
                {
                    Material pmLookup = db.Materials.Where(m => m.MaterialId == pm.MaterialId).First();
                    ProjectMaterialViewModel projectMaterialViewModel = new ProjectMaterialViewModel();
                    projectMaterialViewModel.ProjectMaterialId = pm.ProjectMaterialId;
                    projectMaterialViewModel.Cost = pm.Cost;
                    projectMaterialViewModel.Number = pm.Number;
                    projectMaterialViewModel.Name = pmLookup.Name;
                    projectMaterialViewModels.Add(projectMaterialViewModel);

                }

                    
                var projectCosts = from p in db.Projects
                               join pl in db.ProjectLaborItems on p.ProjectId equals pl.ProjectId into plg
                               join pm in db.ProjectMaterials on p.ProjectId equals pm.ProjectId into pmg
                               where p.ProjectId == (int)ProjectId
                               select new
                               {
                                   Name = p.Name,
                                   CountLabor = plg.Select(a => a.ProjectId).Count(),
                                   CountMaterial = pmg.Select(a => a.ProjectId).Count(),
                                   CostMaterial = pmg.Select(a => (Double?)(a.Cost == null ? 0 : a.Cost) * (a.Number == null ? 0 : a.Number)).Sum(),
                                   CostLabor = plg.Select(a => (Double?)(a.CostPerHour == null ? 0 : a.CostPerHour) * (a.Hours == null ? 0 : a.Hours)).Sum()
                               };

                foreach (var projectCost in projectCosts)
                {

                    ProjectReportLineItem = new ProjectReportLineViewModel();
                    ProjectReportLineItem.Name = project.Name;
                    ProjectReportLineItem.QuantityOfMaterials = projectCost.CountMaterial;
                    ProjectReportLineItem.QuantityOfTasks = projectCost.CountLabor;
                    ProjectReportLineItem.TotalLaborCost = projectCost.CostLabor == null ? 0D : (Double)projectCost.CostLabor;
                    ProjectReportLineItem.TotalMaterialCost = projectCost.CostMaterial == null ? 0D : (Double)projectCost.CostMaterial;
                    ProjectReportLineItem.TotalCost = ProjectReportLineItem.TotalLaborCost + ProjectReportLineItem.TotalMaterialCost;
                    
                }
            }

            projectEditVM.project = project;
            projectEditVM.ProjectCosts = ProjectReportLineItem;
            projectEditVM.projectLaborItem = projectLaborItem;
            projectEditVM.projectMaterial = projectMaterial;
            projectEditVM.projectLaborItems = projectLaborItems;
            projectEditVM.projectMaterials = projectMaterials;
            projectEditVM.projectMaterialViewModels = projectMaterialViewModels;
            return projectEditVM;
        }


        //
        // GET: /ProjectEdit/


        [HttpGet]
        public ActionResult Index(Int32? ProjectId)
        {
            ProjectEditViewModel projectEditVM = load(ProjectId);
            return View("Index", projectEditVM);
        }


        [HttpPost]        
        public ActionResult Index(ProjectEditViewModel projectEditVM)
        {

            DBContext db = new DBContext();
             
            if (db.Projects.Where(p => p.Name == projectEditVM.project.Name).Where(p => p.ProjectId != projectEditVM.project.ProjectId).FirstOrDefault() != null)
            {
                ModelState.AddModelError("ProjectEditViewModel.project.Name", "Project Name \"" + projectEditVM.project.Name + "\" is already being used");
            }

            Project project;
            if (ModelState.IsValid)
            {
                project = new Project();
                if (projectEditVM.project.ProjectId > 0)
                {
                    project = db.Projects.First(p => p.ProjectId == projectEditVM.project.ProjectId);
                }
                else
                {
                    db.Projects.Add(project);
                }
                project.Name = projectEditVM.project.Name;
                project.AppUserId = (int)getCurrentUserId();

                db.SaveChanges();
                projectEditVM = load(project.ProjectId);
                projectEditVM.project.ProjectId = project.ProjectId;

            }
            else
            {

                projectEditVM = load(projectEditVM.project.ProjectId);
            }

            return View("Index", projectEditVM);            
        

        }

        [HttpPost] 
        public ActionResult AddProjectLaborItem(ProjectEditViewModel projectEditVM)
        {
            DBContext db = new DBContext();
            if (ModelState.IsValid)
            {

                db.ProjectLaborItems.Add(projectEditVM.projectLaborItem);
                db.SaveChanges();

            }

            projectEditVM = load(projectEditVM.projectLaborItem.ProjectId);
            return View("Index", projectEditVM);
        }

        [HttpPost] 
        public ActionResult AddProjectMaterial(ProjectEditViewModel projectEditVM)
        {
            DBContext db = new DBContext();
            if (ModelState.IsValid)
            {

                db.ProjectMaterials.Add(projectEditVM.projectMaterial);
                db.SaveChanges();

            }

            projectEditVM = load(projectEditVM.projectMaterial.ProjectId);
            return View("Index", projectEditVM);
        }


        [HttpGet]
        public ActionResult RemoveProjectLaborItem(Int32 ProjectLaborItemId)
        {
            DBContext db = new DBContext();

            ProjectLaborItem projectLaborItem = db.ProjectLaborItems.Where(p => p.ProjectLaborItemId == ProjectLaborItemId).FirstOrDefault();

            Int32? ProjectId = null;

            if (projectLaborItem != null)
            {
                ProjectId = projectLaborItem.ProjectId;
                Project project = db.Projects.Where(p => p.ProjectId == ProjectId).FirstOrDefault();
                if (project != null && project.AppUserId.Equals(getCurrentUserId()))
                {
                    db.ProjectLaborItems.Remove(projectLaborItem);
                    db.SaveChanges();
                }

            }

            ProjectEditViewModel projectEditVM = load(ProjectId);
            return View("Index", projectEditVM);
        }

        [HttpGet]
        public ActionResult RemoveProjectMaterial(Int32 ProjectMaterialId)
        {
            DBContext db = new DBContext();

            ProjectMaterial projectMaterial = db.ProjectMaterials.Where(p => p.ProjectMaterialId == ProjectMaterialId).FirstOrDefault();

            Int32? ProjectId = null;

            if (projectMaterial != null)
            {
                ProjectId = projectMaterial.ProjectId;
                Project project = db.Projects.Where(p => p.ProjectId == ProjectId).FirstOrDefault();
                if (project != null && project.AppUserId.Equals(getCurrentUserId()))
                {
                    db.ProjectMaterials.Remove(projectMaterial);
                    db.SaveChanges();
                }

            }

            ProjectEditViewModel projectEditVM = load(ProjectId);
            return View("Index", projectEditVM);
        }




        [HttpGet]
        public ActionResult RemoveProject(Int32? ProjectId)
        {
            DBContext db = new DBContext();
            
            Project project = db.Projects.Where(p => p.ProjectId == ProjectId).FirstOrDefault();

            if (project != null && project.AppUserId.Equals(getCurrentUserId()))
            {
                foreach (ProjectMaterial pm in db.ProjectMaterials.Where(p => p.ProjectId == ProjectId)) 
                {
                    db.ProjectMaterials.Remove(pm);
                }

                foreach (ProjectLaborItem pl in db.ProjectLaborItems.Where(p => p.ProjectId == ProjectId)) 
                {
                    db.ProjectLaborItems.Remove(pl);
                }
                db.SaveChanges();
                db.Projects.Remove(project);
                db.SaveChanges();

            }

            return Redirect("~/ProjectList");
        }




    }
}
