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
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialUnit> MaterialsUnits { get; set; }
        public DbSet<Project> Projects { get; set; }

    }


}