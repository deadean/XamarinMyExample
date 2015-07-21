using Library.Commands;
using PhotoTransfer.Common.Implementations.Extensions;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace PhotoTransfer.UI.Common.Views.Controls.Implementations.GridViewControl
{
	public class GridViewItem : ContentView
	{
		#region Bindable properties

		public static readonly BindableProperty IsSelectedProperty =
			BindableProperty.Create<GridViewItem, bool>(
				x => x.IsSelected,
				false,
				defaultBindingMode: BindingMode.TwoWay);

		public static readonly BindableProperty TemplateProperty =
			BindableProperty.Create<GridViewItem, DataTemplate>(
				x => x.Template,
				DefaultTemplate,
				propertyChanged: OnTemplatePropertyChanged);

		public static readonly BindableProperty ContentTemplateProperty =
			BindableProperty.Create<GridViewItem, DataTemplate>(
				x => x.ContentTemplate,
				null, 
				coerceValue:(bo, ov) => new DataTemplate(ov.CreateContent),
				propertyChanging:ContentTemplateChanging);

		public static readonly BindableProperty SelectionEnabledProperty =
			BindableProperty.Create<GridViewItem, bool>(
				x => x.SelectionEnabled,
				true);
		
		public static readonly BindableProperty TapCommandProperty =
			BindableProperty.Create<GridViewItem, ICommand>(
				x => x.TapCommand, 
				default(ICommand));
		
		public static readonly BindableProperty TapCommandParameterProperty =
			BindableProperty.Create<GridViewItem, object>(x => x.TapCommandParameter, default(object));

		#endregion

		#region Constructors

		public GridViewItem()
		{
			GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new DelegateCommand(OnTap)
			});
		}

		#endregion

		#region Properties

		public ICommand TapCommand
		{
			get
			{
				return (ICommand)GetValue(TapCommandProperty);
			}

			set
			{
				SetValue(TapCommandProperty, value);
			}
		}

		public object TapCommandParameter
		{
			get
			{
				return (object)GetValue(TapCommandParameterProperty);
			}

			set
			{
				SetValue(TapCommandParameterProperty, value);
			}
		}

		public bool SelectionEnabled
		{
			get
			{
				return (bool)GetValue(SelectionEnabledProperty);
			}

			set
			{
				SetValue(SelectionEnabledProperty, value);
			}
		}

		public bool IsSelected
		{
			get
			{
				return (bool)GetValue(IsSelectedProperty);
			}

			set
			{
				SetValue(IsSelectedProperty, value);
			}
		}

		public DataTemplate Template
		{
			get
			{
				return (DataTemplate)GetValue(TemplateProperty);
			}

			set
			{
				SetValue(TemplateProperty, value);
			}
		}

		public DataTemplate ContentTemplate
		{
			get
			{
				return (DataTemplate)GetValue(ContentTemplateProperty);
			}

			set
			{
				SetValue(ContentTemplateProperty, value);
			}
		}

		#endregion

		#region Handlers

		private static void OnTemplatePropertyChanged(BindableObject bindable, DataTemplate oldValue, DataTemplate newValue)
		{
			((GridViewItem)bindable).OnBindingContextChanged();
		}

		private static void ContentTemplateChanging(BindableObject bindable, DataTemplate oldValue, DataTemplate newValue)
		{
			oldValue.With(x => x.Bindings.Clear());			
			newValue.With(x => x.SetBinding(BindableObject.BindingContextProperty,
				new Binding(BindableObject.BindingContextProperty.PropertyName, BindingMode.TwoWay, source: bindable)));
		}

		protected virtual void OnTap()
		{
			IsSelected = !IsSelected;
			TapCommand.With(x => x.Execute(TapCommandParameter));
		}

		#endregion

		#region Overrided methods

		protected override void OnBindingContextChanged()
		{
			var dataTemplate = Template ?? DefaultTemplate;			
			var content = dataTemplate.CreateContent() as View;
			content.BindingContext = this;
			Content = content;
			base.OnBindingContextChanged();
		}
		
		#endregion

		#region Static templates

		private static DataTemplate DefaultTemplate
		{
			get
			{
				return new DataTemplate(() =>
				{
					var innerContent = new ContentControl();
					innerContent.SetValue(Grid.ColumnProperty, 1);
					innerContent.SetBinding<GridViewItem>(ContentControl.ContentTemplateProperty, x => x.ContentTemplate);
					
					var checkbox = new CheckBox 
					{
						VerticalOptions = LayoutOptions.Center
					};

					checkbox.SetBinding<GridViewItem>(CheckBox.CheckedProperty, x => x.IsSelected);
					
					return new Grid
					{
						ColumnDefinitions = 
						{
							new ColumnDefinition { Width = GridLength.Auto },
							new ColumnDefinition()
						},
						Children = 
						{
							checkbox,
							innerContent
						}
					};
				});
			}
		}

		#endregion
	}
}
