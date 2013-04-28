﻿using System;
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

            DBContext db = new DBContext();
            Project project = new Project();
            ProjectLaborItem projectLaborItem = new ProjectLaborItem();
            ProjectMaterial projectMaterial = new ProjectMaterial();
            List<ProjectLaborItem> projectLaborItems = new List<ProjectLaborItem>();
            List<ProjectMaterial> projectMaterials = new List<ProjectMaterial>();

            if (ProjectId != null)
            {
                projectLaborItem.ProjectId = (Int32)ProjectId;
                projectMaterial.ProjectId = (Int32)ProjectId;
                project = db.Projects.Where(p => p.ProjectId == ProjectId).FirstOrDefault();
                projectLaborItems = db.ProjectLaborItems.Where(p => p.ProjectId == project.ProjectId).ToList<ProjectLaborItem>();
                projectMaterials = db.ProjectMaterials.Where(p => p.ProjectId == project.ProjectId).ToList<ProjectMaterial>();

            }

            projectEditVM.project = project;
            projectEditVM.projectLaborItem = projectLaborItem;
            projectEditVM.projectMaterial = projectMaterial;
            projectEditVM.projectLaborItems = projectLaborItems;
            projectEditVM.projectMaterials = projectMaterials;
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

            projectEditVM = load(projectEditVM.project.ProjectId);

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
                db.Projects.Remove(project);
                db.SaveChanges();

            }

            return Redirect("~/ProjectList");
        }




    }
}
