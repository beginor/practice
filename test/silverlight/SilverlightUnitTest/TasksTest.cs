using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SilverlightUnitTest {

	[TestClass]
	public class TasksTest : SilverlightTest {
		
		[TestMethod]
		public void TestCreateTaskFromAsync() {
			Assert.IsTrue(true);
		}

		[TestMethod]
		public void TestFromCallback() {
			Assert.Fail();
		}
	}
}