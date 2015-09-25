using Library.Types;
using PhotoTransfer.UI.Common.Bases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.UI.Common.VVms.Implementations.ViewModels.Controls
{
	public class Item
	{
		public string Name { get; set; }
	}
	public class PageCollectionViewsVm:AdvancedPageViewModelBase
	{

		#region Services

		#endregion

		#region Fields

		#endregion

		#region Properties

		public ObservableCollection<string> Items { get; set; }
		public ObservableCollection<Item> Items1 { get; set; }

		#endregion

		#region Ctor

		public PageCollectionViewsVm()
		{
			Items = new ObservableCollection<string>();
			Items1 = new ObservableCollection<Item>();
			for (int i = 0; i < 10; i++)
			{
				Items.Add(i.ToString());
				Items1.Add(new Item() { Name = i.ToString() });
			}
		}

		#endregion

		#region Commands

		#endregion

		#region Commands Execute Handlers

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion
	}
}
