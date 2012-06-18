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
			var request = new HttpRequestMessage(HttpMethod.Post, "api/categorytest") {
				Content = new ObjectContent<Category>(cat, new JsonMediaTypeFormatter())
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

			var request = new HttpRequestMessage(HttpMethod.Put, string.Format("api/categorytest/{0}", cat.CategoryID)) {
				Content = new ObjectContent<Category>(cat, new JsonMediaTypeFormatter())
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

		[Test]
		public void TestPostMessage() {
			var content = new Dictionary<string, string> {
				{ "username", "zhang" },
				{ "password", "zhimin" },
				{ "savepass", "true" }
			};
			var request = new HttpRequestMessage(HttpMethod.Post, "http://zhang.gdepb.gov.cn/website/test.mvc/login") {
				Content = new FormUrlEncodedContent(content)
			};

			var client = new HttpClient();
			var requestTask = client.SendAsync(request);
			requestTask.Wait();

			var response = requestTask.Result;
			Assert.True(response.IsSuccessStatusCode);

			var readTask = response.Content.ReadAsStringAsync();
			readTask.Wait();

			Assert.IsNotNull(readTask.Result);
		}
	}
}
