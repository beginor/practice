using System;
using NUnit.Framework;
using MonoBinding;

namespace MonoBindingTest {

	[TestFixture]
	public class DelegateTest {

		[Test]
		public void TestWeakDelegate1() {
			var target = new BindingObject();
			target.WeakDelegate1 = new MyProtocol();
			target.CallDelegate1Method();
		}

		[Test]
		public void TestDelegate1() {
			var target = new BindingObject();
			target.Delegate1 = new MyProtocol();
			target.CallDelegate1Method();
		}

		[Test]
		public void TestWeakDelegate2() {
			var target = new BindingObject();
			target.WeakDelegate2 = new MyProtocol();
			target.CallDelegate2Method();
		}

		[Test]
		public void TestDelegate2() {
			var target = new BindingObject();
			target.Delegate2 = new MyProtocol();
			target.CallDelegate2Method();
		}
	}
}
