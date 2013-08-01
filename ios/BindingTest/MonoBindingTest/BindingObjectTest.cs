using System;
using NUnit.Framework;
using MonoBinding;

namespace MonoBindingTest {

	[TestFixture]
	public class BindingObjectTest {

		[Test]
		public void TestStringMethod () {
			var targetObj = new BindingObject ();
			var stringResult = targetObj.StringMethod ();
			Assert.IsNotNull (stringResult);
			Assert.AreEqual ("return of string method.", stringResult);
		}

		[Test]
		public void TestStringArrayMethod() {
			var targetObj = new BindingObject ();
			var arrayResult = targetObj.StringArrayMethod ();
			Assert.NotNull (arrayResult);
			Assert.AreEqual (1, arrayResult.Length);
			Assert.AreEqual ("return of string array method.", arrayResult [0]);
		}
	}

}
