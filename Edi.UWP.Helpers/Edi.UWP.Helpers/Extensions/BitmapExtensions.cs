using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using Windows.UI.Xaml.Media.Imaging;

namespace Edi.UWP.Helpers.Extensions
{
    public enum ImageFormat
    {
        Bmp,
        Gif,
        Png,
        Jpg
    }

    public static class BitmapExtensions
    {
        /// <summary>
        /// Return WriteableBitmap object from a given path
        /// </summary>
        /// <param name="relativePath">file path</param>
        /// <returns>WriteableBitmap</returns>
        public static async Task<WriteableBitmap> LoadWriteableBitmap(string relativePath)
        {
            var storageFile = await Package.Current.InstalledLocation.GetFileAsync(relativePath.Replace('/', '\\'));
            var stream = await storageFile.OpenReadAsync();
            var wb = new WriteableBitmap(1, 1);
            wb.SetSource(stream);
            return wb;
        }

        /// <summary>
        /// Return byte array of a bitmap object
        /// </summary>
        /// <param name="bitmap">bitmap</param>
        /// <returns>byte array</returns>
        public static byte[] ToByteArray(this WriteableBitmap bitmap)
        {
            return bitmap.PixelBuffer.ToArray();
        }

        /// <summary>
        /// Convert bitmap object to Stream
        /// </summary>
        /// <param name="bitmap">bitmap</param>
        /// <returns>Stream</returns>
        public static Stream ToStream(this WriteableBitmap bitmap)
        {
            return bitmap.PixelBuffer.AsStream();
        }

        /// <summary>
        /// Save a bitmap to a PNG file
        /// </summary>
        /// <param name="bitmap">bitmap</param>
        /// <param name="location">path</param>
        /// <param name="fileName">file name</param>
        /// <param name="format">Image Format (PNG as default)</param>
        /// <returns>FileUpdateStatus</returns>
        public static async Task<FileUpdateStatus> SaveToPngImage(this WriteableBitmap bitmap, PickerLocationId location, string fileName, ImageFormat format = ImageFormat.Png)
        {
            var savePicker = new FileSavePicker
            {
                SuggestedStartLocation = location
            };
            savePicker.FileTypeChoices.Add($"{format} Image", new[] { $".{format.ToString().ToLower()}" });
            savePicker.SuggestedFileName = fileName;
            StorageFile sFile = await savePicker.PickSaveFileAsync();

            Guid encoderId = Guid.Empty;
            switch (format)
            {
                case ImageFormat.Bmp:
                    encoderId = BitmapEncoder.BmpEncoderId;
                    break;
                case ImageFormat.Gif:
                    encoderId = BitmapEncoder.GifEncoderId;
                    break;
                case ImageFormat.Jpg:
                    encoderId = BitmapEncoder.JpegEncoderId;
                    break;
                case ImageFormat.Png:
                    encoderId = BitmapEncoder.PngEncoderId;
                    break;
            }

            return await bitmap.WriteToStorageFile(encoderId, sFile);
        }

        /// <summary>
        /// Save a bitmap to a StorageFile object
        /// </summary>
        /// <param name="bitmap">bitmap</param>
        /// <param name="format">Image Format</param>
        /// <param name="file">StorageFile object</param>
        /// <returns>FileUpdateStatus</returns>
        public static async Task<FileUpdateStatus> SaveStorageFile(this WriteableBitmap bitmap, ImageFormat format, StorageFile file)
        {
            Guid encoderId = Guid.Empty;
            switch (format)
            {
                case ImageFormat.Bmp:
                    encoderId = BitmapEncoder.BmpEncoderId;
                    break;
                case ImageFormat.Gif:
                    encoderId = BitmapEncoder.GifEncoderId;
                    break;
                case ImageFormat.Jpg:
                    encoderId = BitmapEncoder.JpegEncoderId;
                    break;
                case ImageFormat.Png:
                    encoderId = BitmapEncoder.PngEncoderId;
                    break;
            }
            return await bitmap.WriteToStorageFile(encoderId, file);
        }

        public static async Task<FileUpdateStatus> WriteToStorageFile(this SoftwareBitmap bitmap, Guid encoderId, StorageFile file)
        {
            StorageFile sFile = file;
            if (sFile != null)
            {
                CachedFileManager.DeferUpdates(sFile);

                using (var fileStream = await sFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    BitmapEncoder encoder = await BitmapEncoder.CreateAsync(encoderId, fileStream);
                    encoder.SetSoftwareBitmap(bitmap);
                    await encoder.FlushAsync();
                }

                FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(sFile);
                return status;
            }
            return FileUpdateStatus.Failed;
        }

        public static async Task<FileUpdateStatus> WriteToStorageFile(this WriteableBitmap bitmap, Guid encoderId, StorageFile file)
        {
            StorageFile sFile = file;
            if (sFile != null)
            {
                CachedFileManager.DeferUpdates(sFile);

                using (var fileStream = await sFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    BitmapEncoder encoder = await BitmapEncoder.CreateAsync(encoderId, fileStream);
                    Stream pixelStream = bitmap.PixelBuffer.AsStream();
                    byte[] pixels = new byte[pixelStream.Length];
                    await pixelStream.ReadAsync(pixels, 0, pixels.Length);
                    encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore,
                        (uint) bitmap.PixelWidth,
                        (uint) bitmap.PixelHeight,
                        96.0,
                        96.0,
                        pixels);
                    await encoder.FlushAsync();
                }

                FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(sFile);
                return status;
            }
            return FileUpdateStatus.Failed;
        }
    }
}
