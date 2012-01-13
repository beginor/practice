using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mono.Data.Sqlite;
using GDEIC.AppFx.Data;

namespace StoryboardDemo {

	public static class Northwind {
		
		private static string _connStr = string.Format("data source={0}/Assets/northwind.db3", Environment.CurrentDirectory);
		
		public static Task<Category[]> LoadCategories() {
			var db = Database.Open(_connStr);
			return db.QueryAsync<Category>("SELECT * FROM Categories");
		}
		
		public static Task<Product[]> LoadProducts(long categoryId) {
			var db = Database.Open(_connStr);
			return db.QueryAsync<Product>("SELECT ProductID, ProductName, QuantityPerUnit FROM Products WHERE CategoryID = @0", categoryId);
		}
		
		public static Task<Product> GetProduct(long productId) {
			var db = Database.Open(_connStr);
			return db.QuerySingleAsync<Product>("SELECT * FROM Products WHERE ProductID = @0", productId);
		}
	}

}

