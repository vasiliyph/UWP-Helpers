using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;

namespace Edi.UWP.Helpers
{
    public class Utils
    {
        public static void CopyToClipBoard(string str)
        {
            var dp = new DataPackage
            {
                RequestedOperation = DataPackageOperation.Copy,
            };
            dp.SetText(str);
            Clipboard.SetContent(dp);
        }

        public static async Task<Response<bool>> SaveToInkFile(InkCanvas inkCanvas, PickerLocationId location)
        {
            IRandomAccessStream stream = new InMemoryRandomAccessStream();

            var strokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
            if (strokes.Any())
            {
                await inkCanvas.InkPresenter.StrokeContainer.SaveAsync(stream);

                var picker = new FileSavePicker
                {

                    SuggestedStartLocation = location
                };
                picker.FileTypeChoices.Add("INK files", new List<string>() { ".ink" });
                var file = await picker.PickSaveFileAsync();
                if (file == null)
                {
                    return new Response<bool>()
                    {
                        IsSuccess = false,
                        Message = $"{nameof(file)} is null"
                    };
                }

                CachedFileManager.DeferUpdates(file);
                var bt = await Utils.ConvertImagetoByte(stream);
                await FileIO.WriteBytesAsync(file, bt);
                await CachedFileManager.CompleteUpdatesAsync(file);

                return new Response<bool>()
                {
                    IsSuccess = true
                };
            }
            else
            {
                return new Response<bool>()
                {
                    IsSuccess = false
                };
            }
        }

        public static async Task LoadInkFile(InkCanvas inkCanvas, PickerLocationId location)
        {
            var picker = new FileOpenPicker
            {
                SuggestedStartLocation = location
            };
            picker.FileTypeFilter.Add(".ink");
            var pickedFile = await picker.PickSingleFileAsync();
            if (pickedFile != null)
            {
                var file = await pickedFile.OpenReadAsync();
                await inkCanvas.InkPresenter.StrokeContainer.LoadAsync(file);
            }
        }

        public static async Task<byte[]> ConvertImagetoByte(IRandomAccessStream fileStream)
        {
            var reader = new DataReader(fileStream.GetInputStreamAt(0));
            await reader.LoadAsync((uint)fileStream.Size);
            byte[] pixels = new byte[fileStream.Size];
            reader.ReadBytes(pixels);
            return pixels;
        }

        public static string GetAppVersion()
        {
            var ver = Windows.ApplicationModel.Package.Current.Id.Version;
            return $"{ver.Major}.{ver.Minor}.{ver.Build}.{ver.Revision}";
        }

        public static Uri GetAppLogoUri() => Windows.ApplicationModel.Package.Current.Logo;

        public static string GetAppDisplayName() => Windows.ApplicationModel.Package.Current.DisplayName;

        public static string GetAppPublisher() => Windows.ApplicationModel.Package.Current.PublisherDisplayName;
    }
}
