﻿using System;
using eWarranty.DependencyServices;
using Xamarin.Forms;

namespace eWarranty.Hepler
{
    public interface INotificationHandler
    {
        //void ShowNotification();
        void SendNotification();
    }

    public class NotificationHandler : INotificationHandler
    {

        INotificationManager notificationManager;

        public NotificationHandler()
        {

            notificationManager = DependencyService.Get<INotificationManager>();
            notificationManager.NotificationReceived += (sender, eventArgs) =>
            {
                var evtData = (NotificationEventArgs)eventArgs;
                ShowNotification(evtData.Title, evtData.Message);
            };
        }

        void ShowNotification(string title, string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var msg = new Label()
                {
                    Text = $"Notification Received:\nTitle: {title}\nMessage: {message}"
                };
                //stackLayout.Children.Add(msg);
            });
        }

        //NotificQuestionnaireDetails notificQuestionnaireDetails;
        //NotificAttendanceDetailsCheckout notificAttendanceDetailsCheckout;
        //NotificSuperwisorSubmit notificSuperwisorSubmit;
        public void SendNotification()
        {
            //notificQuestionnaireDetails = new NotificQuestionnaireDetails(notificationManager);
            //notificAttendanceDetailsCheckout = new NotificAttendanceDetailsCheckout(notificationManager);
            //notificSuperwisorSubmit = new NotificSuperwisorSubmit(notificationManager);
        }
    }
}
