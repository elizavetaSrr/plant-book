using Plugin.LocalNotification;
using System;

namespace PlantsBook.Push
{
    public static class PushNotificate
    {
        public static async void CreateNotification(int idPush, string namePlant, DateTime datePush, double pushPeriod)
        {
            
            NotificationRequest notification = new NotificationRequest
            {
                
                BadgeNumber = idPush,
                NotificationId = idPush,
                Title = namePlant + " нуждается в поливе",
                Description = "Полейте ваше растение",
                CategoryType = NotificationCategoryType.Reminder,

                Schedule =
                    {
                        NotifyTime = datePush,
                        RepeatType = NotificationRepeat.TimeInterval,
                        NotifyRepeatInterval = TimeSpan.FromDays(pushPeriod)
                        
                    },
                Android =
                {
                    
                    VisibilityType = Plugin.LocalNotification.AndroidOption.AndroidVisibilityType.Public,
                    Priority = Plugin.LocalNotification.AndroidOption.AndroidPriority.Max,
                    IconSmallName =
                    {
                        ResourceName = "leaves",
                    }
                }
            };
            await LocalNotificationCenter.Current.Show(notification);
        }
        public static void DeleteNotification(params int[] push)
        {
            LocalNotificationCenter.Current.Cancel(push[0]);
        }
        public static async void UpdateNotification(int id, double period, DateTime date, string namePlant)
        {
            //LocalNotificationCenter.Current.Clear(new int[] { id });
            NotificationRequest notification = new NotificationRequest
            {
                BadgeNumber = id,
                NotificationId = id,
                Title = namePlant + " нуждается в поливе",
                Description = "Полейте ваше растение",
                CategoryType = NotificationCategoryType.Reminder,
                Schedule =
                {
                    NotifyTime = date,
                    RepeatType = NotificationRepeat.TimeInterval,
                    NotifyRepeatInterval = TimeSpan.FromDays(period)

                },
                Android =
                {
                    VisibilityType = Plugin.LocalNotification.AndroidOption.AndroidVisibilityType.Public,
                    Priority = Plugin.LocalNotification.AndroidOption.AndroidPriority.Max,
                    IconSmallName =
                    {
                        ResourceName = "leaves",
                        
                    }
                }

            };
            await LocalNotificationCenter.Current.Show(notification);
        }
    }
}
