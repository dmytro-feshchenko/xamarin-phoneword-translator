using System;

using Xamarin.Forms;

namespace Phoneword
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
			double padding = 0;
			switch (Device.RuntimePlatform)
			{
				case Device.iOS:
					padding = 40;
					break;
				default:
					padding = 20;
					break;
			}
            Content = new StackLayout
            {
                Padding = new Thickness(padding),
                Children = {
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "Enter a password:"

                    },
                    new Entry {
                        Text = "1-855-XAMARIN"
                    },
                    new Button {
                        Text = "Translate"
                    },
                    new Button {
                        Text = "Call",
                        IsEnabled = false
                    },
                    new Entry {

                    }
                }
            };
        }
    }
}