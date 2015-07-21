using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhotoTransfer.UI.Common.VVms.Controls.Implementations
{
	public partial class ComboBox<T> : Picker
	{
		#region Bindable propeties

		private static readonly BindableProperty ItemsSourceProperty = 
			BindableProperty.Create<ComboBox<T>, IList<T>>(
				x => x.ItemsSource, 
				null, 
				BindingMode.TwoWay, 
				propertyChanged: OnItemsSourceChanged);
		
		public static readonly BindableProperty SelectedItemProperty =
			BindableProperty.Create<ComboBox<T>, T>(
			x => x.SelectedItem, 
			default(T), 
			propertyChanged : OnSelectedItemChanged);


		public static readonly BindableProperty ItemHeaderPathProperty =
			BindableProperty.Create<ComboBox<T>, string>(x => x.ItemHeaderPath, 
			default(string),
			propertyChanged : ItemHeaderPathPropertyChanged);


		public static readonly BindableProperty TextProperty =
			BindableProperty.Create<ComboBox<T>, string>(x => x.Text, default(string));

		public string Text
		{
			get
			{
				return (string)GetValue(TextProperty);
			}

			set
			{
				SetValue(TextProperty, value);
			}
		}

		public string ItemHeaderPath
		{
			get
			{
				return (string)GetValue(ItemHeaderPathProperty);
			}

			set
			{
				SetValue(ItemHeaderPathProperty, value);
			}
		}
		

		#endregion

		#region Constructors

		public ComboBox()
		{
			//InitializeComponent();
		}

		#endregion

		#region Propeties

		public IList<T> ItemsSource 
		{
			get
			{
				return (IList<T>)GetValue(ItemsSourceProperty);
			}

			set 
			{
				SetValue(ItemsSourceProperty, value);
			}
		}

		public T SelectedItem
		{
			get
			{
				return (T)GetValue(SelectedItemProperty);
			}

			set
			{
				SetValue(SelectedItemProperty, value);
			}
		}

		#endregion

		#region Methods

		private static void OnItemsSourceChanged(BindableObject bindable, IList<T> oldvalue, IList<T> newvalue)
		{
			var picker = bindable as ComboBox<T>;
			picker.Items.Clear();

			if (newvalue != null)
			{
				foreach (var item in newvalue)
				{
					picker.Items.Add(item.ToString());
				}
			}
		}

		private static void ItemHeaderPathPropertyChanged(BindableObject bindable, string oldvalue, string newvalue)
		{
			var picker = bindable as ComboBox<T>;
			var pathPartsEnumerator = newvalue.Split('.').GetEnumerator() as IEnumerator<string>;
			PropertyInfo neededProperty = null;

			while (pathPartsEnumerator.MoveNext())
			{
				neededProperty = (neededProperty == null ? neededProperty.PropertyType : typeof(T)).GetRuntimeProperty(pathPartsEnumerator.Current);									
			}

			for (int i = 0; i < picker.Items.Count; i++)
			{
				picker.Items[i] = neededProperty.GetValue(picker.ItemsSource.ElementAt(i)).ToString();
			}
		}		

		private static void OnSelectedItemChanged(BindableObject bindable, T oldvalue, T newvalue)
		{
			var picker = bindable as ComboBox<T>;

			if (newvalue != null)
			{
				picker.SelectedIndex = picker.Items.IndexOf(newvalue.ToString());
			}
		}

		#endregion
	}
}
