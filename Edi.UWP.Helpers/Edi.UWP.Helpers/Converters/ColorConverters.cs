using System;
using System.Globalization;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Edi.UWP.Helpers.Converters
{
    public class ColorToSolidColorBrushValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (null == value)
            {
                return null;
            }

            if (value is Color)
            {
                var color = (Color)value;
                return new SolidColorBrush(color);
            }

            var type = value.GetType();
            throw new InvalidOperationException("Unsupported type [" + type.Name + "]");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class ColorToRgbStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (null == value)
            {
                return null;
            }

            if (value is Color)
            {
                var color = (Color)value;

                const string sRgb = @"{0},{1},{2}";
                return string.Format(sRgb, color.R, color.G, color.B);
            }

            var type = value.GetType();
            throw new InvalidOperationException("Unsupported type [" + type.Name + "]");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var colorStr = ((string)value).ToLower();
            var arrRgb = colorStr.Split(',');
            if (arrRgb.Length == 3)
            {
                var r = (byte)(System.Convert.ToUInt32(arrRgb[0]));
                var g = (byte)(System.Convert.ToUInt32(arrRgb[1]));
                var b = (byte)(System.Convert.ToUInt32(arrRgb[2]));
                return (Color.FromArgb(255, r, g, b));
            }
            throw new FormatException("RGB格式错误");
        }
    }

    public class ColorToHexStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (null == value)
            {
                return null;
            }

            if (value is Color)
            {
                var color = (Color)value;
                return color.ToString().Replace("#FF", "#");
            }

            var type = value.GetType();
            throw new InvalidOperationException("Unsupported type [" + type.Name + "]");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var colorStr = ((string)value).ToLower();

            colorStr = colorStr.Replace("#", string.Empty);

            try
            {
                var r = (byte)(System.Convert.ToUInt32(colorStr.Substring(0, 2), 16));
                var g = (byte)(System.Convert.ToUInt32(colorStr.Substring(2, 2), 16));
                var b = (byte)(System.Convert.ToUInt32(colorStr.Substring(4, 2), 16));

                return (Color.FromArgb(255, r, g, b));
            }
            catch (Exception)
            {
                return (Color.FromArgb(255, 0, 0, 0));
            }
        }
    }

    public class ColorToCMYKStringConverter : IValueConverter
    {
        private static string CMYKtoHex(decimal[] cmyk)
        {
            if (cmyk.Length != 4) return null;

            var r = (int)(255 * (1 - cmyk[0]) * (1 - cmyk[3]));
            var g = (int)(255 * (1 - cmyk[1]) * (1 - cmyk[3]));
            var b = (int)(255 * (1 - cmyk[2]) * (1 - cmyk[3]));

            var hex = "#" + r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
            return hex;
        }

        private static decimal[] HexToCMYK(string hex)
        {
            decimal computedC = 0;
            decimal computedM = 0;
            decimal computedY = 0;
            decimal computedK = 0;

            hex = (hex[0] == '#') ? hex.Substring(1, 6) : hex;

            if (hex.Length != 6)
            {
                return null;
            }

            decimal r = int.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
            decimal g = int.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
            decimal b = int.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);

            // BLACK
            if (r == 0 && g == 0 && b == 0)
            {
                computedK = 1;
                return new[] { 0, 0, 0, computedK };
            }

            computedC = 1 - (r / 255);
            computedM = 1 - (g / 255);
            computedY = 1 - (b / 255);

            var minCMY = Math.Min(computedC, Math.Min(computedM, computedY));

            computedC = (computedC - minCMY) / (1 - minCMY);
            computedM = (computedM - minCMY) / (1 - minCMY);
            computedY = (computedY - minCMY) / (1 - minCMY);
            computedK = minCMY;

            return new[] { computedC, computedM, computedY, computedK };
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (null == value)
            {
                return null;
            }

            if (value is Color)
            {
                var color = (Color)value;
                var hex = color.ToString().Replace("#FF", "#");
                var cmyk = HexToCMYK(hex);
                var cmykStrArr = cmyk.Select(p => p.ToString("0.##"));
                return string.Join(",", cmykStrArr);
            }

            var type = value.GetType();
            throw new InvalidOperationException("Unsupported type [" + type.Name + "]");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (null == value)
            {
                return null;
            }

            var cmykArr = value.ToString().Split(',').Select(decimal.Parse);
            var enumerable = cmykArr as decimal[] ?? cmykArr.ToArray();
            if (enumerable.Any())
            {
                var hex = CMYKtoHex(enumerable.ToArray());
                hex = hex.Replace("#", string.Empty);

                try
                {
                    var r = (byte)(System.Convert.ToUInt32(hex.Substring(0, 2), 16));
                    var g = (byte)(System.Convert.ToUInt32(hex.Substring(2, 2), 16));
                    var b = (byte)(System.Convert.ToUInt32(hex.Substring(4, 2), 16));

                    return (Color.FromArgb(255, r, g, b));
                }
                catch (Exception)
                {
                    return (Color.FromArgb(255, 0, 0, 0));
                }
            }
            return (Color.FromArgb(255, 0, 0, 0));
        }
    }

    public class ColorHexStringToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var colorStr = ((string)value).ToLower();

            colorStr = colorStr.Replace("#", string.Empty);

            var r = (byte)(System.Convert.ToUInt32(colorStr.Substring(0, 2), 16));
            var g = (byte)(System.Convert.ToUInt32(colorStr.Substring(2, 2), 16));
            var b = (byte)(System.Convert.ToUInt32(colorStr.Substring(4, 2), 16));

            var myBrush = new SolidColorBrush(Color.FromArgb(255, r, g, b));
            return myBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class ColorHexStringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var colorStr = ((string)value).ToLower();

            colorStr = colorStr.Replace("#", string.Empty);

            var r = (byte)(System.Convert.ToUInt32(colorStr.Substring(0, 2), 16));
            var g = (byte)(System.Convert.ToUInt32(colorStr.Substring(2, 2), 16));
            var b = (byte)(System.Convert.ToUInt32(colorStr.Substring(4, 2), 16));

            return (Color.FromArgb(255, r, g, b));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
