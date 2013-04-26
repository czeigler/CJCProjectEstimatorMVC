using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CJCProjectEstimatorMVC.Models;

namespace CJCProjectEstimatorMVC.Controllers
{
    public class ProjectEditController : BaseController
    {
        //
        // GET: /ProjectEdit/


        [HttpGet]
        public ActionResult Index(Int32? ProjectId)
        {
            ProjectEditViewModel projectEditVM = new ProjectEditViewModel();

            DBContext db = new DBContext();
            Project project = new Project();
            ProjectLaborItem projectLaborItem = new ProjectLaborItem();
            ProjectMaterial projectMaterial = new ProjectMaterial();
            List<ProjectLaborItem> projectLaborItems = new List<ProjectLaborItem>();
            List<ProjectMaterial> projectMaterials = new List<ProjectMaterial>();

            if (ProjectId != null)
            {
                project = db.Projects.Where(p => p.ProjectId == ProjectId).FirstOrDefault();
                projectLaborItems = db.ProjectLaborItems.Where(p => p.ProjectId == project.ProjectId).ToList<ProjectLaborItem>();
            }



            
            projectEditVM.project = project;
            projectEditVM.projectLaborItems = projectLaborItems;
            projectEditVM.projectMaterials = projectMaterials;

            return View("Index", projectEditVM);
        }

        [HttpPost]        
        public ActionResult Index(ProjectEditViewModel projectEditVM)
        {

            DBContext db = new DBContext();

            if (db.Projects.Where(p => p.Name == projectEditVM.project.Name).FirstOrDefault() != null)
            {
                ModelState.AddModelError("project.Name", "Project Name \"" + projectEditVM.project.Name + "\" is already being used");
            }

            if (ModelState.IsValid)
            {
                projectEditVM.project.AppUserId = (int) getCurrentUserId();
                db.Projects.Add(projectEditVM.project);
                db.SaveChanges();
                
            }

            projectEditVM.projectLaborItem = new ProjectLaborItem();
            projectEditVM.projectLaborItem.ProjectId = projectEditVM.project.ProjectId;

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


            return View("Index");
        }

        [HttpPost] 
        public ActionResult AddProjectMaterial(ProjectEditViewModel projectEditVM)
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult Remove(Int32? ProjectId)
        {
            DBContext db = new DBContext();
            
            Project project = db.Projects.Where(p => p.ProjectId == ProjectId).FirstOrDefault();

            if (project.AppUserId.Equals(getCurrentUserId()))
            {
                if (project != null)
                {
                    db.Projects.Remove(project);
                    db.SaveChanges();
                }
            }

            return Redirect("~/ProjectList");
        }




    }
}
