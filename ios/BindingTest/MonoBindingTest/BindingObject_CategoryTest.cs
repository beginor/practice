using System;
using NUnit.Framework;
using MonoBinding;

namespace MonoBindingTest {

	[TestFixture]
	public class BindingObject_CategoryTest {

		[Test]
		public void TestStringCategoryMethod() {
			var bindObj = new BindingObject ();
			//var catObj = new Extension ();

			var strCatResult = bindObj.StringCategoryMethod();
			Assert.IsNotNull (strCatResult);
			Assert.AreEqual ("return of string category method", strCatResult);
		}

		[Test]
		public void TestStringArrayCategoryMethod() {
			var bindObj = new BindingObject ();
			//var catObj = new Extension ();

			var strArrCatResult = bindObj.StringArrayCategoryMethod ();
			Assert.AreEqual (1, strArrCatResult.Length);
			Assert.AreEqual ("return of string array category method", strArrCatResult [0]);
		}
	}
	
}
