using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.Interfaces.Dialogs
{
	public interface IDialogService
	{
		Task<T> ChooseOneFromAsync<T>(string title, Dictionary<string, T> headeredValues, bool isNeedTranslate = true);
	}
}
