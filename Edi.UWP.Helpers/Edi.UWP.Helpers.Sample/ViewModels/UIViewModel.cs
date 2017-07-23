using System;
using Windows.UI.Xaml.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Edi.UWP.Helpers.Sample.ViewModels
{
    public class UIViewModel : ViewModelBase
    {
        private SolidColorBrush _accentColor;

        public UIViewModel()
        {
            CommandGetAccentColor = new RelayCommand(GetAccentColor);
        }

        public SolidColorBrush AccentColor
        {
            get => _accentColor;
            set { _accentColor = value; RaisePropertyChanged(); }
        }

        public RelayCommand CommandGetAccentColor { get; set; }

        private void GetAccentColor()
        {
            AccentColor = new SolidColorBrush(Edi.UWP.Helpers.UI.GetAccentColor());
        }
    }
}
