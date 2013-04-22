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

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]        
        public ActionResult Index(Project project)
        {

            DBContext db = new DBContext();

            if (db.Projects.Where(p => p.Name == project.Name).FirstOrDefault() != null)
            {
                ModelState.AddModelError("Name", "Project Name \"" + project.Name  + "\" is already being used");
            }

            if (ModelState.IsValid)
            {
                
                db.Projects.Add(project);
                db.SaveChanges();
                
            }
            return View();            
        

        }



    }
}
