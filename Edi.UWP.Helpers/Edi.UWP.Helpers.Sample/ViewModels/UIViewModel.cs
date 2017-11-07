using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Edi.UWP.Helpers.Sample.ViewModels
{
    public class UIViewModel : ViewModelBase
    {
        private SolidColorBrush _accentColor;
        private string _hwText;

        public UIViewModel()
        {
            CommandGetAccentColor = new RelayCommand(GetAccentColor);
            CommandGetScreenHeight = new RelayCommand(GetScreenHeight);
            CommandGetScreenWidth = new RelayCommand(GetScreenWidth);
        }

        public SolidColorBrush AccentColor
        {
            get => _accentColor;
            set
            {
                _accentColor = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand CommandGetAccentColor { get; set; }

        public RelayCommand CommandGetScreenHeight { get; set; }

        public RelayCommand CommandGetScreenWidth { get; set; }

        public RelayCommand CommandHideWindowsMobileStatusBar { get; set; }

        public RelayCommand CommandShowWindowsMobileStatusBar { get; set; }

        public string HWText
        {
            get => _hwText;
            set
            {
                _hwText = value;
                RaisePropertyChanged();
            }
        }

        private void GetScreenWidth()
        {
            HWText = UI.GetScreenWidth().ToString();
        }

        private void GetScreenHeight()
        {
            HWText = UI.GetScreenHeight().ToString();
        }

        private void GetAccentColor()
        {
            AccentColor = new SolidColorBrush(UI.GetAccentColor());
        }
    }
}