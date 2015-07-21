using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotoTransfer.UI.Common.Views.Implementations.Xaml
{
	[ContentProperty("Property")]
	public class GetPropertyValueExtension : IMarkupExtension
	{
		public object Source { get; set; }

		public string Property { get; set; }

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			if (Source == null || string.IsNullOrEmpty(Property))
				return null;

			var prop = Source.GetType().GetTypeInfo().GetDeclaredProperty(Property);

			if (prop == null)
				return null;

			return prop.GetValue(Source);
		}
	}
}
