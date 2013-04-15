using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace CJCProjectEstimatorMVC.Models
{
    public class AppUser
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        private String userName;

        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private String firstName;

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private String lastName;

        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private String passwordHash;

        public String PasswordHash
        {
            get { return passwordHash; }
            set { passwordHash = value; }
        }

        private String passwordSalt;

        public String PasswordSalt
        {
            get { return passwordSalt; }
            set { passwordSalt = value; }
        }
        
        private String companyName;

        public String CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

    }

    public class AppUserDBContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
    }

}