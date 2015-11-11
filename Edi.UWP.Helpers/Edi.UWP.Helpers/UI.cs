using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Notifications;
using Windows.UI.ViewManagement;

namespace Edi.UWP.Helpers
{
    public class UI
    {
        public static void SetWindowLaunchSize(int height, int width)
        {
            ApplicationView.PreferredLaunchViewSize = new Size { Height = height, Width = width };
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        public static void ApplyColorToTitleBar(Color? titleBackgroundColor,
            Color? titleForegroundColor, 
            Color? titleInactiveBackgroundColor,
            Color? titleInactiveForegroundColor)
        {
            var view = ApplicationView.GetForCurrentView();

            // active
            view.TitleBar.BackgroundColor = titleBackgroundColor;
            view.TitleBar.ForegroundColor = titleForegroundColor;

            // inactive
            view.TitleBar.InactiveBackgroundColor = titleInactiveBackgroundColor;
            view.TitleBar.InactiveForegroundColor = titleInactiveForegroundColor;
        }

        public static void ApplyColorToTitleButton(Color? titleButtonBackgroundColor,
            Color? titleButtonForegroundColor,
            Color? titleButtonHoverBackgroundColor,
            Color? titleButtonHoverForegroundColor,
            Color? titleButtonPressedBackgroundColor,
            Color? titleButtonPressedForegroundColor,
            Color? titleButtonInactiveBackgroundColor,
            Color? titleButtonInactiveForegroundColor)
        {
            var view = ApplicationView.GetForCurrentView();

            // button
            view.TitleBar.ButtonBackgroundColor = titleButtonBackgroundColor;
            view.TitleBar.ButtonForegroundColor = titleButtonForegroundColor;

            view.TitleBar.ButtonHoverBackgroundColor = titleButtonHoverBackgroundColor;
            view.TitleBar.ButtonHoverForegroundColor = titleButtonHoverForegroundColor;

            view.TitleBar.ButtonPressedBackgroundColor = titleButtonPressedBackgroundColor;
            view.TitleBar.ButtonPressedForegroundColor = titleButtonPressedForegroundColor;

            view.TitleBar.ButtonInactiveBackgroundColor = titleButtonInactiveBackgroundColor;
            view.TitleBar.ButtonInactiveForegroundColor = titleButtonInactiveForegroundColor;
        }

        public enum NotificationAudioNames
        {
            Default,
            IM,
            Mail,
            Reminder,
            SMS,
            Looping_Alarm,
            Looping_Alarm2,
            Looping_Alarm3,
            Looping_Alarm4,
            Looping_Alarm5,
            Looping_Alarm6,
            Looping_Alarm7,
            Looping_Alarm8,
            Looping_Alarm9,
            Looping_Alarm10,
            Looping_Call,
            Looping_Call2,
            Looping_Call3,
            Looping_Call4,
            Looping_Call5,
            Looping_Call6,
            Looping_Call7,
            Looping_Call8,
            Looping_Call9,
            Looping_Call10,
        }

        public static void ShowToastNotification(string assetsImageFileName, string text, NotificationAudioNames audioName)
        {
            // 1. create element
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            // 2. provide text
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(text));

            // 3. provide image
            XmlNodeList toastImageAttributes = toastXml.GetElementsByTagName("image");
            ((XmlElement)toastImageAttributes[0]).SetAttribute("src", $"ms-appx:///assets/{assetsImageFileName}");
            ((XmlElement)toastImageAttributes[0]).SetAttribute("alt", "logo");

            // 4. duration
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "short");

            // 5. audio
            XmlElement audio = toastXml.CreateElement("audio");
            audio.SetAttribute("src", $"ms-winsoundevent:Notification.{audioName.ToString().Replace("_", ".")}");
            toastNode.AppendChild(audio);

            // 6. app launch parameter
            //((XmlElement)toastNode).SetAttribute("launch", "{\"type\":\"toast\",\"param1\":\"12345\",\"param2\":\"67890\"}");

            // 7. send toast
            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        public static void SetWindowsMobileStatusBarColor(Color? backgroundColor, Color? foregroundColor)
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                StatusBar statusBar = StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = backgroundColor;
                statusBar.ForegroundColor = foregroundColor;
                statusBar.BackgroundOpacity = 1;
            }
        }

        public static async Task HideWindowsMobileStatusBar()
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                await StatusBar.GetForCurrentView().HideAsync();
            }
        }
    }
}
