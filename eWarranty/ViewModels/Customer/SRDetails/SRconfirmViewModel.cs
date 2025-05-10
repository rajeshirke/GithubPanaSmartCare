using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.ViewModels.Customer.CommonPages;
using eWarranty.Views.Customer.CommonPages;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.SRDetails
{
    public class SRconfirmViewModel : BaseViewModel
    {
        public SRconfirmViewModel(INavigation navigation, AddServicesRequestViewModel viewModel) : base(navigation)
        {
            SDDate = DateTime.Now;
            SDTimeSpan = new TimeSpan(9,00,0);
            //MaxDate = DateTime.Today.AddDays(10);
            MinDate = DateTime.Today;
            serviceRequest = viewModel;
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () => {
                await GetAddress();
                IsBusy = false;
            });
            MessagingCenter.Unsubscribe<NewAddressViewModel>(this, "UpdateAddress");
            MessagingCenter.Subscribe<NewAddressViewModel>(this, "UpdateAddress", async (sender) =>
            {
                IsBusy = true;
                await GetAddress();
                IsBusy = false;

            });
        }
        public async Task GetAddress()
        {
            try
            {
                if (serviceRequest.ServiceLocationId)
                    ServiceLocation = "Service Center Repair";
                else
                    ServiceLocation = "Home";

                if (Addresses == null)
                    Addresses = new ObservableCollection<AddressResponse>();
                Addresses.Clear();
                AddressesSL addressesSL = new AddressesSL();
                List<AddressResponse> resAddress = await addressesSL.GetCustomerAddresses(CommonAttribute.CustomeProfile.PersonId);
                if (resAddress != null)
                {
                    foreach (var item in resAddress)
                    {
                       // item.BgColor = "#FFFFFF";
                        Addresses.Add(item);
                    }

                    // Addresses = new ObservableCollection<Address>(resAddress.OrderBy(u => u.IsPrimary));
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
        }
        private DateTime _SDDate;
        public DateTime SDDate
        {
            get { return _SDDate; }
            set
            {

                _SDDate = value;
                OnPropertyChanged("SDDate");
            }
        }
        private TimeSpan _SDTimeSpan;
        public TimeSpan SDTimeSpan
        {
            get { return _SDTimeSpan; }
            set
            {
                _SDTimeSpan = value;
                OnPropertyChanged(nameof(SDTimeSpan));
            }
        }
        private DateTime _MaxDate;
        public DateTime MaxDate
        {
            get { return _MaxDate; }
            set
            {

                _MaxDate = value;
                OnPropertyChanged("MaxDate");
            }
        }
        private DateTime _MinDate;
        public DateTime MinDate
        {
            get { return _MinDate; }
            set
            {

                _MinDate = value;
                OnPropertyChanged("MinDate");
            }
        }
        public Command NewAddressCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new AddAddressesPage());

                });
            }
        }
        public Command EditCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PopAsync();

                });
            }
        }
        private string _ServiceLocation;
        public string ServiceLocation
        {
            get { return _ServiceLocation; }
            set
            {

                _ServiceLocation = value;
                OnPropertyChanged("ServiceLocation");
            }
        }
        //Address
        private AddressResponse _SelectedAddress;
        public AddressResponse SelectedAddress
        {
            get { return _SelectedAddress; }
            set
            {
                _SelectedAddress = value;
                OnPropertyChanged("SelectedAddress");
            }
        }
        private ObservableCollection<AddressResponse> _Addresses;
        public ObservableCollection<AddressResponse> Addresses
        {
            get { return _Addresses; }
            set
            {
                _Addresses = value;
                OnPropertyChanged("Addresses");
            }
        }
        private AddServicesRequestViewModel _serviceRequest;
        public AddServicesRequestViewModel serviceRequest
        {
            get { return _serviceRequest; }
            set
            {
                _serviceRequest = value;
                OnPropertyChanged("serviceRequest");
            }
        }
    }
}
