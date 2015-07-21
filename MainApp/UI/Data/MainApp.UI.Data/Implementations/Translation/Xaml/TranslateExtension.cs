using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PhotoTransfer.Data.Enums;
using PhotoTransfer.Data.Interfaces.Translation;
using PhotoTransfer.UI.Common.Interfaces.Preferences;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotoTransfer.UI.Data.Implementations.Translation.Xaml
{
	public class TranslateExtension : BindableObject, IMarkupExtension
	{
		#region Fields

		BindableObject modTarget;
		ITranslator modTranslator = ServiceLocator.Current.GetInstance<ITranslator>();

		#endregion

		#region Properties

		public string Key { get; set; }

		public BindableProperty TargetProperty { get; set; }

		#endregion

		#region IMarkupExtension implementation

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			TryRegisterTranslateTarget(serviceProvider);

			if (string.IsNullOrEmpty(Key))
				return null;

			return modTranslator.Translate(Key);
		}

		public void TryRegisterTranslateTarget(IServiceProvider serviceProvider)
		{
			if (modTarget != null)
				return;

			if (serviceProvider == null)
				return;

			var pvt = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;

			if (pvt == null)
				return;

			modTarget = pvt.TargetObject as BindableObject;
			modTranslator.LanguageChanged += OnLanguageChanged;	
		}

		void OnLanguageChanged(object sender, EventArgs e)
		{
			if (modTarget == null || TargetProperty == null)
				return;

			modTarget.SetValue(TargetProperty, ProvideValue(default(IServiceProvider)));
		}		

		#endregion
	}
}
