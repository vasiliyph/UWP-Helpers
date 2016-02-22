using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Edi.UWP.Helpers.SampleApp.ViewModel
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
        private string _xmlResult;
        private string _resOutput;

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

        public string XmlResult
        {
            get { return _xmlResult; }
            set { _xmlResult = value; RaisePropertyChanged(); }
        }

        public string ResOutput
        {
            get { return _resOutput; }
            set { _resOutput = value; RaisePropertyChanged(); }
        }

        public RelayCommand CommandShowEmailCompose { get; set; }

        public RelayCommand CommandReview { get; set; }

        public RelayCommand CommandOpenWebsite { get; set; }

        public RelayCommand CommandCopy { get; set; }

        public RelayCommand CommandCall { get; set; }

        public RelayCommand CommandReadXml { get; set; }

        public RelayCommand CommandGetResource { get; set; }

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
            CommandReadXml = new RelayCommand(async () => await ReadXml());
            
            // this blow up
            //CommandGetResource = new RelayCommand(() =>
            //{
            //    ResOutput = Edi.UWP.Helpers.Utils.GetResource("TestRes1");
            //});

            HasInternetConnection = Edi.UWP.Helpers.Utils.HasInternetConnection();
        }

        private async Task ReadXml()
        {
            var xml = await Edi.UWP.Helpers.Utils.GetXmlStringAsync("test.xml");
            XmlResult = xml;
        }

        private async Task ShowEmailCompse()
        {
            await Edi.UWP.Helpers.Tasks.OpenEmailComposeAsync(EmailTo, EmailSubject, EmailBody);
        }
    }
}