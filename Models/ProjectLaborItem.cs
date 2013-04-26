using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CJCProjectEstimatorMVC.Models
{
    public class ProjectLaborItem
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProjectLaborItemId { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(50)]
        public String Description { get; set; }

        [Required]
        public double Hours { get; set; }

        [Required]
        public double CostPerHour { get; set; }

    }
}