using Library.Commands;
using Library.Types;
using PhotoTransfer.Common.Implementations.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using XLabs.Forms.Behaviors;
using XLabs.Forms.Controls;
using XLabs.Forms.Exceptions;

namespace PhotoTransfer.UI.Common.Views.Controls.Implementations.FlipViewControl
{
	public class FlipView : ContentView
	{
		#region Fields

		readonly ContentControl modContentControl;
		readonly DelegateCommand mvSwitchPreviousCommand;
		readonly DelegateCommand mvSwithcNextCommand;
		int mvCurrentItemIndex = -1;

		#endregion

		#region Bindables

		public static readonly BindableProperty ItemsSourceProperty =
			BindableProperty.Create<FlipView, IList>(
				x => x.ItemsSource, 
				default(IList),
				propertyChanged:ItemsSourceChanged);
		
		public static readonly BindableProperty CurrentItemProperty =
			BindableProperty.Create<FlipView, object>(
				x => x.CurrentItem, 
				default(object), 
				propertyChanged: (bo, ov, nv) => bo.WithType<FlipView>(x => x.UpdateSwitchability()),
				defaultValueCreator: fv => fv.ItemsSource.With(x => x.Cast<object>().FirstOrDefault()));
		
		public static readonly BindableProperty LeftButtonStyleProperty =
			BindableProperty.Create<FlipView, Style>(x => x.LeftButtonStyle, default(Style));

		public static readonly BindableProperty RightButtonStyleProperty =
			BindableProperty.Create<FlipView, Style>(x => x.RightButtonStyle, default(Style));
				
		public static readonly BindableProperty ItemTemplateProperty =
			BindableProperty.Create<FlipView, DataTemplate>(x => x.ItemTemplate, default(DataTemplate));

		#endregion

		#region Constructor
		
		public FlipView()
		{
			#region Setup commands
			
			mvSwitchPreviousCommand = new DelegateCommand(() => SwitchView(false), () => mvCurrentItemIndex > 0);
			mvSwithcNextCommand = new DelegateCommand(() => SwitchView(true), () => ItemsSource != null && mvCurrentItemIndex < ItemsSource.Count - 1);

			#endregion

			#region Setup ContentControl

			modContentControl = new ContentControl
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			modContentControl.SetBinding(ContentControl.BindingContextProperty,
				new Binding(CurrentItemProperty.PropertyName, BindingMode.OneWay, source: this));

			modContentControl.SetBinding(
				ContentControl.ContentTemplateProperty, 
				new Binding(ItemTemplateProperty.PropertyName, BindingMode.OneWay, source : this));

			#endregion
			
			var prevButton = new Button
			{
				WidthRequest = 50,
				HeightRequest = 80,
				Command = mvSwitchPreviousCommand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Text = "<"
			};

			var nextButton = new Button
			{
				WidthRequest = 50,
				HeightRequest = 80,
				Command = mvSwithcNextCommand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Text = ">"
			};

			prevButton.SetBinding(Button.StyleProperty, new Binding(FlipView.LeftButtonStyleProperty.PropertyName, source : this));
			nextButton.SetBinding(Button.StyleProperty, new Binding(FlipView.RightButtonStyleProperty.PropertyName, source: this));

			prevButton.SetValue(Grid.ColumnProperty, 0);
			modContentControl.SetValue(Grid.ColumnProperty, 1);
			nextButton.SetValue(Grid.ColumnProperty, 2);

			Content = new Grid
			{
				ColumnDefinitions = 
				{
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) }
				},
				Children = 
				{
					prevButton,
					modContentControl,
					nextButton
				}
			};
		}

		#endregion

		#region Properties for bindables

		public object CurrentItem
		{
			get
			{
				return (object)GetValue(CurrentItemProperty);
			}

			set
			{
				SetValue(CurrentItemProperty, value);
			}
		}

		public IList ItemsSource
		{
			get
			{
				return (IList)GetValue(ItemsSourceProperty);
			}

			set
			{
				SetValue(ItemsSourceProperty, value);
			}
		}

		public DataTemplate ItemTemplate
		{
			get
			{
				return (DataTemplate)GetValue(ItemTemplateProperty);
			}

			set
			{
				SetValue(ItemTemplateProperty, value);
			}
		}

		public Style LeftButtonStyle
		{
			get
			{
				return (Style)GetValue(LeftButtonStyleProperty);
			}

			set
			{
				SetValue(LeftButtonStyleProperty, value);
			}
		}

		public Style RightButtonStyle
		{
			get
			{
				return (Style)GetValue(RightButtonStyleProperty);
			}

			set
			{
				SetValue(RightButtonStyleProperty, value);
			}
		}

		#endregion
		
		#region Gestures handlers

		void SwitchView(bool isSwithNext)
		{
			CurrentItem = ItemsSource[isSwithNext ? ++mvCurrentItemIndex : --mvCurrentItemIndex];
			UpdateSwitchability();
		}

		void UpdateSwitchability()
		{
			mvSwitchPreviousCommand.RaiseCanExecuteChanged();
			mvSwithcNextCommand.RaiseCanExecuteChanged();
		}

		void RemoveCurrentView()
		{
			UpdateSwitchability();
			ItemsSource.RemoveAt(mvCurrentItemIndex);			
		}

		#endregion

		#region Private methods

		private void ItemsSourceChanged(IList oldValue, IList newValue)
		{
			oldValue.WithType<INotifyCollectionChanged>(x => x.CollectionChanged -= ItemsCollectionChanged);
			newValue.WithType<INotifyCollectionChanged>(x => x.CollectionChanged += ItemsCollectionChanged);
			newValue.With(x =>
			{
				if (x.Count > 0)
				{
					CurrentItem = x[mvCurrentItemIndex = 0];
				}
			});
		}

		private void ItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			UpdateSwitchability();

			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
					if (e.NewStartingIndex == mvCurrentItemIndex)
						SwitchView(mvCurrentItemIndex < ItemsSource.Count);
					break;				
				case NotifyCollectionChangedAction.Remove:
					if (e.OldStartingIndex == mvCurrentItemIndex)
						SwitchView(mvCurrentItemIndex == 0);
					break;
				case NotifyCollectionChangedAction.Reset:
					mvCurrentItemIndex = -1;
					CurrentItem = null;
					break;
				case NotifyCollectionChangedAction.Replace:
					break;
				case NotifyCollectionChangedAction.Move:
					break;				
			}
		}

		#endregion

		#region Handlers for bindables

		public static void ItemsSourceChanged(BindableObject bindable, IList oldValue, IList newValue)
		{
			bindable.WithType<FlipView>(fv => fv.ItemsSourceChanged(oldValue, newValue));
		}		

		#endregion
	}
}
