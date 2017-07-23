using Edi.UWP.Helpers.Sample.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Edi.UWP.Helpers.Sample.Views
{
    public sealed partial class TasksPage : Page
    {
        private TasksViewModel ViewModel => DataContext as TasksViewModel;

        public TasksPage()
        {
            InitializeComponent();
        }
    }
}
