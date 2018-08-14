// MainPage.xaml.cs

namespace Phoneword.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new Phoneword.App());
        }
    }
}
