using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.UI.Xaml;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MauiApp2.WinUI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : MauiWinUIApplication
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            // need to add this because otherwise setting background activation does nothing.
            ToastNotificationManagerCompat.OnActivated += (notificationArgs) =>
            {
                // this will run everytime ToastNotification.Activated is called,
                // regardless of what toast is clicked and what element is clicked on.
                // Works for all types of ToastActivationType so long as the Windows app manifest
                // has been updated to support ToastNotifications. 

                // you can check your args here, however I'll be doing mine below to keep it cleaner.
                // With so many ToastNotifications it would be messy to check all of them here.

                Debug.WriteLine($"A ToastNotification was just activated! Arguments: {notificationArgs.Argument}");

                //// using the code below to show a popup from MainPage, saying that the toast itself was clicked.
                //if (notificationArgs.Argument.Contains("action=toastClicked"))
                //    ShowPopup?.Invoke("The Toast was clicked!");
            };
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }

}
