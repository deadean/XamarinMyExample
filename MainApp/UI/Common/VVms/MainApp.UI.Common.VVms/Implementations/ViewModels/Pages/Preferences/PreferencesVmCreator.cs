using PhotoTransfer.Data.Enums;
using PhotoTransfer.Data.Interfaces.Entities.Preferences;

using System.Threading.Tasks;

namespace PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.Pages.Preferences
{
	public static class PreferencesVmCreator
	{
		public static async Task<PreferenceBaseVm> CreatePreference(IPreference preference)
		{
			switch (preference.PreferenceType)
			{
				case enPreferenceType.Text:
					return new TextPreferenceVm(preference);
				case enPreferenceType.Logical:
					break;
				case enPreferenceType.Number:
					break;
				case enPreferenceType.List:					
					return await ListPreferenceVm.CreateAsync(preference);
			}

			return null;
		}
	}
}
