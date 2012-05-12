using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
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
				BaseAddress = new Uri("http://localhost/HttpWebApp/", UriKind.Absolute)
			};
		}

		[Test]
		public void TestGetAll() {
			var requestTask = this._httpClient.GetAsync("api/categorytest");
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
			var requestTask = this._httpClient.GetAsync("api/categorytest/" + id);
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
			var request = new HttpRequestMessage<Category>(cat, HttpMethod.Post, new Uri(this._httpClient.BaseAddress, "api/categorytest"), new MediaTypeFormatter[] { formatter });

			var readContentTask = request.Content.ReadAsStringAsync();
			readContentTask.Wait();
			var strContent = new StringContent(readContentTask.Result, Encoding.UTF8, formatter.SupportedMediaTypes.First().MediaType);
			
			var requestTask = this._httpClient.PostAsync("api/categorytest", strContent);
			//var requestTask = this._httpClient.SendAsync(request);
			requestTask.Wait();

			var response = requestTask.Result;
			response.EnsureSuccessStatusCode();

			var task = response.Content.ReadAsAsync<Category>();
			task.Wait();
			Assert.Greater(task.Result.CategoryID, 1);
		}

		[Test]
		public void TestPut() {
			var cat = new Category {
				CategoryID = 4,
				CategoryName = "My category",
				Description = "My category description"
			};
			var formatter = new JsonMediaTypeFormatter();
			var request = new HttpRequestMessage<Category>(cat);

			var readContentTask = request.Content.ReadAsStringAsync();
			readContentTask.Wait();
			var strContent = new StringContent(readContentTask.Result, Encoding.UTF8, formatter.SupportedMediaTypes.First().MediaType);

			var requestTask = this._httpClient.PutAsync("api/categorytest/" + cat.CategoryID, strContent);
			requestTask.Wait();

			var response = requestTask.Result;
			response.EnsureSuccessStatusCode();
		}
	}
}
