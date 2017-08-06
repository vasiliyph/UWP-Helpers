using System;
using System.Threading.Tasks;
using Edi.UWP.Helpers.ChineseEncoding;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Edi.UWP.Helpers.Sample.ViewModels
{
    public class UtilsViewModel : ViewModelBase
    {
        private string _txtToCopy;
        private bool _hasInternetConnection;

        private string _xmlResult;

        public bool HasInternetConnection
        {
            get => _hasInternetConnection;
            set { _hasInternetConnection = value; RaisePropertyChanged(); }
        }

        public string XmlResult
        {
            get => _xmlResult;
            set { _xmlResult = value; RaisePropertyChanged(); }
        }

        public string TxtToCopy
        {
            get => _txtToCopy;
            set { _txtToCopy = value; RaisePropertyChanged(); }
        }

        private string _resOutput;
        private string _appVersion;
        private string _appDisplayName;

        public string ResOutput
        {
            get => _resOutput;
            set { _resOutput = value; RaisePropertyChanged(); }
        }

        public string AppVersion
        {
            get => _appVersion;
            set { _appVersion = value; RaisePropertyChanged(); }
        }

        public string AppDisplayName
        {
            get => _appDisplayName;
            set { _appDisplayName = value; RaisePropertyChanged(); }
        }

        public RelayCommand CommandGetResource { get; set; }

        public RelayCommand CommandGetAppVersion { get; set; }

        public RelayCommand CommandGetAppDisplayName { get; set; }

        public RelayCommand CommandReadXml { get; set; }

        public RelayCommand CommandCopy { get; set; }

        public UtilsViewModel()
        {
            TxtToCopy = "Edi Wang";
            CommandReadXml = new RelayCommand(async () => await ReadXml());
            CommandCopy = new RelayCommand(() => Utils.CopyToClipBoard(TxtToCopy));
            HasInternetConnection = Utils.HasInternetConnection();

            CommandGetAppVersion = new RelayCommand(() =>
            {
                AppVersion = Utils.GetAppVersion();
            });
            CommandGetAppDisplayName = new RelayCommand(() =>
            {
                AppDisplayName = Utils.GetAppDisplayName();
            });
        }

        private async Task ReadXml()
        {
            var xml = await Utils.GetXmlStringAsync("test.xml");
            XmlResult = xml;
        }
    }
}
