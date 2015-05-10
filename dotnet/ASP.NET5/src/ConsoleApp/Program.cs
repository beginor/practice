using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using ConsoleApp.Data;
using Microsoft.Data.Entity;

namespace ConsoleApp {

    public class Program {

        public void Main(string[] args) {
            var connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;";
            IServiceCollection services = new ServiceCollection();
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            var serviceProvider = services.BuildServiceProvider();
            //serviceProvider.Add
            
            var context = serviceProvider.GetService<DataContext>();

            var categoryCount = context.Categories.Count();
            Console.WriteLine($"category count is {categoryCount}");

            var newCat = new Category {
                Name = $"Category {categoryCount + 1}",
                Description = $"Category {categoryCount + 1} description"
            };
            context.Add(newCat);
            //context.SaveChanges();
            var count = context.SaveChanges();
            Console.WriteLine($"change count is {count}");
            context.Dispose();
            Console.WriteLine("Hello, world!");
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddEntityFramework();
            
        }
    }

}
