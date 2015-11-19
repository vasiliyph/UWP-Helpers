using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace SampleApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _emailTo;

        public string EmailTo
        {
            get { return _emailTo; }
            set { _emailTo = value; RaisePropertyChanged(); }
        }

        private string _emailSubject;

        public string EmailSubject
        {
            get { return _emailSubject; }
            set
            {
                _emailSubject = value;
                RaisePropertyChanged();
            }
        }

        private string _emailBody;

        public string EmailBody
        {
            get { return _emailBody; }
            set
            {
                _emailBody = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand CommandShowEmailCompose { get; set; }

        public MainViewModel()
        {
            EmailTo = "Edi.Wang@outlook.com";
            EmailSubject = "Hello From Edi.UWP.Helpers";
            EmailBody = "Hey";

            CommandShowEmailCompose = new RelayCommand(async ()=> await ShowEmailCompse());
        }

        private async Task ShowEmailCompse()
        {
            await Edi.UWP.Helpers.Tasks.OpenEmailComposeAsync(EmailTo, EmailSubject, EmailBody);
        }
    }
}