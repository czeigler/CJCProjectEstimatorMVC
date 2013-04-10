using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJCProjectEstimatorMVC.Models
{
    public class User
    {
        private String userName;

        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private String password;

        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private String company;

        public String Company
        {
            get { return company; }
            set { company = value; }
        }
        private String email;

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        

    }
}