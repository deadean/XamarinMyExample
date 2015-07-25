using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MainApp.UI.Common.Views.Implementations.Views.Controls
{
	public partial class PageToolBars : ContentPage
	{
		public PageToolBars()
		{
			InitializeComponent();
			if (Device.OS == TargetPlatform.Windows)
			{
				toolbar1.Icon = (FileImageSource)ImageSource.FromFile("Assets\\edit.png");
				toolbar2.Icon = (FileImageSource)ImageSource.FromFile("Assets\\feature.search.png");
				toolbar3.Icon = (FileImageSource)ImageSource.FromFile("Assets\\refresh.png");
			}
		}

		public void OnToolbarItemClicked(object sender, EventArgs args)
		{
			ToolbarItem toolbarItem = (ToolbarItem)sender;
			label.Text = "ToolbarItem '" + toolbarItem.Text + "' clicked";
		}
	}
}
