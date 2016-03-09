// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MPMediaPickerControlleriOSExample
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnPlay { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnSelect { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnStop { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnPlay != null) {
				btnPlay.Dispose ();
				btnPlay = null;
			}
			if (btnSelect != null) {
				btnSelect.Dispose ();
				btnSelect = null;
			}
			if (btnStop != null) {
				btnStop.Dispose ();
				btnStop = null;
			}
		}
	}
}
