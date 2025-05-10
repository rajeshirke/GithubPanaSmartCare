using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Controls;
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
    public class NewAddressViewModel : BaseViewModel
    {
        public string PageNavigateType { get; set; }
        public NewAddressViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () => {
                await BindingData();
                IsBusy = false;
            });
        }
        public NewAddressViewModel(INavigation navigation,string pageType) : base(navigation)
        {
            IsBusy = true;
            PageNavigateType = pageType;
            Device.BeginInvokeOnMainThread(async () => {
                await BindingData();
                IsBusy = false;
            });
        }
        public async Task BindingData()
        {
            try
            {
                if (Addresses == null)
                    Addresses = new AddressRequest();

                MasterDataManagementSL masterDataManagement = new MasterDataManagementSL();
                List<CountryResponse> countryResponses = await masterDataManagement.GetAllCountries();

                if (AllCountries == null)
                    AllCountries = new ObservableCollection<DropDownModel>();
                foreach (var item in countryResponses)
                {

                    DropDownModel dropDownModel = new DropDownModel();
                    dropDownModel.Id = item.CountryId;
                    dropDownModel.Title = item.Name;
                    dropDownModel.Desc = item.Iso;
                    if (item.Iso.ToLower() == CommonAttribute.UserLocation?.CountryCode?.ToLower())
                    {
                        SelectCountry = dropDownModel;
                    }
                    else if (item.CountryId == CommonAttribute.CustomeProfile.CountryId)
                    {
                        SelectCountry = dropDownModel;
                    }
                    AllCountries.Add(dropDownModel);

                }
            }
            catch (Exception ex)
            {

            }
            
        }
        public async Task<bool> Validation()
        {
          
            if (string.IsNullOrEmpty(BuildingName))
            {
                await ErrorDisplayAlert(AppResources.lblEnterBuildingName);
                return false;
            }
           
            if (string.IsNullOrEmpty(Area))
            {
                await ErrorDisplayAlert(AppResources.lblEnterArea);
                return false;
            }
            if (string.IsNullOrEmpty(City))
            {
                await ErrorDisplayAlert(AppResources.lblEnterCity);
                return false;
            }
            if (string.IsNullOrEmpty(State))
            {
                await ErrorDisplayAlert(AppResources.lblEnterState);
                return false;
            }
           
            
            //CountryName
            return true;
        }
        #region events
        //AddProductPage
       
     
        #endregion
        #region Properties
        public Command SaveAddressCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (await Validation())
                        {
                            AddressesSL addressesSL = new AddressesSL();

                            Addresses.CustomerId = CommonAttribute.CustomeProfile.PersonId;
                            Addresses.ApartmentNumber = ApartmentNumber;
                            Addresses.BuildingName = BuildingName;
                            Addresses.Street = Street;
                            Addresses.Area = Area;
                            Addresses.City = City;
                            Addresses.State = State;
                            Addresses.PostalCode = NewPostalCode;

                            Addresses.CountryId = SelectCountry.Id;
                            if (Addresses.IsPrimary == null)
                                Addresses.IsPrimary = false;
                            Addresses.CityId = null;
                            if (GPSAddres != null)
                            {
                                Addresses.Latitude = Convert.ToDecimal(GPSAddres.Position.Latitude);
                                Addresses.Longitude = Convert.ToDecimal(GPSAddres.Position.Longitude);
                            }
                            var receiveContext = await addressesSL.AddAddresses(Addresses);
                            if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
                            {
                                // await DisplayAlert("", receiveContext.message);
                                MessagingCenter.Send<NewAddressViewModel>(this, "UpdateAddress");
                                await Navigation.PopAsync();
                            }
                            else if (receiveContext != null)
                            {
                                await ErrorDisplayAlert(receiveContext.errorMessage);

                            }
                            else
                            {
                                await ErrorDisplayAlert(Resx.AppResources.lblErrorTitle);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    
                });
            }
        }
        public Command CountryChangeCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (AllCountries != null && AllCountries.Count > 0)
                        {
                            DropDownPopupPage dropDownPopup = new DropDownPopupPage();
                            dropDownPopup.Title = AppResources.lblSelectCountry;
                            if (SelectCountry != null)
                                dropDownPopup.Title = SelectCountry.Title;
                            dropDownPopup.DropDownSelectedItem += DropDownPopup_DropDownSelectedItem; ;
                            dropDownPopup.PickerItemsSource = AllCountries;
                            dropDownPopup.MasterData = AllCountries.ToList();
                            await PopupNavigation.PushAsync(dropDownPopup);
                            //SelectCountry = item;
                            //  Navigation.PushAsync(new ProductSuccessPage());
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                    
                });
            }
        }
        public Command PickAddressCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        // AddressPickFromMap addressPickFromMap = new AddressPickFromMap();
                        //  addressPickFromMap.PickerSelectedItem -= AddressPickFromMap_PickerSelectedItem;
                        // addressPickFromMap.PickerSelectedItem += AddressPickFromMap_PickerSelectedItem;
                        MessagingCenter.Unsubscribe<AddressPickFromMap, AddressesModel>(this, "PickAddress");
                        MessagingCenter.Subscribe<AddressPickFromMap, AddressesModel>(this, "PickAddress", (sender, arg) =>
                        {

                            Area = arg.SubArea;
                            Street = arg.Location;

                            City = arg.City;
                            State = arg.City;
                            BuildingName = arg.FlatNo;
                            // CountryName = arg.CountryName;
                            // NewPostalCode = arg.PostalCode;
                            SelectCountry = AllCountries.Where(u => u.Desc == arg.CountryCode).FirstOrDefault();
                            GPSAddres = arg;

                        });
                        await Navigation.PushAsync(new AddressPickFromMap());
                    }
                    catch (Exception ex)
                    {

                    }
                   
                });
            }
        }

        //private void AddressPickFromMap_PickerSelectedItem(object sender, EventArgs e)
        //{
        //    AddressesModel arg = sender as AddressesModel;

        //    Addresses.Area = arg.SubArea;
        //    Addresses.Street = arg.Location;

        //    Addresses.City = arg.City;
        //    Addresses.State = arg.City;
        //    Addresses.BuildingName = arg.FlatNo;
        //    CountryName = arg.CountryName;
        //    Addresses.Area = arg.Location;
        //    SelectCountry = AllCountries.Where(u => u.Desc == arg.CountryCode).FirstOrDefault();
        //    //  Addresses.CountryName = arg.CountryName;

        //    GPSAddres = arg;

        //}

        private void DropDownPopup_DropDownSelectedItem(object sender, EventArgs e)
        {
            DropDownPopupPage control = sender as DropDownPopupPage;
            SelectCountry = control.SelectedItem as DropDownModel;
        }
        private ObservableCollection<DropDownModel> _AllCountries;
        public ObservableCollection<DropDownModel> AllCountries
        {
            get { return _AllCountries; }
            set
            {
                _AllCountries = value;
                OnPropertyChanged("AllCountries");
            }
        }
        private DropDownModel _SelectCountry;
        public DropDownModel SelectCountry
        {
            get { return _SelectCountry; }
            set
            {
                _SelectCountry = value;
                OnPropertyChanged("SelectCountry");
            }
        }
        public AddressesModel GPSAddres { get; set; }
        private AddressRequest _Addresses;
        public AddressRequest Addresses
        {
            get { return _Addresses; }
            set
            {
                _Addresses = value;
                OnPropertyChanged("Addresses");
            }
        }
        //FloorNumber Name
        private bool _IsPrimary;
        public bool IsPrimary
        {
            get { return _IsPrimary; }
            set
            {
                _IsPrimary = value;
                OnPropertyChanged("IsPrimary");
            }
        }
        private string _ApartmentNumber;
        public string ApartmentNumber
        {
            get { return _ApartmentNumber; }
            set
            {
                _ApartmentNumber = value;
                OnPropertyChanged("ApartmentNumber");
            }
        }
       
        private string _BuildingName;
        public string BuildingName
        {
            get { return _BuildingName; }
            set
            {
                _BuildingName = value;
                OnPropertyChanged("BuildingName");
            }
        }
        private string _Street;
        public string Street
        {
            get { return _Street; }
            set
            {
                _Street = value;
                OnPropertyChanged("Street");
            }
        }
        private string _City;
        public string City
        {
            get { return _City; }
            set
            {
                _City = value;
                OnPropertyChanged("City");
            }
        }
        private string _Area;
        public string Area
        {
            get { return _Area; }
            set
            {
                _Area = value;
                OnPropertyChanged("Area");
            }
        }
        private string _State;
        public string State
        {
            get { return _State; }
            set
            {
                _State = value;
                OnPropertyChanged("State");
            }
        }
        private int? _NewPostalCode;
        public int? NewPostalCode
        {
            get { return _NewPostalCode; }
            set
            {
                _NewPostalCode = value;
                OnPropertyChanged("NewPostalCode");
            }
        }
        //PostalCode
        private string _CountryName;
        public string CountryName
        {
            get { return _CountryName; }
            set
            {
                _CountryName = value;
                OnPropertyChanged("CountryName");
            }
        }
        private string _ContactNo;
        public string ContactNo
        {
            get { return _ContactNo; }
            set
            {
                _ContactNo = value;
                OnPropertyChanged("ContactNo");
            }
        }
        private int _PostalCode;
        public int PostalCode
        {
            get { return _PostalCode; }
            set
            {
                _PostalCode = value;
                OnPropertyChanged("PostalCode");
            }
        }
        //PostalCode
        #endregion
    }
}
