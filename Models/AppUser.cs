using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CJCProjectEstimatorMVC.Models
{
    public class AppUser
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public String UserName { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String PasswordHash { get; set; }

        public String PasswordSalt { get; set; }

        public String CompanyName { get; set; }

    }



}