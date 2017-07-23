using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Edi.UWP.Helpers.Sample.ViewModels;

using Windows.UI.Xaml.Controls;
using Edi.UWP.Helpers.Extensions;

namespace Edi.UWP.Helpers.Sample.Views
{
    public sealed partial class BitmapExtensionsPage : Page
    {
        private BitmapExtensionsViewModel ViewModel => DataContext as BitmapExtensionsViewModel;

        public BitmapExtensionsPage()
        {
            InitializeComponent();
        }

        private async void BtnLoadBitmap_OnClick(object sender, RoutedEventArgs e)
        {
            LoadBitMapTarget.Source = await BitmapExtensions.LoadWriteableBitmap("Assets/66090-106.jpg");
        }

        private async void BtnSavePng_OnClick(object sender, RoutedEventArgs e)
        {
            var bitmap = await BitmapExtensions.LoadWriteableBitmap("Assets/66090-106.jpg");
            await bitmap.SaveToPngImage(PickerLocationId.PicturesLibrary, "example-image");
        }
    }
}
