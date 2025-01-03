using MauiApp2.Services;
using Microsoft.Toolkit.Uwp.Notifications;

namespace MauiApp2.Platforms.Windows
{
    public class LocalNotification : ILocalNotification
    {
        public string NotificationIdentifier { get; set; }

        public void RequestNotificationPermission()
        {
            // Auf Windows ist keine explizite Berechtigung erforderlich
            Console.WriteLine("No permission request needed for Windows notifications.");
        }

        public void ScheduleNotification(string identifier, string title, string body, DateTime? dateTime)
        {
            try
            {
                string group = "test";
                ToastNotificationManagerCompat.History.Remove(identifier, group);

                if (dateTime != null)
                {
                    new ToastContentBuilder()
                        .AddArgument("action", "viewConversation")
                        .AddArgument("conversationId", 9813)
                        .AddToastActivationInfo(null, ToastActivationType.Foreground)
                        .AddText(title, hintStyle: AdaptiveTextStyle.Header)
                        .AddText(body, hintStyle: AdaptiveTextStyle.Body)
                        .SetBackgroundActivation()
                        .Schedule((DateTimeOffset)dateTime.Value, t =>
                        {
                            t.ExpirationTime = dateTime.Value.AddDays(1);
                            t.Tag = identifier;
                            t.Group = group;
                        });
                }
                else
                {
                    new ToastContentBuilder()
                        .AddArgument("action", "viewConversation")
                        .AddToastActivationInfo(null, ToastActivationType.Foreground)
                        .AddText(title, hintStyle: AdaptiveTextStyle.Header)
                        .AddText(body, hintStyle: AdaptiveTextStyle.Body)
                        .SetBackgroundActivation()
                        .Show(t =>
                        {
                            t.ExpirationTime = DateTime.Now.AddDays(1);
                            t.Tag = identifier;
                            t.Group = group;
                        });
                }
            }
            catch (Exception ex)
            {
                //// Fangen Sie die Ausnahme und geben Sie detaillierte Informationen aus
                //Console.WriteLine($"Error scheduling notification: {ex.Message}");
                //if (ex.InnerException != null)
                //{
                //    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                //}
                //throw;
            }
        }

        //public void RemovePendingNotification(string identifier)
        //{
        //    var notifier = ToastNotificationManager.CreateToastNotifier();
        //    var scheduled = notifier.GetScheduledToastNotifications();

        //    foreach (var toast in scheduled)
        //    {
        //        if (toast.Id == identifier)
        //        {
        //            notifier.RemoveFromSchedule(toast);
        //        }
        //    }
        //}

        //public void RemoveAllPendingNotifications()
        //{
        //    var notifier = ToastNotificationManager.CreateToastNotifier();
        //    var scheduled = notifier.GetScheduledToastNotifications();

        //    foreach (var toast in scheduled)
        //    {
        //        notifier.RemoveFromSchedule(toast);
        //    }
        //}

        public void RemoveDeliveredNotification(string identifier)
        {
            Console.WriteLine("Windows Toast API does not directly support removing delivered notifications.");
        }

        public void RemoveAllDeliveredNotifications()
        {
            Console.WriteLine("Windows Toast API does not directly support clearing all delivered notifications.");
        }
    }
}
