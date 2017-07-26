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
    }
}
