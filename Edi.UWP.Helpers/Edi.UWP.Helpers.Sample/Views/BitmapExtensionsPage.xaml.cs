using Edi.UWP.Helpers.Sample.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Edi.UWP.Helpers.Sample.Views
{
    public sealed partial class BitmapExtensionsPage : Page
    {
        private BitmapExtensionsViewModel ViewModel
        {
            get { return DataContext as BitmapExtensionsViewModel; }
        }

        public BitmapExtensionsPage()
        {
            InitializeComponent();
        }
    }
}
