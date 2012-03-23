using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using HttpWebApp.Models;
using NUnit.Framework;
using System.Net.Http;

namespace UnitTest {

	[TestFixture]
	public class TestHttpClient {

		[Test]
		public void TestRequest() {
			var client = new HttpClient {
				BaseAddress = new Uri("http://localhost:25422/", UriKind.Absolute)
			};
			var requestTask = client.GetAsync("api/categories");
			requestTask.Wait();
			var responseMessage = requestTask.Result;
			responseMessage.EnsureSuccessStatusCode();

			var readTask = responseMessage.Content.ReadAsAsync<IEnumerable<Category>>();
			readTask.Wait();

			var result = readTask.Result;

			Assert.IsTrue(result.Any());

			var task = client.GetAsync("api/categories/1").ContinueWith(t => t.Result.Content.ReadAsAsync<Category>());
			task.Wait();
			Assert.IsNotNull(task.Result);
			Assert.AreEqual(1, task.Result.Result.CategoryID);
		}
	}
}
