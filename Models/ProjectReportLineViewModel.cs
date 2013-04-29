using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJCProjectEstimatorMVC.Models
{
    public class ProjectReportLineViewModel : Project
    {

        public Int32 QuantityOfMaterials { get; set; }
        public Double TotalMaterialCost { get; set; }
        public Int32 QuantityOfTasks { get; set; }
        public Double TotalLaborCost { get; set; }
        public Double TotalCost { get; set; }

    }
}