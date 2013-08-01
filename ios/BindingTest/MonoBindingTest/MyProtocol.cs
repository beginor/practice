using System;

namespace MonoBindingTest {

	public class MyProtocol : MonoBinding.BindingProtocol {

		public override void StringProtocolMethod(string str) {
			Console.WriteLine("str = {0}", str);
		}
	}
}

