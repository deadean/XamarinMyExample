using PhotoTransfer.Data.Enums;

using System.Collections.Generic;

namespace PhotoTransfer.Data.Interfaces.Translation
{
	public interface ITranslationDictionary
	{
		string this[string key, enLanguage lang] { get; }
	}
}
