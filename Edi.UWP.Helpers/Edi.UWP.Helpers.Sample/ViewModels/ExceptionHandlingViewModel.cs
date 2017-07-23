using System;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Edi.UWP.Helpers.Sample.ViewModels
{
    public class ExceptionHandlingViewModel : ViewModelBase
    {
        public RelayCommand CommandMakeException { get; set; }

        public ExceptionHandlingViewModel()
        {
            CommandMakeException = new RelayCommand(() => throw new Exception("WTF"));
        }
    }
}
