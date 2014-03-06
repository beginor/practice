using System;
using System.Data.Entity;

namespace MvcTest {

    public class NorthwindContext : DbContext {

        public NorthwindContext(string connectionString) : base(connectionString) {
            Database.Log = log => Console.WriteLine(log);
        }

        public DbSet<Category> Categories {
            get;
            set;
        }
    }

    public partial class Category {

        public int CategoryId {
            get;
            set;
        }

        public string CategoryName {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }
    }
}

