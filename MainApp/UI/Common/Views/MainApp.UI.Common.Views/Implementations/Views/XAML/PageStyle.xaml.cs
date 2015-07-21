using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MainApp.UI.Common.Views.Implementations.Views.XAML
{
	public partial class PageStyle : ContentPage
	{
		public PageStyle()
		{
			InitializeComponent();
			Setter setter = new Setter(){Property = Button.FontSizeProperty, Value= Device.GetNamedSize(NamedSize.Large, typeof(Button))};
			Style style = new Style(typeof(Button)) { Setters = { setter } };
			
			Resources.Add("styleTxtColor1", style);

			button.Style = (Style)Resources["styleTxtColor1"];
		}

		public void OnClick1(object sender, EventArgs e)
		{
			Resources["buttonStyleDynamic"] = Resources["Style1"];
		}

		public void OnClick2(object sender, EventArgs e)
		{
			Resources["buttonStyleDynamic"] = Resources["Style2"];
		}
	}
}
