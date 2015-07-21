using PhotoTransfer.Data.Enums;
using PhotoTransfer.Data.Interfaces.Translation;

using System.Collections.Generic;

using TranslationKeys = PhotoTransfer.Data.Constants.Language.TranslationKeys;
using English = PhotoTransfer.Data.Constants.Language.Constants.English;
using German = PhotoTransfer.Data.Constants.Language.Constants.German;
using Russian = PhotoTransfer.Data.Constants.Language.Constants.Russian;

using Xamarin.Forms;

using PhotoTransfer.UI.Data.Implementations.Translation;

using System;
using System.Linq;
using System.Reflection;

[assembly: Dependency(typeof(TranslationDictionary))]
namespace PhotoTransfer.UI.Data.Implementations.Translation
{
	public class TranslationDictionary : ITranslationDictionary
	{
		#region Fields
		
		static readonly Type modTranslationKeysType = typeof(TranslationKeys);

		Dictionary<enLanguage, Type> modConstantsTypeMappings = new Dictionary<enLanguage, Type> 
		{
			{ enLanguage.ENG, typeof(English) },
			{ enLanguage.RUS, typeof(Russian) },
			{ enLanguage.DEU, typeof(German) }
		};

		#endregion

		#region ITransaltionDictionary implementation

		public string this[string key, enLanguage lang]
		{
			get
			{
				if (!modConstantsTypeMappings.ContainsKey(lang))
					return key;

				var constantKeyField = GetConstantKeyField(key);

				if (constantKeyField == null)
					return key;

				var constantTranlsationField = GetConstantTranslationField(constantKeyField.Name, lang);

				if (constantTranlsationField == null)
					return key;

				var translation = constantTranlsationField.GetValue(null) as string;

				return translation ?? key;
			}
		}

		private FieldInfo GetConstantTranslationField(string fieldName, enLanguage lang)
		{
			if (!modConstantsTypeMappings.ContainsKey(lang))
				return null;

			return modConstantsTypeMappings[lang].GetTypeInfo().DeclaredFields.FirstOrDefault(x => x.IsStatic && x.Name == fieldName);
		}

		private static FieldInfo GetConstantKeyField(string keyValue)
		{
			return GetConstantByValue(keyValue, modTranslationKeysType.GetTypeInfo());
		}

		public static FieldInfo GetConstantByValue(object value, TypeInfo type)
		{
			return type.DeclaredFields.FirstOrDefault(x => x.IsStatic && value.Equals(x.GetValue(null)));
		}

		#endregion	
	}
}
