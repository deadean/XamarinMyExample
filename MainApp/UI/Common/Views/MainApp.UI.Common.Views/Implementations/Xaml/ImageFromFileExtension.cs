using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MainApp.UI.Common.Views.Implementations.Xaml
{
	[ContentProperty("Source")]
	public class ImageFromFileExtension:IMarkupExtension
	{
		public string Source { get; set; }
		public object ProvideValue(IServiceProvider serviceProvider)
		{
			if (Source == null)
				return null;

			return ImageSource.FromFile(Source);
		}
	}
}
