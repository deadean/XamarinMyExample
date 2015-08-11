﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MainApp.UI.Common.Views.Implementations.Views.Controls
{
	public partial class StandartControls : ContentPage
	{
		const int COUNT = 50;
		Random random = new Random();

		// Arrays for Random Name Generator.
		string[] vowels = { "a", "e", "i", "o", "u", "ai", "ei", "ie", "ou", "oo" };
		string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m",
                                "n", "p", "q", "r", "s", "t", "v", "w", "x", "z" };
		public StandartControls()
		{
			InitializeComponent();

			List<View> views = new List<View>();
			TapGestureRecognizer tapGesture = new TapGestureRecognizer();
			tapGesture.Tapped += OnBoxViewTapped;

			// Create BoxView elements and add to List.
			for (int i = 0; i < COUNT; i++)
			{
				BoxView boxView = new BoxView
				{
					Color = Color.Blue,
					HeightRequest = 300 * random.NextDouble(),
					VerticalOptions = LayoutOptions.End,
					StyleId = RandomNameGenerator()
				};
				boxView.GestureRecognizers.Add(tapGesture);
				views.Add(boxView);
			}

			// Add whole List of BoxView elements to Grid.
			grid.Children.AddHorizontal(views);

			// Start a timer at the frame rate.
			Device.StartTimer(TimeSpan.FromMilliseconds(15), OnTimerTick);
		}

		string RandomNameGenerator()
		{
			int numPieces = 1 + 2 * random.Next(1, 4);
			StringBuilder name = new StringBuilder();

			for (int i = 0; i < numPieces; i++)
			{
				name.Append(i % 2 == 0 ?
						consonants[random.Next(consonants.Length)] :
						vowels[random.Next(vowels.Length)]);
			}
			name[0] = Char.ToUpper(name[0]);
			return name.ToString();
		}

		// Set text to overlay Label and make it visible.
		void OnBoxViewTapped(object sender, EventArgs args)
		{
			BoxView boxView = (BoxView)sender;
			label.Text = String.Format("The individual known as {0} " +
																 "has a height of {1} centimeters.",
																 boxView.StyleId, (int)boxView.HeightRequest);
			overlay.Opacity = 1;
		}

		// Decrease visibility of overlay.
		bool OnTimerTick()
		{
			overlay.Opacity = Math.Max(0, overlay.Opacity - 0.0025);
			return true;
		}

		public void ValueChanged(object obj, EventArgs args)
		{
			boxview.Color = Color.FromRgb((int)slider1.Value, (int)slider2.Value, (int)slider3.Value);
		}

		public void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
		{
			AbsoluteLayout.SetLayoutBounds(label1, new Rectangle(args.NewValue, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			AbsoluteLayout.SetLayoutBounds(label2, new Rectangle(args.NewValue, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

			label1.Opacity = 1 - args.NewValue;
			label2.Opacity = args.NewValue; 
		}

		private void OnSizeChanged(object sender, EventArgs args)
		{
			 if (Width < Height)
			 {             
				 mainGrid.RowDefinitions[1].Height = GridLength.Auto;
				 mainGrid.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Absolute);
				 Grid.SetRow(boxview12, 1);
				 Grid.SetColumn(boxview12, 0);
			 }
			 else
			 {
				 mainGrid.RowDefinitions[1].Height = new GridLength(0, GridUnitType.Absolute);
				 mainGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
				 Grid.SetRow(boxview12, 0);
				 Grid.SetColumn(boxview12, 1);         
			 }
		}
	}
}
