using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Final_Project.Data.Entities;

namespace Final_Project.Data
{
    public class AppDbContext : DbContext
    {
        //public virtual DbSet<Friend> Friends { get; set; }
        //public virtual DbSet<Car> Cars { get; set; }

        // public System.Data.Entity.DbSet<Lab3.Models.View.UserViewModel> UserViewModels { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new AppDbInitializer());
        }


        public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
        {
            // intentionally left blank
        }

        //public System.Data.Entity.DbSet<Final_Project.Models.View.CarViewModel> CarViewModels { get; set; }
    }
}