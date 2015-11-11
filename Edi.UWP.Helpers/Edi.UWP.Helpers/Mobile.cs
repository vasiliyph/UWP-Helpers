using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Phone.UI.Input;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Edi.UWP.Helpers
{
    public class Mobile
    {
        public static void SetWindowsMobileStatusBarColor(Color? backgroundColor, Color? foregroundColor)
        {
            UI.SetWindowsMobileStatusBarColor(backgroundColor, foregroundColor);
        }

        public static async Task HideWindowsMobileStatusBar()
        {
            await UI.HideWindowsMobileStatusBar();
        }

        public static void ExitOnBackPressed(Frame pageFrame, BackPressedEventArgs e)
        {
            e.Handled = true;

            if (!pageFrame.CanGoBack)
            {
                Application.Current.Exit();
            }
        }
    }
}
