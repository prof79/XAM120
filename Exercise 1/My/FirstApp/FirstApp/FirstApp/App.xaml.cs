// App.xaml.cs

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace FirstApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

            //MainPage = new MainPage();

            // Code-based approach
            var button = new Button
            {
                Text = "Click Me"
            };

            button.Clicked += async (s, e) =>
                await MainPage.DisplayAlert("Hello", "Have a good day!", "OK");

            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Label
                        {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Welcome to Xamarin University!",
                            FontAttributes = FontAttributes.Bold,
                        },
                        button
                    }
                }
            };
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
