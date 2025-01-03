using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.Services
{
    public interface ILocalNotification
    {
        string NotificationIdentifier { get; set; }
        void RequestNotificationPermission();
        void ScheduleNotification(string identifier, string title, string body, DateTime? dateTime);
        //void RemovePendingNotification(string identifier);
        //void RemoveAllPendingNotifications();
        void RemoveDeliveredNotification(string identifier);
        void RemoveAllDeliveredNotifications();
    }
}
