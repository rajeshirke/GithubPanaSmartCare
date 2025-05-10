using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Controls;
using eWarranty.Core.Hepler;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.DependencyServices;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.Views.Customer.Accesssories;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.Accesssories
{
    public class AccesssoriesViewModel:BaseViewModel
    {
        public AccesssoriesViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () => {
                await BindingData();
                IsBusy = false;
            });
        }
        public async Task<int> GetCartCount()
        {
            AccessoryManagementSL accessoryManagement = new AccessoryManagementSL();
            List<ShoppingCartResponse> accessoryResponses = await accessoryManagement.GetShoppingCartItemsByPersonId(CommonAttribute.CustomeProfile.PersonId);
            return accessoryResponses.Count;

        }
        public async Task BindingData()
        {
            try
            {
                txtDeviceName = "";
                if (MasterProduct == null)
                    MasterProduct = new List<AccessoryResponse>();
                if (Products == null)
                    Products = new ObservableCollection<AccesssoriesListModel>();

                int SCId = 0;
                if (SelectedSeller != null)
                {
                    SCId = SelectedSeller.Id;
                }
                AccessoryManagementSL accessoryManagementSL = new AccessoryManagementSL();
                List<AccessoryResponse> accessoryResponses = await accessoryManagementSL.SearchAvailableAccessories(CommonAttribute.CustomeProfile.CountryId, SCId, txtDeviceName);
                accessoryResponses.ForEach(c => c.CurrencyCode = CommonAttribute.CustomeProfile?.CountryResponse?.CurrencyCode);
                if (accessoryResponses.Count == 0)
                {
                    IsAccessoryAvailable = true;
                }
                else
                {
                    IsAccessoryAvailable = false;
                    AccessoriesList = new List<AccessoryResponse>(accessoryResponses);
                    AccessoriesList.ForEach(c => c.CurrencyCode = CommonAttribute.CustomeProfile?.CountryResponse?.CurrencyCode);
                    //AccessoriesList = AccessoriesList.Take(10).ToList();

                }

                //bannerdata
                //if (BannersData == null)
                //{
                //    BannersData = new ObservableCollection<BannerData>();
                //    //BannersData = null;
                //    BannersData.Add(new BannerData() { UserProfile = true, id = 1, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/1.jpg" });
                //    BannersData.Add(new BannerData() { UserProfile = true, id = 2, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/2.jpg" });
                //    BannersData.Add(new BannerData() { UserProfile = true, id = 3, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/3.jpg" });
                //    BannersData.Add(new BannerData() { UserProfile = true, id = 4, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/4.jpg" });
                //    BannersData.Add(new BannerData() { UserProfile = true, id = 5, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/5.jpg" });
                //}
                //else
                //{
                //    BannersData = null;
                //    BannersData = new ObservableCollection<BannerData>();

                //    BannersData.Add(new BannerData() { UserProfile = true, id = 1, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/1.jpg" });
                //    BannersData.Add(new BannerData() { UserProfile = true, id = 2, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/2.jpg" });
                //    BannersData.Add(new BannerData() { UserProfile = true, id = 3, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/3.jpg" });
                //    BannersData.Add(new BannerData() { UserProfile = true, id = 4, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/4.jpg" });
                //    BannersData.Add(new BannerData() { UserProfile = true, id = 5, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/5.jpg" });
                //}


                //for location picker
                if (SellerDropdown == null)
                {
                    SellerDropdown = new ObservableCollection<DropDownModel>();
                    SellerDropdown.Add(new DropDownModel { Id = 0, Title = AppResources.lblAll });

                    if (CommonAttribute.UserLocation != null)
                    {
                        ServiceCentersManagementSL serviceCentersManagementSL = new ServiceCentersManagementSL();
                        List<ServiceCenter> respServiceCenter = await serviceCentersManagementSL.GetServiceCentersNearestToLocation(CommonAttribute.CustomeProfile.CountryId, CommonAttribute.UserLocation.Latitude, CommonAttribute.UserLocation.Longitude);
                        ServiceCentors = new List<ServiceCenter>(respServiceCenter);
                        foreach (var item in ServiceCentors)
                        {
                            SellerDropdown.Add(new DropDownModel { Id = item.ServiceCenterId, Title = item.Name });
                        }

                    }
                    else
                    {
                        if (Device.RuntimePlatform == Device.Android)
                        {
                            bool gpsStatus = DependencyService.Get<ILocSettings>().isGpsAvailable();
                            //if (!gpsStatus)
                            //await ErrorDisplayAlert(AppResources.lblErrorGPS);
                        }
                    }
                }
                CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode;
            }
            catch (Exception ex)
            {

            }
            
        }

        public Command SellerCommand
        {
            get
            {
                return new Command<DropDownModel>((obj) =>
                {
                    try
                    {
                        if (obj != null)
                            SelectedSeller = obj;
                        else
                            SelectedSeller.Id = 0;
                    }
                    catch (Exception ex)
                    {

                    }
                    
                });
            }
        }

        public Command SearchAccessoriesCommand
        {
            get
            {
                return new Command(async () => 
                {
                    try
                    {
                        int SCId = 0;
                        if (SelectedSeller != null)
                        {
                            SCId = SelectedSeller.Id;
                        }
                        List<AccessoryResponse> accessoryResponses = new List<AccessoryResponse>();
                        AccessoryManagementSL accessoryManagementSL = new AccessoryManagementSL();
                        accessoryResponses = await accessoryManagementSL.SearchAvailableAccessories(CommonAttribute.CustomeProfile.CountryId, SCId, txtDeviceName);

                        //AccessoriesLists = new List<AccesssoriesListModel>(Products.Where(u => u.RigthItem.Name == SelectedLocation).FirstOrDefault());
                        // List<AccessoryResponse> accessoryResponses = new List<AccessoryResponse>(AccessoriesList.Where(u => u.ServiceCenterId == SelectedSeller.Id));
                        if (accessoryResponses.Count == 0)
                        {
                            AccessoriesList = null;
                            IsAccessoryAvailable = true;
                        }
                        else
                        {
                            IsAccessoryAvailable = false;

                            if (accessoryResponses.Count > 0)
                                AccessoriesList = null;

                            AccessoriesList = new List<AccessoryResponse>(accessoryResponses);
                            AccessoriesList.ForEach(c => c.CurrencyCode = CommonAttribute.CustomeProfile?.CountryResponse?.CurrencyCode);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    
                });
            }
        }

        public Command ProductsCommand
        {
            get
            {
                return new Command<long>((item) =>
                {
                    try
                    {
                        AccessoryResponse model = AccessoriesList.Where(u => u.AccessoryMasterId == item).FirstOrDefault();
                        Navigation.PushAsync(new AccesssoriesDetailsPage(model));

                    }
                    catch (Exception ex)
                    {

                    }
                    

                });
            }
        }
        public Command CheckOutCommand
        {
            get
            {
                return new Command( async() =>
                {
                    await Navigation.PushAsync(new CheckoutPage("cart"));

                });
            }
        }
        public Command SearchProductCommand
        {
            get
            {
                return new Command<string>(async (item) =>
                {
                    try
                    {
                        int SCId = 0;
                        if (SelectedSeller != null)
                        {
                            SCId = SelectedSeller.Id;
                        }
                        txtDeviceName = item;
                        AccessoryManagementSL accessoryManagementSL = new AccessoryManagementSL();
                        List<AccessoryResponse> accessoryResponses = await accessoryManagementSL.SearchAvailableAccessories((int)CommonAttribute.CustomeProfile.CountryId, SCId, item);


                        if (accessoryResponses.Count == 0)
                        {
                            AccessoriesList = null;
                            IsAccessoryAvailable = true;
                        }
                        else
                        {
                            IsAccessoryAvailable = false;

                            if (accessoryResponses.Count > 0)
                                AccessoriesList = null;

                            AccessoriesList = new List<AccessoryResponse>(accessoryResponses);
                            AccessoriesList.ForEach(c => c.CurrencyCode = CommonAttribute.CustomeProfile?.CountryResponse?.CurrencyCode);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    

                });
            }
        }

        #region properties        

        public string _txtDeviceName;
        public string txtDeviceName
        {
            get { return _txtDeviceName; }
            set
            {
                _txtDeviceName = value;
                OnPropertyChanged("txtDeviceName");
            }
        }

        private List<AccesssoriesListModel> _AccessoriesLists;
        public List<AccesssoriesListModel> AccessoriesLists
        {
            get { return _AccessoriesLists; }
            set
            {
                _AccessoriesLists = value;
                OnPropertyChanged("AccessoriesLists");
            }
        }

        private List<AccessoryResponse> _AccessoriesList;
        public List<AccessoryResponse> AccessoriesList
        {
            get { return _AccessoriesList; }
            set
            {
                _AccessoriesList = value;
                OnPropertyChanged("AccessoriesList");
            }
        }

        private List<ServiceCenter> _ServiceCentors;
        public List<ServiceCenter> ServiceCentors
        {
            get { return _ServiceCentors; }
            set
            {
                _ServiceCentors = value;
                OnPropertyChanged("ServiceCentors");
            }
        }

        private ObservableCollection<BannerData> _BannersData;
        public ObservableCollection<BannerData> BannersData
        {
            get { return _BannersData; }
            set
            {
                _BannersData = value;
                OnPropertyChanged("BannersData");
            }
        }

        public List<AccessoryResponse> MasterProduct { get; set; }
        private ObservableCollection<AccesssoriesListModel> _Products;
        public ObservableCollection<AccesssoriesListModel> Products
        {
            get { return _Products; }
            set
            {
                _Products = value;
                OnPropertyChanged("Products");
            }
        }

        public bool _IsListVisible;
        public bool IsListVisible
        {
            get { return _IsListVisible; }
            set
            {
                _IsListVisible = value;
                OnPropertyChanged("IsListVisible");
            }
        }

        public Boolean _IsAccessoryAvailable;
        public Boolean IsAccessoryAvailable
        {
            get { return _IsAccessoryAvailable; }
            set
            {
                _IsAccessoryAvailable = value;
                OnPropertyChanged("IsAccessoryAvailable");
            }
        }

        public string _SelectedLocation;
        public string SelectedLocation
        {
            get { return _SelectedLocation; }
            set
            {
                _SelectedLocation = value;
                OnPropertyChanged("SelectedLocation");
            }
        }

        private ObservableCollection<DropDownModel> _SellerDropdown;
        public ObservableCollection<DropDownModel> SellerDropdown
        {
            get { return _SellerDropdown; }
            set
            {
                _SellerDropdown = value;
                OnPropertyChanged("SellerDropdown");
            }
        }
        private DropDownModel _SelectedSeller;
        public DropDownModel SelectedSeller
        {
            get { return _SelectedSeller; }
            set
            {
                _SelectedSeller = value;
                OnPropertyChanged("SelectedSeller");
            }
        }

        private int _CountryID;
        public int CountryID
        {
            get { return _CountryID; }
            set
            {
                _CountryID = value;
                OnPropertyChanged("CountryID");
            }
        }

        #endregion
    }
}
