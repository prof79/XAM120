using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Phoneword.Core;

namespace Phoneword
{
    public class MainPage : ContentPage
    {
        #region Fields

        private readonly Entry _numberInput;
        private readonly Button _translateButton;
        private readonly Button _callButton;
        private string _translatedNumber;

        #endregion

        #region Constructors

        public MainPage()
        {
            // Construct the UI

            _numberInput = new Entry
            {
                Placeholder = "Telephone number",
                Text = "1-855-XAMARIN",
                WidthRequest = 400,
            };

            _translateButton = new Button
            {
                Text = "Translate"
            };

            _callButton = new Button
            {
                Text = "Call",
                IsEnabled = false,
            };

            Content =
                new StackLayout
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Padding = 20,
                    Children =
                    {
                        new Label
                        {
                            Text = "Enter a phoneword:"
                        },
                        _numberInput,
                        _translateButton,
                        _callButton
                    }
                }
            ;

            _translateButton.Clicked += (sender, e) =>
            {
                _translatedNumber =
                    _numberInput.Text.ToNumber();

                if (_translatedNumber != null)
                {
                    _callButton.Text =
                        $"Call {_translatedNumber}";

                    _callButton.IsEnabled = true;
                }
                else
                {
                    _callButton.Text = "Call";

                    _callButton.IsEnabled = false;
                }
            };

            _callButton.Clicked += async (sender, e) =>
            {
                var dialNumber = await
                    DisplayAlert(
                        "Dial a number",
                        $"Would you like to call {_translatedNumber}?",
                        "Yes",
                        "No");

                if (dialNumber)
                {
                    await
                        DependencyService
                            .Get<IDialer>()
                            .DialAsync(_translatedNumber)
                            .ConfigureAwait(false);
                }
            };
        }

        #endregion
    }
}
