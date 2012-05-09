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
				BaseAddress = new Uri("http://localhost:25422/api/", UriKind.Absolute)
			};
			var requestTask = client.GetAsync("categorytest");
			requestTask.Wait();
			var responseMessage = requestTask.Result;
			responseMessage.EnsureSuccessStatusCode();

			var readTask = responseMessage.Content.ReadAsAsync<IEnumerable<Category>>();
			readTask.Wait();

			var result = readTask.Result;

			Assert.IsTrue(result.Any());
		}
	}
}
