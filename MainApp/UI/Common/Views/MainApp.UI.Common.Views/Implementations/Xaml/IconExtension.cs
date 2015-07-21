using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PhotoTransfer.UI.Common.Interfaces.Image;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotoTransfer.UI.Common.Views.Implementations.Xaml
{	
	[ContentProperty("IconName")]
	public class IconExtension : IMarkupExtension
	{
		private readonly IIconsLoader modIconsLoader = ServiceLocator.Current.GetInstance<IIconsLoader>();

		public string IconName { get; set; }

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			return ImageSource.FromFile(modIconsLoader.GetIconPath(IconName));
		}
	}
}
