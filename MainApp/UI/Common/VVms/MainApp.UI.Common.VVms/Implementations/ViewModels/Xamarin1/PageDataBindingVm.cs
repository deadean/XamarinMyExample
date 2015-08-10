using PhotoTransfer.UI.Common.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MainApp.UI.Common.VVms.Implementations.ViewModels.Xamarin1
{
	public class PageDataBindingVm:AdvancedPageViewModelBase
	{
		private bool mvInputText;

		[TypeConverter(typeof(IsEnableByTextLengthConverter))]
		public bool InputText
		{
			get
			{
				return mvInputText;
			}

			set
			{
				mvInputText = value;
				this.RaisePropertyChanged("InputText");
			}
		}
		
	}
}
