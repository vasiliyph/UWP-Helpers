using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Edi.UWP.Helpers.Extensions
{
    public static class ColorExtenstions
    {
        public static Color FromHex(this Color color, string hex)
        {
            var c = ConvertHexToColor(hex);
            return c;
        }

        public static string ToHex(this Color color)
        {
            return color.ToString().Replace("#FF", "#");
        }

        public static SolidColorBrush FromHex(this SolidColorBrush brush, string hex)
        {
            var color = ConvertHexToColor(hex);
            return new SolidColorBrush(color);
        }

        private static Color ConvertHexToColor(string hex)
        {
            var colorStr = hex.ToLower();
            colorStr = colorStr.Replace("#", string.Empty);
            var r = (byte)Convert.ToUInt32(colorStr.Substring(0, 2), 16);
            var g = (byte)Convert.ToUInt32(colorStr.Substring(2, 2), 16);
            var b = (byte)Convert.ToUInt32(colorStr.Substring(4, 2), 16);
            var color = Color.FromArgb(255, r, g, b);
            return color;
        }
    }
}
