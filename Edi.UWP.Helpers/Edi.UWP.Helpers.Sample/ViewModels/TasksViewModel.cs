using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Edi.UWP.Helpers.Sample.ViewModels
{
    public class TasksViewModel : ViewModelBase
    {
        private string _displayName;
        private string _emailBody;
        private string _emailSubject;
        private string _emailTo;
        private string _phoneNumber;

        public TasksViewModel()
        {
            EmailTo = "Edi.Wang@outlook.com";
            EmailSubject = "Hello From Edi.UWP.Helpers";
            EmailBody = "Hey";
            PhoneNumber = "10086";
            DisplayName = "SB Mobile";
            CommandShowEmailCompose = new RelayCommand(async () => await ShowEmailCompse());
            CommandOpenWebsite = new RelayCommand(async () => await Tasks.OpenWebsiteAsync("http://edi.wang"));
            CommandReview = new RelayCommand(async () => await Tasks.OpenStoreReviewAsync());
        }

        public string EmailTo
        {
            get => _emailTo;
            set
            {
                _emailTo = value;
                RaisePropertyChanged();
            }
        }

        public string EmailSubject
        {
            get => _emailSubject;
            set
            {
                _emailSubject = value;
                RaisePropertyChanged();
            }
        }

        public string EmailBody
        {
            get => _emailBody;
            set
            {
                _emailBody = value;
                RaisePropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                RaisePropertyChanged();
            }
        }

        public string DisplayName
        {
            get => _displayName;
            set
            {
                _displayName = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand CommandShowEmailCompose { get; set; }

        public RelayCommand CommandReview { get; set; }

        public RelayCommand CommandOpenWebsite { get; set; }

        public RelayCommand CommandCall { get; set; }

        private async Task ShowEmailCompse()
        {
            await Tasks.OpenEmailComposeAsync(EmailTo, EmailSubject, EmailBody);
        }
    }
}