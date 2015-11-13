using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Edi.UWP.Helpers
{
    public static class BitmapExtensions
    {
        public static byte[] ToByteArray(WriteableBitmap bitmap)
        {
            return bitmap.PixelBuffer.ToArray();
        }

        public static Stream ToStream(WriteableBitmap bitmap)
        {
            return bitmap.PixelBuffer.AsStream();
        }
    }
}
