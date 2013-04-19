using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CJCProjectEstimatorMVC.Models
{
    public class Material
    {
        public int MaterialId { get; set; }

        [Required]
        [StringLength(45)]
        public String Name { get; set; }
        
        [Required]
        [StringLength(256)]
        public String Description { get; set; }

        [Required]
        public float Cost { get; set; }

        [Required]
        public int MaterialUnitId { get; set; }

    }

    

}