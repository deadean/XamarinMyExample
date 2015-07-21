using GalaSoft.MvvmLight.Ioc;

using PhotoTransfer.Common.Implementations.Extensions;
using PhotoTransfer.Data.Enums;
using PhotoTransfer.Data.Implementations.Translation;
using PhotoTransfer.Data.Interfaces.Translation;
using PhotoTransfer.UI.Common.Interfaces.Preferences;
using PhotoTransfer.UI.Data.Implementations.Translation;
using PhotoTransfer.Data.Constants.Language;

using System;

using Xamarin.Forms;
using Microsoft.Practices.ServiceLocation;

[assembly: Dependency(typeof(Translator))]
namespace PhotoTransfer.UI.Data.Implementations.Translation
{
	public class Translator : TranslatorBase
	{	
		public Translator() : base(DependencyService.Get<ITranslationDictionary>())
		{
			Init();
		}

		[PreferredConstructor]
		public Translator(ITranslationDictionary dictionary) : base(dictionary)
		{
			Init();
		}

		public void Init()
		{
			ServiceLocator.Current.GetInstance<IPreferencesService>().PreferenceChanged += Translator_PreferenceChanged;
		}

		void Translator_PreferenceChanged(object sender, IPreferenceChangedEventArgs e)
		{
			switch (e.PreferenceName)
			{
				case TranslationKeys.LANGUAGE:
					Language = e.WithType<IPreferenceChangedEventArgs<enLanguage>>().Value;
					break;
			}
		}
	}
}
