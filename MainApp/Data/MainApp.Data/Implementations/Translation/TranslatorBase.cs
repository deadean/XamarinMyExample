using PhotoTransfer.Data.Enums;
using PhotoTransfer.Data.Interfaces.Translation;
using System;

namespace PhotoTransfer.Data.Implementations.Translation
{
	public class TranslatorBase : ITranslator
	{
		#region Events

		public event EventHandler LanguageChanged;

		#endregion

		#region Fields

		ITranslationDictionary modTranslationDictionary;
		enLanguage modLanguage;

		#endregion

		#region Constructor
	
		public TranslatorBase(ITranslationDictionary dictionary)
		{
			modTranslationDictionary = dictionary;			
		}

		#endregion

		#region Properties

		public enLanguage Language 
		{
			get
			{
				return modLanguage;
			}

			set
			{
				if (modLanguage == value)
					return;

				modLanguage = value;
				RaiseLanguageChanged();
			}
		}

		#endregion

		#region Pulbic methods

		public string Translate(string key)
		{			
			return modTranslationDictionary[key, Language];
		}

		#endregion

		#region Private methods

		private void RaiseLanguageChanged()
		{ 
			var handler = LanguageChanged;

			if (handler == null)
				return;

			handler(this, EventArgs.Empty);
		}

		#endregion
	}
}
