using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using System.Linq;

namespace ConsoleApp.Data {

    public class DataContext : DbContext {

        private static bool created;

        public DataContext() {
            if (!created) {
                Database.AsRelational().ApplyMigrations();
                created = true;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            var connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;";
            options.UseSqlServer(connectionString);
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            //if (Categories.Count() == 0) {
            //    var category = new Category {
            //        Id = 1
            //    }
            //}
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

    }

}