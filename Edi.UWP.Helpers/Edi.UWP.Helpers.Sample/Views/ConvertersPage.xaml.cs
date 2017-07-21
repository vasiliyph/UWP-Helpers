using Edi.UWP.Helpers.Sample.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Edi.UWP.Helpers.Sample.Views
{
    public sealed partial class ConvertersPage : Page
    {
        private ConvertersViewModel ViewModel
        {
            get { return DataContext as ConvertersViewModel; }
        }

        public ConvertersPage()
        {
            InitializeComponent();
        }
    }
}
