using System.Threading;
using Microsoft.Silverlight.Testing;
using Microsoft.Silverlight.Testing.Harness;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Net;

namespace SilverlightUnitTest {

	[TestClass]
	public class TasksTest : SilverlightTest {

		[TestMethod, Asynchronous]
		public void TestCreateTaskFromAsync() {
			WebResponse response = null;

			//this.EnqueueCallback(() => Assert.IsNotNull(response));
			//this.EnqueueTestComplete();

			new Thread(() => {
				var url = "http://zhang.gdepb.gov.cn/";
				var request = WebRequest.CreateHttp(url);
				request.Method = "GET";
				var requestTask = Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);
				requestTask.Wait();
				response = requestTask.Result;
				Assert.IsNotNull(response);
				this.EnqueueTestComplete();
			}).Start();
		}

		[TestMethod]
		public void TestFromCallback() {
			Assert.Fail();
		}
	}
}