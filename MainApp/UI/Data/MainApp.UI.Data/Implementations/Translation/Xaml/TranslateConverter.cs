using GalaSoft.MvvmLight.Ioc;

using PhotoTransfer.Common.Implementations.Extensions;
using PhotoTransfer.Data.Interfaces.Translation;

using System;
using System.Linq;
using System.Globalization;

using Xamarin.Forms;
using Microsoft.Practices.ServiceLocation;

namespace PhotoTransfer.UI.Data.Implementations.Translation.Xaml
{
	public class TranslateConverter : IValueConverter
	{
		ITranslator modTranslator = ServiceLocator.Current.GetInstance<ITranslator>();

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return modTranslator.Translate(value.ToString());
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}

		public Func<object, string> ConverterFunction
		{
			get
			{
				return x => Convert(x, null, null, CultureInfo.CurrentCulture).ToString();
			}
		}
	}
}
