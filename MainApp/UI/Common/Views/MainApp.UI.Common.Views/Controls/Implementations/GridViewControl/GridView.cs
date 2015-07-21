using PhotoTransfer.Common.Implementations.Extensions;
using PhotoTransfer.UI.Common.Views.Controls.Enums;
using PhotoTransfer.UI.Common.Views.Controls.Implementations.WrapLayoutControl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace PhotoTransfer.UI.Common.Views.Controls.Implementations.GridViewControl
{
	public class GridView : WrapLayout
	{
		#region Bindable properties

		public static readonly BindableProperty SelectedItemsProperty = BindableProperty.Create<GridView, IList>(
			x => x.SelectedItems, 
			null, 
			BindingMode.TwoWay, 
			propertyChanged: OnSelectedItemsChanged);

		public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create<GridView, object>(
			x => x.SelectedItem, 
			default(object), 
			BindingMode.TwoWay);
		
		public static readonly BindableProperty SelectionModeProperty =
			BindableProperty.Create<GridView, enSelectionMode>(
				x => x.SelectionMode, 
				enSelectionMode.Single);

		#endregion

		#region Properties

		public IList SelectedItems
		{
			get
			{
				return (IList)GetValue(SelectedItemsProperty);
			}

			private set 
			{
				SetValue(SelectedItemsProperty, value);
			}
		}

		public object SelectedItem
		{
			get
			{
				return (object)GetValue(SelectedItemProperty);
			}

			set
			{
				SetValue(SelectedItemProperty, value);
			}
		}

		public enSelectionMode SelectionMode
		{
			get
			{
				return (enSelectionMode)GetValue(SelectionModeProperty);
			}

			set
			{
				SetValue(SelectionModeProperty, value);
			}
		}

		#endregion

		#region Private methods

		void InitContent()
		{
			if (SelectionMode != enSelectionMode.None)
			{
				SelectedItems.With(x => x.Clear());
				Children.ForEach(x => 
				{
					x.PropertyChanged -= OnChildPropertyChanged;
					x.RemoveBinding(GridViewItem.ContentTemplateProperty);
				});
			}

			Children.Clear();

			if (ItemsSource == null)
				return;

			ItemsSource.Cast<object>().Select(x => 
			{
				var item = new GridViewItem
				{
					BindingContext = x,					
					SelectionEnabled = SelectionMode != enSelectionMode.None
				};

				item.SetBinding(GridViewItem.ContentTemplateProperty, new Binding(GridView.ItemTemplateProperty.PropertyName, source : this));				
				
				if (SelectionMode != enSelectionMode.None)
					item.PropertyChanged += OnChildPropertyChanged;

				return item;
			}).ForEach(Children.Add);
		}

		#endregion

		#region Handlers for bindables

		private static void OnSelectedItemsChanged(object sender, IList oldValue, IList newValue)
		{
			sender.WithType<GridView>(gv =>
				{
					oldValue.WithType<INotifyCollectionChanged>(x => x.CollectionChanged -= gv.SelectedItemsCollectionChanged);
					newValue.WithType<INotifyCollectionChanged>(x => x.CollectionChanged += gv.SelectedItemsCollectionChanged);
				});
		}

		private void SelectedItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Reset:
					Children.OfType<GridViewItem>().ForEach(x =>
					{
						x.PropertyChanged -= OnChildPropertyChanged;
						x.IsSelected = false;
						x.PropertyChanged += OnChildPropertyChanged;
					});

					break;
			}
		}

		#endregion

		#region Handlers

		private void OnChildPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName != GridViewItem.IsSelectedProperty.PropertyName)
				return;

			var gvi = (GridViewItem)sender;
			
			if (gvi.IsSelected)
			{
				if (SelectionMode == enSelectionMode.Single && SelectedItem != null)
				{
					var lastSelected = Children.FirstOrDefault(x => x.BindingContext == SelectedItem) as GridViewItem;

					if (lastSelected != null)
						lastSelected.IsSelected = false;
				}

				SelectedItems.Add(gvi.BindingContext);
				SelectedItem = gvi.BindingContext;
			}
			else
			{
				SelectedItems.Remove(gvi.BindingContext);				
				SelectedItem = SelectedItems.Cast<object>().LastOrDefault();
			}
		}

		#endregion		

		#region Overrided methods

		protected override void OnItemSourceChangedProtected(WrapLayout sender, IList newValue)
		{
			InitContent();
		}

		protected override void OnItemTemplateChangedProtected(BindableObject sender, DataTemplate newValue)
		{

		}

		#endregion
	}
}
