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
				var source = new TaskCompletionSource<string>();
				var c = new WebClient();
				c.DownloadStringCompleted += (sender, args) => {
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
				c.DownloadStringAsync(new Uri(UrlToTest, UriKind.Absolute), null);

				source.Task.Wait();
				Assert.IsNotNull(source.Task.Result);

				this.EnqueueTestComplete();
			}).Start();
		}

		[TestMethod, Asynchronous]
		public void TestCallbackAsyncModel() {
			
		}
	}
}