using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CJCProjectEstimatorMVC.Models
{
    public class DBContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
    }


}