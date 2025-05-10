using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.CommonPages
{
    public class NotificationsViewModel : BaseViewModel
    {
        public NotificationsViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () => {
                await BindingData();
                IsBusy = false;
            });
        }
        public async Task BindingData()
        {
            try
            {
                UserManagementSL userManagementSL = new UserManagementSL();
                List<PersonNotificationResponse> personNotifications = await userManagementSL.GetUnreadNotifications(CommonAttribute.CustomeProfile.PersonId);
                if (personNotifications != null && personNotifications.Count > 0)
                {
                    if (Notifications == null)
                        Notifications = new ObservableCollection<PersonNotificationResponse>();

                    Notifications = new ObservableCollection<PersonNotificationResponse>(personNotifications);
                }
            }
            catch (Exception ex)
            {

            }
           
        }
        public Command SelectedItemCommand
        {
            get
            {
                return new Command<PersonNotificationResponse>(async (item) =>
                {
                    try
                    {
                        IsBusy = true;
                        UserManagementSL userManagementSL = new UserManagementSL();
                        var personNotifications = await userManagementSL.UpdateNotificationReadDate(CommonAttribute.CustomeProfile.PersonId, item.NotificationId);
                        if (personNotifications)
                        {
                            await BindingData();
                        }
                        IsBusy = false;
                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                    
                });
            }
        }
        private ObservableCollection<PersonNotificationResponse> _Notifications;
        public ObservableCollection<PersonNotificationResponse> Notifications
        {
            get { return _Notifications; }
            set
            {
                _Notifications = value;
                OnPropertyChanged("Notifications");
            }
        }
    }
}
