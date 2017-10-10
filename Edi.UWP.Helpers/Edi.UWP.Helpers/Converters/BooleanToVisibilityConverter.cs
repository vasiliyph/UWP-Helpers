using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Edi.UWP.Helpers.Converters
{
    /// <summary>
    /// Covert bool to Visibility
    /// </summary>
    [Obsolete("In Windows 10 15063, System can bind Visibility to bool value natively, no use for this any more")]
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value is bool && (bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value is Visibility && (Visibility)value == Visibility.Visible;
        }
    }
}
