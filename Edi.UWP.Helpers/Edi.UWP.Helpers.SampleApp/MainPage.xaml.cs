using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Edi.UWP.Helpers.Extensions;

namespace Edi.UWP.Helpers.SampleApp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            InkDefault.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Touch | CoreInputDeviceTypes.Pen;
        }

        private void BtnMakeException_OnClick(object sender, RoutedEventArgs e)
        {
            throw new ArgumentException("Test");
        }

        private void AppBarButtonAbout_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private async void BtnSaveInk_OnClick(object sender, RoutedEventArgs e)
        {
            await Edi.UWP.Helpers.Utils.SaveToInkFile(InkDefault, PickerLocationId.Desktop);
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
