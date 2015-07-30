using Library.Commands;
using PhotoTransfer.UI.Common.Bases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Extensions;

namespace MainApp.UI.Common.VVms.Implementations.ViewModels.Controls
{
	public class SearchResultsItem
	{
		public string Value { get; set; }
	}
	public class StandartControlsVm:AdvancedPageViewModelBase
	{
		
		private IList<string> modValues;
		public ICommand SearchCommand { get;private set; }
		public StandartControlsVm()
		{
			SearchCommand = new DelegateCommand(OnSearchCommand);
			modValues = new List<string>();
			for (int i = 0; i < 1000; i++)
			{
				modValues.Add(i.ToString());
			}

			SearchResults = new ObservableCollection<SearchResultsItem>();
		}

		private void OnSearchCommand()
		{
			if (String.IsNullOrWhiteSpace(SearchText))
				return;


			SearchResults.Clear();
			foreach (var item in modValues.Where(x => x.Contains(SearchText)))
			{
				SearchResults.Add(new SearchResultsItem() { Value = item});
			}
		}


		string mvSearchText;
		public string SearchText
		{
			get
			{
				return mvSearchText;
			}

			set
			{
				mvSearchText = value;
				this.OnPropertyChanged();
			}
		}

		public ObservableCollection<SearchResultsItem> SearchResults { get; set; }
		
	}
}
