using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MainApp.UI.Common.Views.Controls.Implementations.CheckBoxes
{
	public partial class CustomCheckBox : ContentView
	{
		public CustomCheckBox()
		{
			InitializeComponent();
		}

		#region Bindable Properties

		public static readonly BindableProperty TextProperty = BindableProperty.Create<CustomCheckBox, string>(
			checkbox => checkbox.Text, null,
			propertyChanged: (bindable, oldValue, newValue) => { ((CustomCheckBox)bindable).textLabel.Text = (string)newValue; });

		public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create<CustomCheckBox, bool>(
			checkbox => checkbox.IsChecked,
			false,
			propertyChanged: (bindable, oldValue, newValue) =>
			{
				// Set the graphic.
				CustomCheckBox checkbox = (CustomCheckBox)bindable;
				checkbox.boxLabel.Text = newValue ? "\u2611" : "\u2610";
				// Fire the event.
				EventHandler<bool> eventHandler = checkbox.CheckedChanged;
				if (eventHandler != null)
				{
					eventHandler(checkbox, newValue);
				}
			});

		#endregion

		public event EventHandler<bool> CheckedChanged;

		public string Text { set { SetValue(TextProperty, value); } get { return (string)GetValue(TextProperty); } }
		public bool IsChecked { set { SetValue(IsCheckedProperty, value); } get { return (bool)GetValue(IsCheckedProperty); } }
		void OnCheckBoxTapped(object sender, EventArgs args)
		{         
			IsChecked = !IsChecked;     
		} 
	}
}
