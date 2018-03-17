using System.Data.Entity;
using Lab3.Data.Entities;

namespace Lab3.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
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

        public System.Data.Entity.DbSet<Lab3.Models.View.CarViewModel> CarViewModels { get; set; }
    }
}