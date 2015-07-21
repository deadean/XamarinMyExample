using Library.Commands;

using System;
using System.Collections.Generic;

namespace PhotoTransfer.UI.Common.Interfaces.ViewModels
{
	public interface IPagePreferencesVm
	{
		IList<IPreferenceVm> Preferences { get; set; }
		Action PostSavePreferencesAction { set; }
		AsyncCommand SavePreferencesCommand { get; }
		AsyncCommand SendLogFileCommand { get; }
	}
}
