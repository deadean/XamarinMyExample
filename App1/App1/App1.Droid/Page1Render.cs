using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using App1.Droid;
using App1;

[assembly: ExportRenderer(typeof(View1), typeof(GridView))]

namespace App1.Droid
{
	public class Page1Render : ViewRenderer<View1, GridView>
	{
		public Page1Render()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<View1> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement != null || this.Element == null)
				return;


			GridView grd = new GridView(Forms.Context);
			grd.SetColumnWidth(100);
			grd.StretchMode = StretchMode.StretchColumnWidth;
			grd.SetGravity(GravityFlags.Center);
			grd.Adapter = new ImageAdapter(Forms.Context);
			grd.ItemClick += (sender, args) => Toast.MakeText(this.Context, args.Position.ToString(), ToastLength.Short).Show();

			SetNativeControl(grd);
		}

		//protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		//{
		//	base.OnElementChanged(e);

		//	GridView grd = new GridView(this.Context);
		//	grd.SetColumnWidth(100);
		//	grd.StretchMode = StretchMode.StretchColumnWidth;
		//	grd.SetGravity(GravityFlags.Center);
		//	grd.Adapter = new ImageAdapter(this.Context);
		//	grd.ItemClick += (sender, args) => Toast.MakeText(this.Context, args.Position.ToString(), ToastLength.Short).Show();

		//	this.AddView(grd, ViewGroup.LayoutParams.FillParent);
		//}
	}
}