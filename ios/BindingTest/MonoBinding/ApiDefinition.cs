using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.ComponentModel;

namespace MonoBinding {


	[BaseType(typeof(NSObject))]
	public partial interface BindingObject {

		[Export("delegate1", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate1 { get; set; }

		[Wrap("WeakDelegate1")]
		BindingProtocol Delegate1 { get; set; }

		[Export("delegate2", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate2 { get; set; }

		[Wrap("WeakDelegate2")]
		BindingProtocol Delegate2 { get; set; }

		[Export("callDelegate1Method")]
		void CallDelegate1Method();

		[Export("callDelegate2Method")]
		void CallDelegate2Method();

		[Export("voidMethod")]
		void VoidMethod();

		[Export("stringMethod")]
		string StringMethod ();

		[Export("stringArrayMethod")]
		string[] StringArrayMethod();

		[Export("stringCategoryMethod")]
		string StringCategoryMethod ();

		[Export("stringArrayCategoryMethod")]
		string[] StringArrayCategoryMethod();
	}

	[Model, BaseType(typeof(NSObject))]
	public partial interface BindingProtocol {

		[Export("stringProtocolMethod:")]
		void StringProtocolMethod(string str);

	}


	[BaseType(typeof(UIView))]
	[Category]
	public partial interface MyUIViewExtension {

		[Export("makeBackgroundRed")]
		void MakeBackgroundRed ();
	}
}

