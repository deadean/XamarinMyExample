using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UsingBindingLibraryToShowCustomControl.iOS.Renderers;
using UIKit;
using System.Drawing;
using UsingBindingLibraryToShowCustomControl;
using XMBindingLibrarySample;
using CoreGraphics;

[assembly: ExportRenderer(typeof(Control), typeof(PageRenderer1))]

namespace UsingBindingLibraryToShowCustomControl.iOS.Renderers
{
	public class PageRenderer1 : ViewRenderer<Control, XMCustomView>
	{
		XMCustomView _CustomView;

		public PageRenderer1 ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<UsingBindingLibraryToShowCustomControl.Control> e)
		{
			base.OnElementChanged (e);

//			_CustomView = new XMCustomView();
//			_CustomView.Name = @"Anuj";
//			_CustomView.Frame = new CGRect(10, 25, 300, 300);

			// The instance method we bound.
//			_CustomView.CustomizeViewWithText(string.Format(@"Yo {0}, I hurd you like bindings! MonoTouch makes it super easy with BTOUCH. Try it out!",
//				_CustomView.Name ?? "Dawg"));

			_CustomView = new XMCustomView ();
			_CustomView.Frame = new CGRect(10, 25, 300, 300);
			_CustomView.StartMicrophone ("");
			
			this.SetNativeControl(_CustomView);
		}
	}
}

