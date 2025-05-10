using System;
using System.Windows.Input;
using eWarranty.Views.Supervisor;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Supervisor
{
    public class SupLeftSideMenuViewModel : BaseViewModel
    {
        public Command ServicesCommand { get; set; }
        public Command AMCReqCommand { get; set; }
        public Command AccessoryReqCommand { get; set; }
        public Command PartStockReqCommand { get; set; }

        public SupLeftSideMenuViewModel(INavigation navigation) : base(navigation)
        {
            ServicesCommand = new Command(() =>
            {
                Shell.Current.FlyoutIsPresented = false;               
                Navigation.PushAsync(new ServiceRequestsListPage());
            });
            AMCReqCommand = new Command(() =>
            {
                Shell.Current.FlyoutIsPresented = false;
                Navigation.PushAsync(new AMCRequestsListPage());
            });
            AccessoryReqCommand = new Command(() =>
            {
                Shell.Current.FlyoutIsPresented = false;
                Navigation.PushAsync(new AccessoryRequestsListPage());
            });
            PartStockReqCommand = new Command(() =>
            {
                Shell.Current.FlyoutIsPresented = false;
                Navigation.PushAsync(new PartStockRequestsListPage());
            });
        }
    }
}

