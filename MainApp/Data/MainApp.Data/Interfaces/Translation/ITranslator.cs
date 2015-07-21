using PhotoTransfer.Data.Enums;
using System;
namespace PhotoTransfer.Data.Interfaces.Translation
{
	public interface ITranslator
	{
		event EventHandler LanguageChanged;
		enLanguage Language { get; set; }		
		string Translate(string key);
	}
}
