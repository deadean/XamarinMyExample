using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MainApp.UI.Common.Views.Controls.Implementations.Labels
{
	public class AltLabel:Label
	{
		public static readonly BindableProperty PointSizeProperty =
			BindableProperty.Create
			(
				propertyName: "PointSize",
				returnType: typeof(double),
				declaringType: typeof(AltLabel),
				defaultValue: 8.0,
				defaultBindingMode: BindingMode.TwoWay,
				validateValue: (bindable, obj) => { return true; },
				propertyChanged: OnPointSizePropertyChanged,
				propertyChanging: null,
				coerceValue: null,
				defaultValueCreator: null
			);

		public static readonly BindableProperty PointSize1Property =
			BindableProperty.Create<AltLabel, double>(
			label => label.PointSize, 8, 
			propertyChanged: (b, o, n) => { ((AltLabel)b).FontSize = (Device.OnPlatform(160, 160, 240) * (double)n) / 72; });

		public double PointSize { set { SetValue(PointSizeProperty, value); } get { return (double)GetValue(PointSizeProperty); } }

		static void OnPointSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			AltLabel label = (AltLabel)bindable;

			label.FontSize = (Device.OnPlatform(160, 160, 240) * (double)newValue) / 72;
		}

		public static readonly BindablePropertyKey WordCountKey =
			BindableProperty.CreateReadOnly<AltLabel, int>(
			label => label.WordCount, 0,
			propertyChanged: (b, o, n) => {  });

		public static readonly BindableProperty WordCountProperty = WordCountKey.BindableProperty; 

		public int WordCount { private set { SetValue(WordCountKey, value); } get { return (int)GetValue(WordCountProperty); } } 

		public AltLabel()
		{
			PropertyChanged += AltLabel_PropertyChanged;
		}

		void AltLabel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Text")
			{
				WordCount = String.IsNullOrWhiteSpace(Text) ? 0 : Text.Split(' ', '-', '\u2014').Length;
			}
		}
	}
}
