using System;
using System.Windows.Input;
using eWarranty.Views.Customer.CommonPages;
using eWarranty.Views.Supervisor;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Supervisor
{
    public class SupDashboardTileViewModel : BaseViewModel
    {
        public ICommand ServicesCommand { get; set; }
        public ICommand AMCReqCommand { get; set; }
        public ICommand AccessoryReqCommand { get; set; }
        public ICommand PartStockReqCommand { get; set; }

        public SupDashboardTileViewModel(INavigation navigation) : base(navigation)
        {
            SelectedDate = DateTime.Now;
            ServicesCommand = new Command(() =>
            {
                Navigation.PushAsync(new ServiceRequestsListPage());
            });
            AMCReqCommand = new Command(() =>
            {
                Navigation.PushAsync(new AMCRequestsListPage());
            });
            AccessoryReqCommand = new Command(() =>
            {
                Navigation.PushAsync(new AccessoryRequestsListPage());
            });
            PartStockReqCommand = new Command(() =>
            {
                Navigation.PushAsync(new PartStockRequestsListPage());
            });
        }

        public Command UserNotificationsCommand
        {
            get
            {
                return new Command(() =>
                {

                    Navigation.PushAsync(new UserNotificationsPage());
                });
            }
        }


        private DateTime _SelectedDate;
        public DateTime SelectedDate
        {
            get { return _SelectedDate; }
            set
            {
                _SelectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
            }
        }
    }
}

