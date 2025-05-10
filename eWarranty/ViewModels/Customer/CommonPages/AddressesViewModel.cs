using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Controls;
using eWarranty.Core.Common;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.Views.Customer.CommonPages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.CommonPages
{
    public class AddressesViewModel : BaseViewModel
    {
        public AddressesViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;
            DataBinding();
        }
        #region Methods
        public async Task DataBinding()
        {
            try
            {
                if (Addresses == null)
                    Addresses = new ObservableCollection<AddressResponse>();


                BtnHide = false;

                //AddNewAddress
                AddNewAddressCommand = new Command(() =>
                {
                    Navigation.PushAsync(new AddAddressesPage());
                });
                MessagingCenter.Unsubscribe<NewAddressViewModel>(this, "UpdateAddress");
                MessagingCenter.Subscribe<NewAddressViewModel>(this, "UpdateAddress", async (sender) =>
                {
                    IsBusy = true;
                    await GetAddress();
                    IsBusy = false;

                });
                await GetAddress();
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            
        }
        public async Task GetAddress()
        {
            try
            {
                AddressesSL addressesSL = new AddressesSL();
                List<AddressResponse> resAddress = await addressesSL.GetCustomerAddresses(CommonAttribute.CustomeProfile.PersonId);

                if (resAddress != null)
                {
                    Addresses.Clear();
                    foreach (var item in resAddress)
                    {
                        item.BgColor = "#707070";
                        Addresses.Add(item);


                    }
                    SelectedAddress = Addresses.Where(s => s.IsPrimary == true).FirstOrDefault();
                    // Addresses = new ObservableCollection<AddressResponse>(resAddress.OrderBy(u => u.IsPrimary));
                }
            }
            catch (Exception ex)
            {

            }
            
        }
        #endregion
        #region events
        //AddProductPage
        public ICommand AddNewAddressCommand { get; set; }

        #endregion
        #region Properties

        private bool  _BtnHide;
        public bool BtnHide
        {
            get { return _BtnHide; }
            set
            {
                _BtnHide = value;
                OnPropertyChanged("BtnHide");
            }
        }
        private AddressResponse _SelectedAddress;
        public AddressResponse SelectedAddress
        {
            get { return _SelectedAddress; }
            set
            {
                _SelectedAddress = value;
                if (value != null)
                {
                    _SelectedAddress.BgColor = "#FFFFFF";
                    BtnHide = true;
                }
                   
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
        public Command UpdateAddressCommand
        {
            get
            {
                return new Command<AddressResponse>(async (item) =>
                {
                    try
                    {
                        IsBusy = true;
                        AddressesSL addressesSL = new AddressesSL();
                        AddressRequest addressRequest = new AddressRequest();
                        addressRequest.AddressId = item.AddressId;
                        addressRequest.CustomerId = CommonAttribute.CustomeProfile.PersonId;
                        addressRequest.IsPrimary = true;
                        addressRequest.CityId = null;
                        APIResponse resAddress = await addressesSL.UpdateAddress(item.AddressId, addressRequest);
                        if (resAddress != null && resAddress.Status == Convert.ToInt16(APIResponseEnum.Success))
                        {
                            string msg = CommonFunctions.GetMessagesByLanguage(resAddress, CommonAttribute.selectedLang.lid);
                            await DisplayAlert("", msg);
                            await GetAddress();
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
        #endregion
    }
}
