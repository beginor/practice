// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace CandySearch
{
	[Register ("CandyTableViewController")]
	partial class CandyTableViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISearchBar SearchBar { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISearchDisplayController searchDisplayController { get; set; }

		[Action ("GoToSearch:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void GoToSearch (UIBarButtonItem sender);

		void ReleaseDesignerOutlets ()
		{
			if (SearchBar != null) {
				SearchBar.Dispose ();
				SearchBar = null;
			}
			if (searchDisplayController != null) {
				searchDisplayController.Dispose ();
				searchDisplayController = null;
			}
		}
	}
}
