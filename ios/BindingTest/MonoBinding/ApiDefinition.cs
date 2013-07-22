using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MonoBinding {


	[BaseType(typeof(NSObject))]
	public partial interface BindingObject {

		[Export("voidMethod")]
		void VoidMethod();

		[Export("stringMethod")]
		string StringMethod ();

		[Export("stringArrayMethod")]
		string[] StringArrayMethod();

	}

	[Category]
	[BaseType(typeof(BindingObject))]
	public partial interface Extension {

		[Export("stringCategoryMethod")]
		string StringCategoryMethod ();

		[Export("stringArrayCategoryMethod")]
		string[] StringArrayCategoryMethod();
	}

	[BaseType(typeof(UIView))]
	[Category]
	public partial interface MyUIViewExtension {

		[Export("makeBackgroundRed")]
		void MakeBackgroundRed ();
	}
}

