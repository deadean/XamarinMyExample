using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Types
{
	public interface INavigationHelper
	{
		RelayCommand GoBackCommand { get; set; }
	}
}
