using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJCProjectEstimatorMVC.Models
{
    public class ProjectReportViewModel : BaseViewModel
    {

        public List<ProjectReportLineViewModel> Projects { get; set; }

        public Double avgProjectCost { get; set; }
        public Double totalProjectCost { get; set; }
        public Int32 numProjects { get; set; }


        public ProjectReportViewModel() 
        {
            Projects = new List<ProjectReportLineViewModel>();
        }

        


    }
}