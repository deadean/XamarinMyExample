using MainApp.UI.Common.Interfaces.ViewModels.Xamarin1;
using PhotoTransfer.UI.Common.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Extensions;
using System.Windows.Input;
using Library.Commands;

namespace MainApp.UI.Common.VVms.Implementations.ViewModels.Xamarin1
{
	public class TapGestureRecognizerVm : AdvancedPageViewModelBase, ITapGestureRecognizerVm
	{
		private string mvText;

		public string Text
		{
			get { return mvText; }
			set { mvText = value; this.OnPropertyChanged(); }
		}

		public TapGestureRecognizerVm()
		{
			Text = DateTime.Now.ToString();
			TapCommand = new DelegateCommand(() => Text = DateTime.Now.ToString());
		}

		public ICommand TapCommand
		{
			get;
			private set;
		}
		
	}
}
