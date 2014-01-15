using System;
using System.Linq;
using EntityFxTest.Data;

namespace EntityFxTest {

    public class ContextTest {

        public static void Main(string[] args) {
            var connectionString = "Data Source=172.21.24.145;Initial Catalog=Northwind;User Id=udev;Password=devdev;Connect Timeout=15;";
            using (var db = new Northwind(connectionString)) {

                db.Database.Log = l => Console.WriteLine(l);

                var categories = db.Categories.ToList();
                foreach (var c in categories) {
                    Console.WriteLine("{0:D2} \t {1} \t {2}", c.CategoryID, c.CategoryName, c.Description);
                }
            }

        }
    }
}