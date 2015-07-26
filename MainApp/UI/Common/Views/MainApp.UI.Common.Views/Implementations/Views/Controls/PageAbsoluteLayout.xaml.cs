using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MainApp.UI.Common.Views.Implementations.Views.Controls
{
	public partial class PageAbsoluteLayout : ContentPage
	{
		const double squareSize = 35;
		private AbsoluteLayout absoluteLayout2;
		private AbsoluteLayout absoluteLayout3;
		const double period = 2000;                     
		readonly DateTime startTime = DateTime.Now;
		public PageAbsoluteLayout()
		{
			InitializeComponent();
			AbsoluteLayout absoluteLayout = new AbsoluteLayout
			{
				Padding = new Thickness(50),
				BackgroundColor = Color.FromRgb(240, 220, 130)
			};

			GenerateDefaultLayout(absoluteLayout);

			GenerateLayout1(absoluteLayout);

			GenerateLayout2(absoluteLayout);

			//GenerateLayout3(absoluteLayout);

			stack1.Children.Add(absoluteLayout);

			Device.StartTimer(TimeSpan.FromMilliseconds(15), OnTimerTick);
		}

		bool OnTimerTick()
		{
			TimeSpan elapsed = DateTime.Now - startTime;
			double t = (elapsed.TotalMilliseconds % period) / period;   // 0 to 1
			t = 2 * (t < 0.5 ? t : 1 - t);                              // 0 to 1 to 0

			AbsoluteLayout.SetLayoutBounds(label1,
					new Rectangle(t, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

			AbsoluteLayout.SetLayoutBounds(label2,
					new Rectangle(0.5, 1 - t, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

			return true;
		}

		private void GenerateLayout3(AbsoluteLayout absoluteLayout)
		{
			 absoluteLayout3 = new AbsoluteLayout         
			 {             
				 BackgroundColor = Color.FromRgb(240, 220, 130),             
				 HorizontalOptions = LayoutOptions.Center,            
				 VerticalOptions = LayoutOptions.Center         
			 };  
			for (int row = 0; row < 8; row++)         
			{             
				for (int col = 0; col < 8; col++)             
				{                 
					// Skip every other square.                 
					if (((row ^ col) & 1) == 0)                     
						continue;  
                
					BoxView boxView = new BoxView                 
					{                     
						Color = Color.FromRgb(0, 64, 0)                 
					};  
                
					Rectangle rect = new Rectangle(col / 7.0,   row / 7.0,  1 / 8.0,  1 / 8.0); 
					absoluteLayout.Children.Add(boxView, rect, AbsoluteLayoutFlags.All);
				}         
			}  
			ContentView contentView = new ContentView 
			{ 
				Content = absoluteLayout3
			}; 
			contentView.SizeChanged += OnContentViewSizeChanged;

			absoluteLayout.Children.Add(contentView, new Point(0, 250));
		}

		private void GenerateLayout2(AbsoluteLayout absoluteLayout)
		{
			absoluteLayout2 = new AbsoluteLayout
			{
				BackgroundColor = Color.FromRgb(240, 220, 130),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			for (int i = 0; i < 32; i++)
			{
				BoxView boxView = new BoxView
				{
					Color = Color.FromRgb(0, 64, 0)
				};
				absoluteLayout2.Children.Add(boxView);
			}

			ContentView contentView = new ContentView
			{
				Content = absoluteLayout2
			};
			contentView.SizeChanged += OnContentViewSizeChanged;
			absoluteLayout.Children.Add(contentView, new Rectangle(new Point(300, 130), new Size(400, 400)));
		}

		void OnContentViewSizeChanged(object sender, EventArgs args)
		{
			ContentView contentView = (ContentView)sender;
			double squareSize = Math.Min(contentView.Width, contentView.Height) / 8;
			int index = 0;

			for (int row = 0; row < 8; row++)
			{
				for (int col = 0; col < 8; col++)
				{
					// Skip every other square.
					if (((row ^ col) & 1) == 0)
						continue;

					View view = absoluteLayout2.Children[index];
					Rectangle rect = new Rectangle(col * squareSize,
																				 row * squareSize,
																				 squareSize, squareSize);

					AbsoluteLayout.SetLayoutBounds(view, rect);
					index++;
				}
			}
		}

		private static void GenerateDefaultLayout(AbsoluteLayout absoluteLayout)
		{
			absoluteLayout.Children.Add(
						 new BoxView
						 {
							 Color = Color.Blue
						 },
						 new Rectangle(0, 10, 200, 5));

			absoluteLayout.Children.Add(
					new BoxView
					{
						Color = Color.Blue
					},
					new Rectangle(0, 20, 200, 5));

			absoluteLayout.Children.Add(
					new BoxView
					{
						Color = Color.Blue
					},
					new Rectangle(10, 0, 5, 65));

			absoluteLayout.Children.Add(
					new BoxView
					{
						Color = Color.Blue
					},
					new Rectangle(20, 0, 5, 65));

			absoluteLayout.Children.Add(
					new Label
					{
						Text = "Stylish Header",
						FontSize = 24
					},
					new Point(30, 25));

			absoluteLayout.Children.Add(
					new Label
					{
						FormattedText = new FormattedString
						{
							Spans = 
                    {
                        new Span
                        {
                            Text = "Although the "
                        },
                        new Span
                        {
                            Text = "AbsoluteLayout",
                            FontAttributes = FontAttributes.Italic
                        },
                        new Span
                        {
                            Text = " is usually employed for purposes other " +
                                    "than the display of text using "
                        },
                        new Span
                        {
                            Text = "Label",
                            FontAttributes = FontAttributes.Italic
                        },
                        new Span
                        {
                            Text = ", obviously it can be used in that way. " +
                                    "The text continues to wrap nicely " +
                                    "within the bounds of the container " +
                                    "and any padding that might be applied."
                        }
                    }
						}
					},
					new Point(0, 80));
		}

		private static AbsoluteLayout GenerateLayout1(AbsoluteLayout absoluteLayout)
		{
			AbsoluteLayout l1 = new AbsoluteLayout();

			for (int row = 0; row < 8; row++)
			{
				for (int col = 0; col < 8; col++)
				{
					// Skip every other square.
					if (((row ^ col) & 1) == 0)
						continue;

					BoxView boxView = new BoxView { Color = Color.FromRgb(0, 64, 0) };
					Rectangle rect = new Rectangle(col * squareSize, row * squareSize, squareSize, squareSize);
					l1.Children.Add(boxView, rect);
				}
			}

			absoluteLayout.Children.Add(l1, new Point(0, 130));
			return l1;
		}
	}
}
