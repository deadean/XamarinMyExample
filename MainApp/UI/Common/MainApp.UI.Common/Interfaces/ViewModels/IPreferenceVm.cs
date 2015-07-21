using System;

namespace PhotoTransfer.UI.Common.Interfaces.ViewModels
{
	public interface IPreferenceVm
	{
		string PreferenceName { get; }
		string PreferenceValue { get; }
	}
}
