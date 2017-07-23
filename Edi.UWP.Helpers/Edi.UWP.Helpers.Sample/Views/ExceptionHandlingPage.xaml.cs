using Edi.UWP.Helpers.Sample.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Edi.UWP.Helpers.Sample.Views
{
    public sealed partial class ExceptionHandlingPage : Page
    {
        private ExceptionHandlingViewModel ViewModel => DataContext as ExceptionHandlingViewModel;

        public ExceptionHandlingPage()
        {
            InitializeComponent();
        }
    }
}
