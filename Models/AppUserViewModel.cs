using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace CJCProjectEstimatorMVC.Models
{
    public class AppUserViewModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        private String userName;

        [Required(ErrorMessage="Please enter a User Name")]
        [StringLength(45, ErrorMessage="User Name is too long")]
        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private String firstName;

        [Required(ErrorMessage = "Please enter a First Name")]
        [StringLength(45, ErrorMessage = "First Name is too long")]
        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private String lastName;

        [Required(ErrorMessage = "Please enter a Last Name")]
        [StringLength(45, ErrorMessage = "Last Name is too long")]
        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private String password;

        [Required(ErrorMessage = "Please enter a Password")]
        [StringLength(15, ErrorMessage = "Password is too long")]
        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        private String passwordConfirm;

        [Compare("Password", ErrorMessage="Password and Confirm Password must match")]
        [Required(ErrorMessage = "Please enter a Password Confirmation")]
        [StringLength(15, ErrorMessage = "Password Confirmation is too long")]
        public String PasswordConfirm
        {
            get { return passwordConfirm; }
            set { passwordConfirm = value; }
        }

        private String companyName;

        [StringLength(45, ErrorMessage = "Company Name is too long")]
        public String CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

    }

}