namespace PhotoTransfer.Common.Interfaces.Selector
{
	public interface ISelector<T, TItem, TContainer>
		where TItem : class
	{
		TItem SelectItem(T item);
		TItem SelectItem(T item, TContainer container);
	}
}
