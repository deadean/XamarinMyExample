using PhotoTransfer.Common.Implementations.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace PhotoTransfer.UI.Common.Views.Controls.Implementations
{
	public class Combobox<T> : Picker
	{
		#region Bindable properties
		
		public static readonly BindableProperty ItemsSourceProperty =
			BindableProperty.Create<Combobox<T>, IList<T>>(
				x => x.ItemsSource, 
				null, 
				propertyChanged : ItemsSourceChanged, 
				defaultBindingMode : BindingMode.TwoWay);

		public static readonly BindableProperty SelectedItemProperty =
			BindableProperty.Create<Combobox<T>, T>(
				x => x.SelectedItem, 
				default(T),
				propertyChanged : SelectedItemChanged, 
				defaultBindingMode : BindingMode.TwoWay);

		public static readonly BindableProperty StringConverterProperty =
			BindableProperty.Create<Combobox<T>, Func<T, string>>(
				x => x.StringConverter, 
				null, 
				propertyChanged: StringConverterChanged, 
				defaultBindingMode: BindingMode.TwoWay);

		#endregion

		#region Constructors
		
		public Combobox()
		{	
			SelectedIndexChanged += Combobox_SelectedIndexChanged;			
		}

		#endregion

		#region Destructors

		~Combobox()
		{
			SelectedIndexChanged -= Combobox_SelectedIndexChanged;
		}

		#endregion

		#region Properties
		
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

		public Func<T, string> StringConverter
		{
			get
			{
				return (Func<T, string>)GetValue(StringConverterProperty);
			}

			set
			{
				SetValue(StringConverterProperty, value);
			}
		}

		#endregion

		#region Bindable properties changed handlers

		private static void ItemsSourceChanged(BindableObject source, IList<T> oldValue, IList<T> newValue)
		{
			if (newValue == null)
				return;

			source.WithType<Combobox<T>>(x =>
			{
				x.Items.Clear();

				foreach (var item in newValue)
				{
					x.Items.Add(x.StringConverter == null ? item.ToString() : x.StringConverter(item));
				}
			});
		}

		private static void StringConverterChanged(BindableObject source, Func<T, string> oldValue, Func<T, string> newValue)
		{			
			source.WithType<Combobox<T>>(x =>
			{
				if (x.ItemsSource == null)
					return;

				for (int i = 0; i < x.ItemsSource.Count; i++)
				{
					x.Items[i] = newValue == null ? x.ItemsSource[i].ToString() : newValue(x.ItemsSource[i]);
				}
			});
		}

		private static void SelectedItemChanged(BindableObject source, T oldValue, T newValue)
		{
			source.WithType<Combobox<T>>(x =>
			{
				if (x.ItemsSource == null)
					return;

				x.SelectedIndex = x.ItemsSource.IndexOf(newValue);
			});
		}

		#endregion

		#region Event handlers

		void Combobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (SelectedIndex == -1 || ItemsSource.Count == 0)
				return;

			SelectedItem = ItemsSource[SelectedIndex];
		}

		#endregion
	}
}
