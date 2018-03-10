using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Lab8_Bradley_Bergstrom.Data.Entities;

namespace Lab8_Bradley_Bergstrom.Data
{
    public class AppDbContext : DbContext
    {
        // public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Car> Cars { get; set; }

        // public System.Data.Entity.DbSet<Lab3.Models.View.UserViewModel> UserViewModels { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new AppDbInitializer());
        }


        public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
        {
            // intentionally left blank
        }

        public System.Data.Entity.DbSet<Lab8_Bradley_Bergstrom.Models.View.CarViewModel> CarViewModels { get; set; }
    }
}