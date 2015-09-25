using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MainApp.UI.Common.Views.Implementations.Views.Controls
{
	public partial class PageCollectionViews : ContentPage
	{
		public PageCollectionViews()
		{
			InitializeComponent();

			DataTemplate dataTemplate = new DataTemplate(typeof(TextCell));
			dataTemplate.SetBinding(TextCell.TextProperty, "Name");
			dataTemplate.SetBinding(TextCell.DetailProperty, new Binding() { Path = "Name", StringFormat = "The number is {0} " });

			listView1.ItemTemplate = dataTemplate;
		}
	}
}
