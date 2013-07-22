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

	[TestFixture]
	public class BindingObject_CategoryTest {

		[Test]
		public void TestStringCategoryMethod() {
			//var bindObj = new BindingObject ();
			var catObj = new Extension ();

			var strCatResult = catObj.StringCategoryMethod();
			Assert.IsNotNull (strCatResult);
			Assert.AreEqual ("return of string category method", strCatResult);
		}

		[Test]
		public void TestStringArrayCategoryMethod() {
			//var bindObj = new BindingObject ();
			var catObj = new Extension ();

			var strArrCatResult = catObj.StringArrayCategoryMethod ();
			Assert.AreEqual (1, strArrCatResult.Length);
			Assert.AreEqual ("return of string array category method", strArrCatResult [0]);
		}
	}
}
