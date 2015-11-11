using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.System;

namespace Edi.UWP.Helpers
{
    public class Tasks
    {
        public static async Task OpenStoreReviewAsync()
        {
            var pfn = Package.Current.Id.FamilyName;
            await Launcher.LaunchUriAsync(new Uri("ms-windows-store://review/?PFN=" + pfn));
        }

        public static async Task OpenWebsiteAsync(string url)
        {
            await Launcher.LaunchUriAsync(new Uri(url, UriKind.Absolute));
        }

        public static async Task OpenEmailComposeAsync(string toAddress, string subject, string body)
        {
            var uri = new Uri(string.Format("mailto:?to={0}&subject={1}&body={2}", toAddress, subject, body), UriKind.Absolute);
            await Launcher.LaunchUriAsync(uri);
        }
    }
}
