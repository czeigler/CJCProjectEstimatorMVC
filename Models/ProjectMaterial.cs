﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJCProjectEstimatorMVC.Models
{
    public class ProjectMaterial
    {
        public int ProjectMaterialId { get; set; }
	    public int ProjectId { get; set; }
	    public int MaterialId { get; set; }
	    public double Number { get; set; }
        public double Cost { get; set; }
    }
}