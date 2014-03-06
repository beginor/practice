using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace EntityFxTest.Data {

    class Northwind : DbContext {

        public Northwind(string connectionString) : base(connectionString) {
        }

        public virtual DbSet<Category> Categories { get; set; }

        //public virtual DbSet<Order_Details> Order_Details { get; set; }
        
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }

    }

    public partial class Category {

        public Category() {
            this.Products = new HashSet<Product>();
        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }

    public partial class Product {

        public Product() {
        }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<short> UnitsInStock { get; set; }
        public Nullable<short> UnitsOnOrder { get; set; }
        public Nullable<short> ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public virtual Category Category { get; set; }

    }

    
}
