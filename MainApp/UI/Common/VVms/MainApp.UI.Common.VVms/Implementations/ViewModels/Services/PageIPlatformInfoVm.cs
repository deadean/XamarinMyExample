using MainApp.Services.Interfaces.PlatformInfo;
using MainApp.UI.Common.Interfaces.ViewModels.Services;
using PhotoTransfer.UI.Common.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Library.Extensions;
using Microsoft.Practices.ServiceLocation;

namespace MainApp.UI.Common.VVms.Implementations.ViewModels.Services
{
	public class PageIPlatformInfoVm : AdvancedPageViewModelBase, IPageIPlatformInfoVm
	{

		#region Fields

		#endregion

		#region Properties


		string mvModel;

		public string Model
		{
			get
			{
				return mvModel;
			}

			set
			{
				mvModel = value;
				this.OnPropertyChanged();
			}
		}


		string mvVersion;

		public string Version
		{
			get
			{
				return mvVersion;
			}

			set
			{
				mvVersion = value;
				this.OnPropertyChanged();
			}
		}
		
		

		#endregion

		#region Ctor

		public PageIPlatformInfoVm()
		{
			IPlatformInfo platformInfo = ServiceLocator.Current.GetInstance<IPlatformInfo>();
			Model= platformInfo.GetModel();
			Version= platformInfo.GetVersion();
		}

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion
	}
}
