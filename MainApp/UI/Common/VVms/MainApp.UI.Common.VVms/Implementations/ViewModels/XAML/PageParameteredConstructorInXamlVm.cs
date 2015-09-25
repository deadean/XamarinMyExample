using MainApp.UI.Common.Interfaces.ViewModels;
using PhotoTransfer.UI.Common.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Extensions;

namespace MainApp.UI.Common.VVms.Implementations.ViewModels.XAML
{
	public class PageParameteredConstructorInXamlVm : AdvancedPageViewModelBase, IPageParameteredConstructorInXamlVm
	{
	}


	public class ViewModelInXaml : AdvancedPageViewModelBase
	{
		private string mvTestParam;

		public ViewModelInXaml(string testparam)
		{
			TestParam = testparam;
		}

		public string TestParam
		{
			get
			{
				return mvTestParam;
			}

			set
			{
				mvTestParam = value;
				this.OnPropertyChanged();
			}
		}
		
	}
}
