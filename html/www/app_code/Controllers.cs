using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

/// <summary>
/// Summary description for CategoryController
/// </summary>
public class CategoryController : ApiController {

    private static IList<Category> data = new List<Category> {
        new Category { CategoryId = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, be"},
        new Category { CategoryId = 2, CategoryName = "Condiments", Description = "Sweet and savory sauces, relis"},
        new Category { CategoryId = 3, CategoryName = "Confections", Description = "Desserts, candies, and sweet b"},
        new Category { CategoryId = 4, CategoryName = "Dairy Products", Description = "Cheeses"},
        new Category { CategoryId = 5, CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and c"},
        new Category { CategoryId = 6, CategoryName = "Meat/Poultry", Description = "Prepared meats"},
        new Category { CategoryId = 7, CategoryName = "Produce", Description = "Dried fruit and bean curd"},
        new Category { CategoryId = 8, CategoryName = "Seafood", Description = "Seaweed and fish"}
    };

    public IEnumerable<Category> GetAll() {
        return data;
    }

    public IHttpActionResult Get(int id) {
        var c = data.FirstOrDefault(cat => cat.CategoryId == id);
        if (c == null) {
            return NotFound();
        }
        return Ok(c);
    }

    public IHttpActionResult Post(Category category) {
        category.CategoryId = data.Count + 1;
        data.Add(category);
        var response = Request.CreateResponse(category);
        var url = Url.Link("DefaultApi", new { id = category.CategoryId });
        response.Headers.Location = new Uri(url);
        return ResponseMessage(response);
    }

    public IHttpActionResult Put([FromUri]int id, [FromBody]Category category) {
        var cat = data.FirstOrDefault(c => c.CategoryId == id);
        if (cat == null) {
            return NotFound();
        }
        cat.CategoryName = category.CategoryName;
        cat.Description = category.Description;
        return Ok(cat);
    }

    public IHttpActionResult Delete(int id) {
        var cat = data.FirstOrDefault(c => c.CategoryId == id);
        if (cat != null) {
            data.Remove(cat);
        }
        return StatusCode(System.Net.HttpStatusCode.NoContent);
    }
}