using System;
using System.Threading;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Net;

namespace SilverlightUnitTest {

	[TestClass]
	public class TasksTest : SilverlightTest {

		private const string UrlToTest = "http://zhang.gdepb.gov.cn/";

		[TestMethod, Asynchronous]
		public void TestAsyncProgramModel() {
			new Thread(() => {
				var request = WebRequest.CreateHttp(UrlToTest);
				request.Method = "GET";
				var requestTask = Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);
				requestTask.Wait();
				var response = requestTask.Result;
				Assert.IsNotNull(response);
				this.EnqueueTestComplete();
			}).Start();
		}

		[TestMethod, Asynchronous]
		public void TestEventAsyncPattern() {
			new Thread(() => {
				var webClient = new WebClient();
				var source = new TaskCompletionSource<string>();
				webClient.DownloadStringCompleted += (sender, args) => {
					if (args.Cancelled) {
						source.SetCanceled();
						return;
					}
					if (args.Error != null) {
						source.SetException(args.Error);
						return;
					}
					source.SetResult(args.Result);
				};
				webClient.DownloadStringAsync(new Uri(UrlToTest, UriKind.Absolute), null);

				source.Task.Wait();
				var result = source.Task.Result;
				Assert.IsNotNull(result);

				this.EnqueueTestComplete();
			}).Start();
		}

		[TestMethod, Asynchronous]
		public void TestCallbackAsyncModel() {
			var source = new TaskCompletionSource<int>();
			Action<int> callback = i => source.SetResult(i);
			AddAsync(1, 2, callback);
			source.Task.Wait();
			var result = source.Task.Result;
			Assert.AreEqual(1 + 2, result);
			this.TestComplete();
		}

		private static void AddAsync(int a, int b, Action<int> callback) {
			new Thread(() => {
				Thread.Sleep(2000);
				if (callback != null) {
					var result = a + b;
					callback(result);
				}
			}).Start();
		}
	}
}