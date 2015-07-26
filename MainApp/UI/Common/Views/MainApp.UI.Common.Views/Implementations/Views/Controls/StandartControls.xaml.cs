using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MainApp.UI.Common.Views.Implementations.Views.Controls
{
	public partial class StandartControls : ContentPage
	{
		public StandartControls()
		{
			InitializeComponent();
		}

		public void ValueChanged(object obj, EventArgs args)
		{
			boxview.Color = Color.FromRgb((int)slider1.Value, (int)slider2.Value, (int)slider3.Value);
		}

		public void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
		{
			AbsoluteLayout.SetLayoutBounds(label1, new Rectangle(args.NewValue, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			AbsoluteLayout.SetLayoutBounds(label2, new Rectangle(args.NewValue, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

			label1.Opacity = 1 - args.NewValue;
			label2.Opacity = args.NewValue; 
		}
	}
}
