using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
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
using eWarranty.Views.Account;
using eWarranty.Views.Customer;
using eWarranty.Views.Customer.CommonPages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Extensions = eWarranty.Hepler.Extensions;

namespace eWarranty.ViewModels.Customer.ProfileView
{
    public class MyProfileViewModel : BaseViewModel
    {
        public MyProfileViewModel(INavigation navigation) : base(navigation)
        {
            try
            {
                IsBusy = true;
                Device.BeginInvokeOnMainThread(async () => {
                    await BindingData();
                    await GetCountries();
                    await GetNationality();
                    IsBusy = false;
                });
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
           
           
        }
        public async Task BindingData()
        {
            try
            {
                if (Addresses == null)
                    Addresses = new AddressRequest();

                languages = Extensions.Getlanguages();
                if (!string.IsNullOrEmpty(CommonAttribute.CustomeProfile.AlternateMobileNumber))
                {
                    AlternateNumber = CommonAttribute.CustomeProfile?.MobileNumber; //CommonAttribute.CustomeProfile.AlternateMobileNumber.Remove(0, 3);
                }
                AlternateNumber = CommonAttribute.CustomeProfile?.MobileNumber;
                SelectedLanguage = CommonAttribute.selectedLang;
                Email = CommonAttribute.CustomeProfile.Email;
                PhoneCode = CommonAttribute.CustomeProfile?.PhoneCode;
                MobileNumber = PhoneCode + " " + CommonAttribute.CustomeProfile?.MobileNumber;

                Name = CommonAttribute.CustomeProfile.FirstName + "" + CommonAttribute.CustomeProfile.LastName;
                

            }
            catch (Exception ex)
            {

            }
           
        }

        public async Task AddNewFieldMethod()
        {

            try
            {
                IsBusy = true;
                if (!string.IsNullOrEmpty(AddNewValue))
                {
                    
                    
                }
                else
                {
                    await DisplayAlert("Alert!", "Kindly provide a value to proceed.");
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;

            }
            finally
            {
                IsBusy = false;

            }
        }

        public async Task GetNationality()
        {
            try
            {
                MasterDataManagementSL dataManagementSL = new MasterDataManagementSL();
                AllNationality = new ObservableCollection<DropDownModel>();

                NationalityResponses = await dataManagementSL.GetActiveCountryList();
                if (AllNationality == null)
                    AllNationality = new ObservableCollection<DropDownModel>();
                foreach (var item in CountryResponses)
                {

                    DropDownModel dropDownModel = new DropDownModel();
                    dropDownModel.Id = item.CountryId;
                    dropDownModel.Title = item.Name;
                    dropDownModel.Desc = item.Iso;
                    if (AllNationality.Any(p => p.Id == item.CountryId && p.Title == item.Name))
                    {
                        AllNationality.Remove(dropDownModel);
                    }
                    else
                    {
                        AllNationality.Add(dropDownModel);
                    }
                }
                AllNationality.OrderBy(p => p.Id).Distinct().GroupBy(p => p.Id);

            }
            catch (Exception ex)
            {

            }
        }

        public async Task GetAreaByCity()
        {
            try
            {
                MasterDataManagementSL dataManagementSL = new MasterDataManagementSL();
                AllAreas = new ObservableCollection<DropDownModel>();

                AreaResponses = await dataManagementSL.GetAreaByCityId((long)(SelectCity?.Id));
                if (AllAreas == null)
                    AllAreas = new ObservableCollection<DropDownModel>();
                foreach (var item in AreaResponses)
                {

                    DropDownModel dropDownModel = new DropDownModel();
                    dropDownModel.Id = item.Id;
                    dropDownModel.Title = item.Name;
                    if (AllAreas.Any(p => p.Id == item.Id && p.Title == item.Name))
                    {
                        AllAreas.Remove(dropDownModel);
                    }
                    else
                    {
                        AllAreas.Add(dropDownModel);
                    }
                }
                AllAreas.OrderBy(p => p.Id).Distinct().GroupBy(p => p.Id);

            }
            catch (Exception ex)
            {

            }
        }

        public async Task GetCountries()
        {
            try
            {
                string phone_code = CommonAttribute.CustomeProfile?.PhoneCode.Replace("+", "");
                int _phoneCode = Convert.ToInt32(phone_code);

                MasterDataManagementSL dataManagementSL = new MasterDataManagementSL();
                AllCountries = new ObservableCollection<DropDownModel>();
                CountryResponses = await dataManagementSL.GetActiveCountryList();
                if (AllCountries == null)
                    AllCountries = new ObservableCollection<DropDownModel>();
                foreach (var item in CountryResponses)
                {

                    DropDownModel dropDownModel = new DropDownModel();
                    dropDownModel.Id = item.CountryId;
                    dropDownModel.Title = item.Name;
                    dropDownModel.Desc = item.Iso;
                    if (item.PhoneCode == _phoneCode)
                    {
                        SelectCountry = dropDownModel;
                        SelectedCountryResponse = item;
                    }
                    if (AllCountries.Any(p => p.Id == item.CountryId && p.Title == item.Name))
                    {
                        AllCountries.Remove(dropDownModel);
                    }
                    else
                    {
                        AllCountries.Add(dropDownModel);
                    }
                }
                AllCountries.OrderBy(p => p.Id).Distinct().GroupBy(p => p.Id);
                if (SelectCountry != null && SelectCountry.Id != 0)
                {
                    await GetCities();
                }

            }
            catch (Exception ex)
            {

            }
        }

        public async Task GetCities()
        {
            try
            {
                MasterDataManagementSL dataManagementSL = new MasterDataManagementSL();
                AllCities = new ObservableCollection<DropDownModel>();

                CityResponses = await dataManagementSL.GetCitiesByCountryId(SelectCountry.Id);
                if (AllCities == null)
                    AllCities = new ObservableCollection<DropDownModel>();
                foreach (var item in CityResponses)
                {

                    DropDownModel dropDownModel = new DropDownModel();
                    dropDownModel.Id = item.Id;
                    dropDownModel.Title = item.Name;
                    if (AllCities.Any(p => p.Id == item.Id && p.Title == item.Name))
                    {
                        AllCities.Remove(dropDownModel);
                    }
                    else
                    {
                        AllCities.Add(dropDownModel);
                    }
                }
                AllCities.OrderBy(p => p.Id).Distinct().GroupBy(p => p.Id);

            }
            catch (Exception ex)
            {

            }
        }

        public Command UpdateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (string.IsNullOrEmpty(AlternateNumber))
                        {
                            await ErrorDisplayAlert(AppResources.lblPleaseenteralternatenumber);
                            return;
                        }
                        //if (string.IsNullOrEmpty(Name))
                        //{
                        //  await  ErrorDisplayAlert("Please enter full name.");
                        //    return;
                        //}
                        //if (string.IsNullOrEmpty(AlternateNumber))
                        //{
                        //    await ErrorDisplayAlert("Please enter alternate number.");
                        //    return;
                        //}
                        //if (await Validation())
                        //{
                        string fname = string.Empty;
                        string lname = "";
                        string[] names = Name.Split(' ');
                        if (names.Length != 0)
                            fname = names[0];

                        for (int i = 1; i < names.Length; i++)
                        {
                            lname = lname + names[i];
                        }
                        UserManagementSL userManagement = new UserManagementSL();
                        PersonUpdateRequest personUpdate = new PersonUpdateRequest();
                        personUpdate.PersonId = CommonAttribute.CustomeProfile.PersonId;
                        personUpdate.CountryId = 0;
                        personUpdate.Email = "";
                        personUpdate.MobileNumber = "";
                        personUpdate.FirstName = fname;
                        personUpdate.LastName = lname;
                        personUpdate.Salutation = 0;
                        if (SelectedLanguageType != null)
                            personUpdate.PreferredLanguageId = SelectedLanguageType.Id;
                        // personUpdate.PreferredLanguageId = CommonAttribute.selectedLang.lid;
                        personUpdate.AlternateMobileNumber = PhoneCode + AlternateNumber?.Trim();
                        APIResponse aPIResponse = await userManagement.UpdatePersonDetails(personUpdate);
                        if (aPIResponse?.Status == Convert.ToInt16(APIResponseEnum.Success))
                        {
                            CommonAttribute.CustomeProfile.AlternateMobileNumber = personUpdate.AlternateMobileNumber;

                            string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                            await DisplayAlert(AppResources.lblSuccess, msg); //"Updated Successfully."
                        }
                        else
                        {
                            if (aPIResponse != null)
                            {
                                string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);

                                await Application.Current.MainPage.DisplayAlert("", msg, AppResources.lblCancel);
                            }

                            else
                            {
                                await ErrorDisplayAlert(AppResources.lblAPIError);
                            }
                        }
                        //  }
                    }
                    catch (Exception ex)
                    {

                    }
                    

                });
            }
        }

        public Command ProfileUpdateCommand2
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        //if (string.IsNullOrEmpty(Name))
                        //{
                        //    await ErrorDisplayAlert("Please enter full name.");
                        //    return;
                        //}

                        if (string.IsNullOrEmpty(AlternateNumber))
                        {
                            AlternateNumber = "";
                        }
                        string fname = string.Empty;
                        string lname = "";
                        string[] names = Name.Split(' ');
                        if (names.Length != 0)
                            fname = names[0];

                        for (int i = 1; i < names.Length; i++)
                        {
                            lname = lname + names[i];
                        }
                        UserManagementSL userManagement = new UserManagementSL();
                        PersonUpdateRequest personUpdate = new PersonUpdateRequest();
                        personUpdate.PersonId = CommonAttribute.CustomeProfile.PersonId;
                        personUpdate.CountryId = 0;
                        personUpdate.Email = "";
                        personUpdate.MobileNumber = "";
                        personUpdate.FirstName = fname;
                        personUpdate.LastName = lname;
                        personUpdate.Salutation = 0;
                        if (SelectedLanguageType != null)
                            personUpdate.PreferredLanguageId = SelectedLanguageType.Id;
                        // personUpdate.PreferredLanguageId = CommonAttribute.selectedLang.lid;
                        if (!string.IsNullOrEmpty(AlternateNumber))
                            personUpdate.AlternateMobileNumber = PhoneCode + AlternateNumber.Trim();
                        APIResponse aPIResponse = await userManagement.UpdatePersonDetails(personUpdate);
                        if (aPIResponse?.Status == Convert.ToInt16(APIResponseEnum.Success))
                        {
                            if (!string.IsNullOrEmpty(AlternateNumber))
                                CommonAttribute.CustomeProfile.AlternateMobileNumber = AlternateNumber.Trim();
                            //await Navigation.PushAsync(new RegSuccessView());
                            Application.Current.MainPage = new DashBoadMasterPage();
                        }
                        else
                        {
                            if (aPIResponse != null)
                            {
                                string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                                await Application.Current.MainPage.DisplayAlert("", msg, AppResources.lblCancel);
                            }


                            else
                            {
                                await ErrorDisplayAlert(AppResources.lblAPIError);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    

                });
            }
        }

        async Task<bool> Validation()
        {
            try
            {
                if (string.IsNullOrEmpty(SelectNationality.Title))
                {
                    await ErrorDisplayAlert("Kindly choose your nationality to proceed.");
                    return false;
                }
                if (string.IsNullOrEmpty(SelectCountry.Title))
                {
                    await ErrorDisplayAlert("Kindly choose country to proceed.");
                    return false;
                }
                if (string.IsNullOrEmpty(SelectCity.Title))
                {
                    await ErrorDisplayAlert("Kindly choose your desired city to proceed.");
                    return false;
                }
                if (string.IsNullOrEmpty(SelectArea.Title))
                {
                    await ErrorDisplayAlert("Kindly choose your desired area to proceed.");
                    return false;
                }                
                if (string.IsNullOrEmpty(ApartmentNumber))
                {
                    await ErrorDisplayAlert("Kindly enter apartment/house no. to proceed.");
                    return false;
                }
                if (string.IsNullOrEmpty(BuildingName))
                {
                    await ErrorDisplayAlert("Kindly enter building name to proceed.");
                    return false;
                }
                if (string.IsNullOrEmpty(PostalCode.ToString()))
                {
                    await ErrorDisplayAlert("Kindly enter postal code to proceed.");
                    return false;
                }

            }
            catch (Exception ex)
            {

            }
            return true;
        }

        public Command ProfileUpdateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        await SaveAddress();
                        if (await Validation())
                        {
                            if (string.IsNullOrEmpty(AlternateNumber))
                            {
                                AlternateNumber = "";
                            }
                            string fname = string.Empty;
                            string lname = "";
                            string[] names = Name.Split(' ');
                            if (names.Length != 0)
                                fname = names[0];

                            for (int i = 1; i < names.Length; i++)
                            {
                                lname = lname + names[i];
                            }
                            UserManagementSL userManagement = new UserManagementSL();
                            PersonUpdateRequest personUpdate = new PersonUpdateRequest();
                            personUpdate.PersonId = (long)(CommonAttribute.CustomeProfile?.PersonId);
                            personUpdate.CountryId = SelectCountry?.Id;
                            personUpdate.AreaId = SelectArea?.Id;
                            personUpdate.Email = CommonAttribute.CustomeProfile?.Email;
                            personUpdate.NationalityId = SelectNationality?.Id;
                            personUpdate.CityId = SelectCity?.Id;
                            personUpdate.MobileNumber = CommonAttribute.CustomeProfile?.MobileNumber;
                            personUpdate.FirstName = fname;
                            personUpdate.LastName = lname;
                            personUpdate.Salutation = 0;

                            if (SelectedLanguageType != null)
                                personUpdate.PreferredLanguageId = SelectedLanguageType.Id;
                            // personUpdate.PreferredLanguageId = CommonAttribute.selectedLang.lid;
                            if (!string.IsNullOrEmpty(AlternateNumber))
                                personUpdate.AlternateMobileNumber = PhoneCode + AlternateNumber.Trim();
                            APIResponse aPIResponse = await userManagement.UpdatePersonDetails(personUpdate);
                            if (aPIResponse?.Status == Convert.ToInt16(APIResponseEnum.Success))
                            {
                                if (!string.IsNullOrEmpty(AlternateNumber))
                                    CommonAttribute.CustomeProfile.AlternateMobileNumber = AlternateNumber.Trim();
                                //Application.Current.MainPage = new DashBoadMasterPage();
                                await Navigation.PushAsync(new RegSuccessView());

                            }
                            else
                            {
                                if (aPIResponse != null)
                                {
                                    string msg = CommonFunctions.GetMessagesByLanguage(aPIResponse, CommonAttribute.selectedLang.lid);
                                    await Application.Current.MainPage.DisplayAlert("", msg, AppResources.lblCancel);
                                }
                                else
                                {
                                    await ErrorDisplayAlert(AppResources.lblAPIError);
                                }
                            }
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
                        AddressPickFromMap addressPickFromMap = new AddressPickFromMap();
                        addressPickFromMap.PickerSelectedItem += AddressPickFromMap_PickerSelectedItem;

                        await Navigation.PushAsync(addressPickFromMap);
                    }
                    catch (Exception ex)
                    {

                    }
                    

                });
            }
        }

        private void AddressPickFromMap_PickerSelectedItem(object sender, EventArgs e)
        {
            try
            {
                var arg = sender as AddressesModel;
                Area = arg.SubArea;
                Street = arg.Location;

                City = arg.City;
                State = arg.City;
                BuildingName = arg.FlatNo;
                // CountryName = arg.CountryName;
                // NewPostalCode = arg.PostalCode;
                SelectCountry = AllCountries.Where(u => u.Desc == arg.CountryCode).FirstOrDefault();
                GPSAddres = arg;
            }
            catch (Exception ex)
            {

            }
           

        }

        public Command SkipCommand
        {
            get
            {
                return new Command(async () =>
                {
                    //Application.Current.MainPage = new DashBoadMasterPage();
                    await Navigation.PushAsync(new RegSuccessView());

                });
            }
        }
        public Command LonguageChangeCommand
        {
            get
            {
                return new Command<DropDownModel>(async (Item) =>
                {
                    SelectedLanguageType = Item;
                });
            }
        }

        [Obsolete]
        public Command AreaChangeCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (AllAreas != null && AllAreas.Count > 0)
                        {
                            DropDownPopupPage dropDownPopup = new DropDownPopupPage();
                            dropDownPopup.Title = "Areas";
                            dropDownPopup.DropDownSelectedItem += DropDownPopup_DropDownSelectedItemArea;
                            dropDownPopup.PickerItemsSource = AllAreas;
                            dropDownPopup.MasterData = AllAreas.ToList();
                            await PopupNavigation.PushAsync(dropDownPopup);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                   

                });
            }
        }
        private async void DropDownPopup_DropDownSelectedItemArea(object sender, EventArgs e)
        {
            DropDownPopupPage control = sender as DropDownPopupPage;
            SelectArea = control.SelectedItem as DropDownModel;
            SelectedAreaResponse = AreaResponses.Where(u => u.Id == SelectArea.Id).FirstOrDefault();
            if (SelectArea.Title == "Add New+")
            {
                await PopupNavigation.Instance.PopAllAsync();
                
                await PopupNavigation.Instance.PushAsync(new AddNewFieldPopup());
            }
        }

        [Obsolete]
        public Command NationalityChangeCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (AllNationality != null && AllNationality.Count > 0)
                        {
                            DropDownPopupPage dropDownPopup = new DropDownPopupPage();
                            dropDownPopup.Title = "Nationality";
                            dropDownPopup.DropDownSelectedItem += DropDownPopup_DropDownSelectedItemNationality;
                            dropDownPopup.PickerItemsSource = AllNationality;
                            dropDownPopup.MasterData = AllNationality.ToList();
                            await PopupNavigation.PushAsync(dropDownPopup);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    

                });
            }
        }
        private void DropDownPopup_DropDownSelectedItemNationality(object sender, EventArgs e)
        {
            try
            {
                DropDownPopupPage control = sender as DropDownPopupPage;
                SelectNationality = control.SelectedItem as DropDownModel;
                SelectedNationalityResponse = NationalityResponses.Where(u => u.CountryId == SelectNationality.Id).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            
        }

        [Obsolete]
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
                            dropDownPopup.Title = "Country";
                            dropDownPopup.DropDownSelectedItem += DropDownPopup_DropDownSelectedItem; ;
                            dropDownPopup.PickerItemsSource = AllCountries;
                            dropDownPopup.MasterData = AllCountries.ToList();
                            await PopupNavigation.PushAsync(dropDownPopup);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    
                    
                });
            }
        }
        private async void DropDownPopup_DropDownSelectedItem(object sender, EventArgs e)
        {
            try
            {
                DropDownPopupPage control = sender as DropDownPopupPage;
                SelectCountry = control.SelectedItem as DropDownModel;
                SelectedCountryResponse = CountryResponses.Where(u => u.CountryId == SelectCountry.Id).FirstOrDefault();
                if (SelectCountry != null && SelectCountry.Id != 0)
                {
                    await GetCities();
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        [Obsolete]
        public Command CityChangeCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (AllCities != null && AllCities.Count > 0)
                        {
                            DropDownPopupPage dropDownPopup = new DropDownPopupPage();
                            dropDownPopup.Title = "City";
                            dropDownPopup.DropDownSelectedItem += DropDownPopup_DropDownSelectedItemCity;
                            dropDownPopup.PickerItemsSource = AllCities;
                            dropDownPopup.MasterData = AllCities.ToList();
                            await PopupNavigation.PushAsync(dropDownPopup);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    
                });
            }
        }
        private async void DropDownPopup_DropDownSelectedItemCity(object sender, EventArgs e)
        {
            try
            {
                DropDownPopupPage control = sender as DropDownPopupPage;
                SelectCity = control.SelectedItem as DropDownModel;
                SelectedCityResponse = CityResponses.Where(u => u.Id == SelectCity.Id).FirstOrDefault();
                if (SelectCity != null && SelectCity.Id != 0)
                {
                    await GetAreaByCity();
                }
            }
            catch (Exception ex)
            {

            }
            
        }
        public async Task SaveAddress()
        {
            try
            {
                if (await LocationValidation())
                {
                    AddressesSL addressesSL = new AddressesSL();

                    Addresses.CustomerId = CommonAttribute.CustomeProfile.PersonId;
                    Addresses.ApartmentNumber = ApartmentNumber;
                    Addresses.BuildingName = BuildingName;
                    Addresses.Street = Street;
                    Addresses.Area = SelectArea.Title;
                    Addresses.City = SelectCity?.Title;
                    Addresses.State = State;
                    Addresses.PostalCode = Convert.ToInt32(NewPostalCode);
                    if (SelectCountry != null)
                        Addresses.CountryId = SelectCountry.Id;
                    // if (Addresses.IsPrimary == null)
                    Addresses.IsPrimary = true;
                    Addresses.CityId = null;
                    if (GPSAddres != null)
                    {
                        Addresses.Latitude = Convert.ToDecimal(GPSAddres.Position.Latitude);
                        Addresses.Longitude = Convert.ToDecimal(GPSAddres.Position.Longitude);
                    }
                    var receiveContext = await addressesSL.AddAddresses(Addresses);
                    if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
                    {

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
            
        }
        public async Task<bool> LocationValidation()
        {
            if (string.IsNullOrEmpty(BuildingName))
            {
               // await ErrorDisplayAlert("Please enter building namr.");
                return false;
            }

            if (string.IsNullOrEmpty(SelectArea.Title))
            {
              //  await ErrorDisplayAlert("Please enter area.");
                return false;
            }
            if (string.IsNullOrEmpty(SelectCity?.Title))
            {
              //  await ErrorDisplayAlert("Please enter city.");
                return false;
            }
            if (string.IsNullOrEmpty(State))
            {
               // await ErrorDisplayAlert("Please enter state.");
                return false;
            }
            //CountryName
            return true;
        }
        public AddressesModel GPSAddres { get; set; }
        private ObservableCollection<DropDownModel> _Languages;
        public ObservableCollection<DropDownModel> Languages
        {
            get { return _Languages; }
            set
            {
                _Languages = value;
                OnPropertyChanged("Languages");
            }
        }
        private DropDownModel _SelectedLanguageType;
        public DropDownModel SelectedLanguageType
        {
            get { return _SelectedLanguageType; }
            set
            {
                _SelectedLanguageType = value;
                OnPropertyChanged("SelectedLanguageType");
            }
        }
        public List<CountryResponse> CountryResponses { get; set; }
        public List<EntityKeyValueResponse> CityResponses { get; set; }
        public List<CountryResponse> NationalityResponses { get; set; }
        public List<EntityKeyValueResponse> AreaResponses { get; set; }

        private string _AddNewValue;
        public string AddNewValue
        {
            get
            { return _AddNewValue; }
            set
            {
                _AddNewValue = value;
                OnPropertyChanged(nameof(AddNewValue));
            }
        }

        private CountryResponse _SelectedCountryResponse;
        public CountryResponse SelectedCountryResponse
        {
            get { return _SelectedCountryResponse; }
            set
            {
                _SelectedCountryResponse = value;
                PhoneCode = "+" + value.PhoneCode.ToString();
                OnPropertyChanged(nameof(SelectedCountryResponse));
            }
        }

        private CountryResponse _SelectedNationalityResponse;
        public CountryResponse SelectedNationalityResponse
        {
            get { return _SelectedNationalityResponse; }
            set
            {
                _SelectedNationalityResponse = value;
                OnPropertyChanged(nameof(SelectedNationalityResponse));
            }
        }


        private EntityKeyValueResponse _SelectedCityResponse;
        public EntityKeyValueResponse SelectedCityResponse
        {
            get { return _SelectedCityResponse; }
            set
            {
                _SelectedCityResponse = value;
                OnPropertyChanged(nameof(SelectedCityResponse));
            }
        }

        private EntityKeyValueResponse _SelectedAreaResponse;
        public EntityKeyValueResponse SelectedAreaResponse
        {
            get { return _SelectedAreaResponse; }
            set
            {
                _SelectedAreaResponse = value;
                OnPropertyChanged(nameof(SelectedAreaResponse));
            }
        }

        private ObservableCollection<DropDownModel> _AllNationality;
        public ObservableCollection<DropDownModel> AllNationality
        {
            get { return _AllNationality; }
            set
            {
                _AllNationality = value;
                OnPropertyChanged(nameof(AllNationality));
            }
        }
        private DropDownModel _SelectNationality;
        public DropDownModel SelectNationality
        {
            get { return _SelectNationality; }
            set
            {
                _SelectNationality = value;
                OnPropertyChanged(nameof(SelectNationality));
            }
        }

        private ObservableCollection<DropDownModel> _AllAreas;
        public ObservableCollection<DropDownModel> AllAreas
        {
            get { return _AllAreas; }
            set
            {
                _AllAreas = value;
                OnPropertyChanged(nameof(AllAreas));
            }
        }
        private DropDownModel _SelectArea;
        public DropDownModel SelectArea
        {
            get { return _SelectArea; }
            set
            {
                _SelectArea = value;
                OnPropertyChanged(nameof(SelectArea));
            }
        }

        private ObservableCollection<DropDownModel> _AllCountries;
        public ObservableCollection<DropDownModel> AllCountries
        {
            get { return _AllCountries; }
            set
            {
                _AllCountries = value;
                OnPropertyChanged(nameof(AllCountries));
            }
        }

        private DropDownModel _SelectCountry;
        public DropDownModel SelectCountry
        {
            get { return _SelectCountry; }
            set
            {
                _SelectCountry = value;
                OnPropertyChanged(nameof(SelectCountry));
            }
        }

        private ObservableCollection<DropDownModel> _AllCities;
        public ObservableCollection<DropDownModel> AllCities
        {
            get { return _AllCities; }
            set
            {
                _AllCities = value;
                OnPropertyChanged(nameof(AllCities));
            }
        }
        private DropDownModel _SelectCity;
        public DropDownModel SelectCity
        {
            get { return _SelectCity; }
            set
            {
                _SelectCity = value;
                OnPropertyChanged(nameof(SelectCity));
            }
        }

        public CountryResponse country { get; set; }
        public EntityKeyValueResponse CityByCountryId { get; set; }

        public List<LanguageModel> languages { get; set; }
      //  public LanguageModel SelectedLanguage { get; set; }

        private LanguageModel _SelectedLanguage;
        public LanguageModel SelectedLanguage
        {
            get { return _SelectedLanguage; }
            set
            {

                _SelectedLanguage = value;
                OnPropertyChanged("SelectedLanguage");
            }
        }
        //PhoneCode
        private string _PhoneCode;
        public string PhoneCode
        {
            get { return _PhoneCode; }
            set
            {

                _PhoneCode = value;
                OnPropertyChanged(nameof(PhoneCode));
            }
        }
        private string _AlternateNumber;
        public string AlternateNumber
        {
            get { return _AlternateNumber; }
            set
            {

                _AlternateNumber = value;
                OnPropertyChanged("AlternateNumber");
            }
        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {

                _Email = value;
                OnPropertyChanged("Email");
            }
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {

                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        private string _MobileNumber;
        public string MobileNumber
        {
            get { return _MobileNumber; }
            set
            {

                _MobileNumber = value;
                OnPropertyChanged("MobileNumber");
            }
        }

        
        public Command AddressCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new AddressesPage());

                });
            }
        }
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
        private string _NewPostalCode;
        public string NewPostalCode
        {
            get { return _NewPostalCode; }
            set
            {
                _NewPostalCode = value;
                OnPropertyChanged(nameof(NewPostalCode));
            }
        }
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
    }
}
