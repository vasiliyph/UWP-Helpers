using System;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Edi.UWP.Helpers.Sample.ViewModels
{
    public class ConvertersViewModel : ViewModelBase
    {
        private bool _isVisible;

        public bool IsVisible
        {
            get => _isVisible;
            set { _isVisible = value; RaisePropertyChanged(); }
        }

        public RelayCommand CommandToggleBool { get; set; }

        public ConvertersViewModel()
        {
            CommandToggleBool = new RelayCommand(() => { IsVisible = !IsVisible; });
        }
    }
}
