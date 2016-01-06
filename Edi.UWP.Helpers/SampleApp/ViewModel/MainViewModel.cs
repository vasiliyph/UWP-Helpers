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
        private string _txtToCopy;
        private bool _hasInternetConnection;
        private string _phoneNumber;
        private string _displayName;

        public string EmailBody
        {
            get { return _emailBody; }
            set
            {
                _emailBody = value;
                RaisePropertyChanged();
            }
        }

        public string TxtToCopy
        {
            get { return _txtToCopy; }
            set { _txtToCopy = value; RaisePropertyChanged(); }
        }

        public bool HasInternetConnection
        {
            get { return _hasInternetConnection; }
            set { _hasInternetConnection = value; RaisePropertyChanged(); }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; RaisePropertyChanged(); }
        }

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; RaisePropertyChanged(); }
        }

        public RelayCommand CommandShowEmailCompose { get; set; }

        public RelayCommand CommandReview { get; set; }

        public RelayCommand CommandOpenWebsite { get; set; }

        public RelayCommand CommandCopy { get; set; }

        public RelayCommand CommandCall { get; set; }

        public MainViewModel()
        {
            EmailTo = "Edi.Wang@outlook.com";
            EmailSubject = "Hello From Edi.UWP.Helpers";
            EmailBody = "Hey";
            TxtToCopy = "Edi Wang";
            PhoneNumber = "10086";
            DisplayName = "SB Mobile";

            CommandShowEmailCompose = new RelayCommand(async ()=> await ShowEmailCompse());
            CommandReview = new RelayCommand(async ()=> await Edi.UWP.Helpers.Tasks.OpenStoreReviewAsync());
            CommandOpenWebsite = new RelayCommand(async () => await Edi.UWP.Helpers.Tasks.OpenWebsiteAsync("http://edi.wang"));
            CommandCopy = new RelayCommand(()=> Edi.UWP.Helpers.Utils.CopyToClipBoard(TxtToCopy));
            CommandCall = new RelayCommand(() => Edi.UWP.Helpers.Utils.MakePhoneCall(PhoneNumber, DisplayName));

            HasInternetConnection = Edi.UWP.Helpers.Utils.HasInternetConnection();
        }

        private async Task ShowEmailCompse()
        {
            await Edi.UWP.Helpers.Tasks.OpenEmailComposeAsync(EmailTo, EmailSubject, EmailBody);
        }
    }
}