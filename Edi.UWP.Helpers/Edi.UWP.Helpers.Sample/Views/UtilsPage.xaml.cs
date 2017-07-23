using Windows.Storage.Pickers;
using Windows.UI.Core;
using Edi.UWP.Helpers.Sample.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Edi.UWP.Helpers.Sample.Views
{
    public sealed partial class UtilsPage : Page
    {
        private UtilsViewModel ViewModel => DataContext as UtilsViewModel;

        public UtilsPage()
        {
            InitializeComponent();
            InkDefault.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Touch | CoreInputDeviceTypes.Pen;
        }

        private async void BtnSaveInk_OnClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await Edi.UWP.Helpers.Utils.SaveToInkFile(InkDefault, PickerLocationId.Desktop);
        }
    }
}
