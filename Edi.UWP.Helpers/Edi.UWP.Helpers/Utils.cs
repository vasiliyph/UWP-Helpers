using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;

namespace Edi.UWP.Helpers
{
    public class Utils
    {
        public static void CopyToClipBoard(string str)
        {
            var dp = new DataPackage
            {
                RequestedOperation = DataPackageOperation.Copy,
            };
            dp.SetText(str);
            Clipboard.SetContent(dp);
        }

        public string GetAppVersion()
        {
            var ver = Windows.ApplicationModel.Package.Current.Id.Version;
            return $"{ver.Major}.{ver.Minor}.{ver.Build}.{ver.Revision}";
        }

        public Uri GetAppLogoUri() => Windows.ApplicationModel.Package.Current.Logo;

        public string GetAppDisplayName() => Windows.ApplicationModel.Package.Current.DisplayName;

        public string GetAppPublisher() => Windows.ApplicationModel.Package.Current.PublisherDisplayName;
    }
}
