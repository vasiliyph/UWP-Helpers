using Edi.UWP.Helpers.Sample.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Edi.UWP.Helpers.Sample.Views
{
    public sealed partial class UtilsPage : Page
    {
        private UtilsViewModel ViewModel
        {
            get { return DataContext as UtilsViewModel; }
        }

        public UtilsPage()
        {
            InitializeComponent();
        }
    }
}
