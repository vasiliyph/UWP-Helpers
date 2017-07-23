using Windows.UI.Xaml;
using Edi.UWP.Helpers.Sample.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Edi.UWP.Helpers.Sample.Views
{
    public sealed partial class UIPage : Page
    {
        private UIViewModel ViewModel => DataContext as UIViewModel;

        public UIPage()
        {
            InitializeComponent();
        }

        private async void BtnHideWindowsMobileStatusBar_OnClick(object sender, RoutedEventArgs e)
        {
            await Edi.UWP.Helpers.UI.HideWindowsMobileStatusBar();
        }

        private async void BtnShowWindowsMobileStatusBar_OnClick(object sender, RoutedEventArgs e)
        {
            await Edi.UWP.Helpers.UI.ShowWindowsMobileStatusBar();
        }

        private void BtnGetHeight_OnClick(object sender, RoutedEventArgs e)
        {
            TxtHW.Text = Edi.UWP.Helpers.UI.GetScreenHeight().ToString();
        }

        private void BtnGetWidth_OnClick(object sender, RoutedEventArgs e)
        {
            TxtHW.Text = Edi.UWP.Helpers.UI.GetScreenWidth().ToString();
        }
    }
}
