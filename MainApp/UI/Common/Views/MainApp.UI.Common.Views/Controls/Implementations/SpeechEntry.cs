using Library.Commands;
using Microsoft.Practices.ServiceLocation;
using PhotoTransfer.UI.Common.Constants;
using PhotoTransfer.UI.Common.Interfaces.Image;
using PhotoTransfer.UI.Common.Interfaces.SpeechRecognitionService;
using PhotoTransfer.UI.Common.Views.Implementations.Xaml;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace PhotoTransfer.UI.Common.Views.Controls.Implementations
{
	public class SpeechEntry : ContentView
	{
		#region Binadble propeties
		
		public static readonly BindableProperty TextProperty = BindableProperty.Create<SpeechEntry, string>(x => x.Text, string.Empty, BindingMode.TwoWay);

		#endregion

		#region Services

		private static readonly ISpeechRecognitionService modSpeechRecognitionService = ServiceLocator.Current.GetInstance<ISpeechRecognitionService>();
		private readonly IIconsLoader modIconsLoader = ServiceLocator.Current.GetInstance<IIconsLoader>();
		private readonly Entry modEntry;

		#endregion
		
		#region Constructor
		
		public SpeechEntry()
		{			
			modEntry = new Entry();
			modEntry.SetValue(Grid.ColumnProperty, 0);
			modEntry.SetBinding(Entry.TextProperty, new Binding(SpeechEntry.TextProperty.PropertyName, BindingMode.TwoWay, source : this));
			
			var button = new ImageButton 
			{
				Source = ImageSource.FromFile(modIconsLoader.GetIconPath(IconNames.csMicrophone)) as FileImageSource,
				Command = new AsyncCommand(OnTryRecognizeSpeech),
				ImageHeightRequest = 35,
				ImageWidthRequest = 35,
				WidthRequest = 70,
				HeightRequest = 35
			};

			button.SetValue(Grid.ColumnProperty, 1);

			Content = new Grid
			{
				ColumnDefinitions = 
				{
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) }
				},
				Children = 
				{
					modEntry,
					button
				}
			};
		}

		#endregion

		#region Propeties for bindables

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

		#endregion

		#region Private methods

		async Task OnTryRecognizeSpeech()
		{
			IsEnabled = false;
			modEntry.Text = await modSpeechRecognitionService.TryToRecognizeSpeech();
			IsEnabled = true;
		}

		#endregion
	}
}
