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

        [Required(ErrorMessage = "Please enter a User Name")]
        [StringLength(40, ErrorMessage = "User Name is too long")]
        public String UserName { get; set; }

        [Required(ErrorMessage = "Please enter a First Name")]
        [StringLength(40, ErrorMessage = "First Name is too long")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a Last Name")]
        [StringLength(40, ErrorMessage = "Last Name is too long")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Please enter a Password")]
        [StringLength(256, ErrorMessage = "Password is too long")]
        public String PasswordHash { get; set; }

        [Required]
        [StringLength(256)]
        public String PasswordSalt { get; set; }

        [StringLength(40, ErrorMessage = "Company Name is too long")]
        public String CompanyName { get; set; }

    }



}