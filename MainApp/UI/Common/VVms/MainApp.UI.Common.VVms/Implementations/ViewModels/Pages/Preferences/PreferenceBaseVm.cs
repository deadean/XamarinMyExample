using Library.Types;
using Library.Extensions;

using PhotoTransfer.Common.Implementations.Extensions;
using PhotoTransfer.Data.Enums;
using PhotoTransfer.Data.Interfaces.Entities.Preferences;
using PhotoTransfer.UI.Common.Interfaces.Preferences;
using PhotoTransfer.Data.Constants.Language;

using System;
using System.Threading.Tasks;

using GalaSoft;
using GalaSoft.MvvmLight.Ioc;
using PhotoTransfer.UI.Common.Interfaces.ViewModels;

namespace PhotoTransfer.UI.Common.VVms.Implementations.ViewModels.Pages.Preferences
{
	public class PreferenceBaseVm : AdvancedViewModelBase, IPreferenceVm
	{
		#region Fields
				
		string modValue;

		#endregion

		#region Constructors
		
		public PreferenceBaseVm(IPreference preference)
		{
			PreferenceName = preference.Name;
			modValue = preference.Value;
			PreferenceType = preference.PreferenceType;
		}
		
		#endregion

		#region Properties

		public string PreferenceName
		{
			get; 
			private set;
		}

		public string PreferenceValue
		{
			get
			{
				return modValue;
			}

			set
			{
				if (modValue == value)
					return;

				modValue = value;
				this.OnPropertyChanged();
			}
		}

		public enPreferenceType PreferenceType
		{
			get;
			private set;
		}

		#endregion		
	}
}
