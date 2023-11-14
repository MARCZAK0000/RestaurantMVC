using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.MVC.Models;

namespace Restaurant.MVC.Extension
{
    public static class NotificationController
    {
        public static void SetNotification(this Controller controller, string type, string message)
        {
            var notifcation = new Notification(type, message);
            controller.TempData["Notification"] = JsonConvert.SerializeObject(notifcation);
        }
    }
}
