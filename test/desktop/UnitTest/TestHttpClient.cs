using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using HttpWebApp.Models;
using NUnit.Framework;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace UnitTest {

	[TestFixture]
	public class TestHttpClient {

		private HttpClient _httpClient;

		[SetUp]
		public void SetUp() {
			this._httpClient = new HttpClient {
				BaseAddress = new Uri("http://localhost:25422/api/", UriKind.Absolute)
			};
		}

		[Test]
		public void TestGetAll() {
			var requestTask = this._httpClient.GetAsync("categorytest");
			requestTask.Wait();
			var responseMessage = requestTask.Result;
			responseMessage.EnsureSuccessStatusCode();

			var readTask = responseMessage.Content.ReadAsAsync<IEnumerable<Category>>();
			readTask.Wait();

			var result = readTask.Result;

			Assert.IsTrue(result.Any());
		}

		[Test]
		public void TestGetById() {
			const int id = 1;
			var requestTask = this._httpClient.GetAsync("categorytest/" + id);
			requestTask.Wait();
			var responseMsg = requestTask.Result;
			responseMsg.EnsureSuccessStatusCode();

			var readTask = responseMsg.Content.ReadAsAsync<Category>();
			readTask.Wait();

			var result = readTask.Result;

			Assert.AreEqual(id, result.CategoryID);
		}

		[Test]
		public void TestPost() {
			var cat = new Category {
				CategoryName = "My category",
				Description = "My category description"
			};
			var formatter = new JsonMediaTypeFormatter();
			var mediaType = new MediaTypeHeaderValue("application/json");
			var requestMsg = new HttpRequestMessage<Category>(cat, mediaType, new MediaTypeFormatter[] { formatter } );
			
			var requestTask = this._httpClient.PostAsync("categorytest", requestMsg.Content);
			requestTask.Wait();
			var responseMessage = requestTask.Result;
			responseMessage.EnsureSuccessStatusCode();
		}
	}
}
