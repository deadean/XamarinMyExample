namespace Library.Types
{
	public interface INavigableAdvancedViewModelBase : IViewModel
	{
		object NavigationParameter { set; }
		void SetNavigationHelper(INavigationHelper navigationHelper);
	}
}
