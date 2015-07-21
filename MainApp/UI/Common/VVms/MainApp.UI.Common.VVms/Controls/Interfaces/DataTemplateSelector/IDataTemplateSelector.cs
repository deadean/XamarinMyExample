
using Xamarin.Forms;

namespace PhotoTransfer.UI.Common.VVms.Controls.Interfaces.DataTemplateSelector
{
	public interface IDataTemplateSelector<T> : IDataTemplateSelector
	{
		DataTemplate SelectTemplate(T item, BindableObject container);
	}

	public interface IDataTemplateSelector
	{
		DataTemplate SelectTemplate(object item, BindableObject container);
	}
}
