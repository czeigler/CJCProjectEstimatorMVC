using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CJCProjectEstimatorMVC.Models
{
    public class Project
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
        
        [Required]
        [StringLength(40)]
        public String Name { get; set; }

        [Required]
        public int AppUserId { get; set; }
    }
}