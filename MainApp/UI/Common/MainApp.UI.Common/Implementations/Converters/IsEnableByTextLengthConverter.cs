using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MainApp.UI.Common
{
	public sealed class IsEnableByTextLengthConverter:IValueConverter
	{
		public int MaxLength { get; set; }

		public IsEnableByTextLengthConverter()
		{
			MaxLength = 5;
		}

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value == null)
				return false;

			return ((string)value).Length <= MaxLength;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
