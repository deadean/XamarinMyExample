using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MainApp.UI.Common.Views.Implementations.Views.Xamarin1
{
	public partial class PageDataBinding : ContentPage
	{
		public PageDataBinding()
		{
			InitializeComponent();
			Example1();
			Example2();
		}

		private void Example2()
		{
			//Binding binding = new Binding() { Source = this.slider2, Path = "Value" };
			//this.label2.SetBinding(Label.OpacityProperty, binding);

			Binding binding = Binding.Create<Slider>(x => x.Value);
			binding.Source = slider2;
			this.label2.SetBinding(Label.OpacityProperty, binding);
		}

		private void Example1()
		{
			this.label1.BindingContext = this.slider1;
			this.label1.SetBinding(Label.OpacityProperty, "Value");
		}
	}
}
