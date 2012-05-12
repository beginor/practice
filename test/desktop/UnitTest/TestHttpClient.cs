using System;
using System.Collections.Generic;
using System.Linq;
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
				BaseAddress = new Uri("http://localhost:25422/HttpWebApp/", UriKind.Absolute)
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
			var uri = string.Format("api/categorytest/{0}", id);
			var requestTask = this._httpClient.GetAsync(uri);
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
			var request = new HttpRequestMessage<Category>(cat, formatter.SupportedMediaTypes.First(), new MediaTypeFormatter[] { formatter }) {
				Method = HttpMethod.Post,
				RequestUri = new Uri("api/categorytest", UriKind.Relative)
			};

			var requestTask = this._httpClient.SendAsync(request);
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

			var uri = string.Format("api/categorytest/{0}", cat.CategoryID);
			var formatter = new JsonMediaTypeFormatter();
			var request = new HttpRequestMessage<Category>(cat, formatter.SupportedMediaTypes.First(), new [] { formatter }) {
				RequestUri = new Uri(uri, UriKind.Relative),
				Method = HttpMethod.Put
			};

			var requestTask = this._httpClient.SendAsync(request);
			requestTask.Wait();

			var response = requestTask.Result;
			response.EnsureSuccessStatusCode();
		}

		[Test]
		public void TestDelete() {
			var uri = "api/categorytest/4";
			var requestTask = this._httpClient.DeleteAsync(uri);
			requestTask.Wait();

			var response = requestTask.Result;
			response.EnsureSuccessStatusCode();
		}
	}
}
