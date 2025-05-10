using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using eWarranty.Core.Hepler;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Views.Customer.Accesssories;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.Accesssories
{
    public class AccesssoriesViewModelBU : BaseViewModel
    {
        public AccesssoriesViewModelBU(INavigation navigation) : base(navigation)
        {
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () => {
                await BindingData();
                IsBusy = false;
            });
        }

        public async Task BindingData()
        {
            if (MasterProduct == null)
                MasterProduct = new List<AccessoryResponse>();
            if (Products == null)
                Products = new ObservableCollection<AccesssoriesListModel>();

            //AccessoryResponse
            //for (int i = 1; i < 10; i++)
            //{
            //    AccesssoriesModel accesssoriesRigth = new AccesssoriesModel() { id = i, Price=20*i, ProductName = "Product"+i.ToString(), ProductImage= "headphone.jpg" };
            //    AccesssoriesModel accesssoriesLeft = new AccesssoriesModel() { id = i+2, Price = 20 * i+2, ProductName = "Product" + (i+1).ToString(), ProductImage = "headphone.jpg" };
            //    MasterProduct.Add(accesssoriesRigth);
            //    MasterProduct.Add(accesssoriesLeft);
            //    Products.Add(new AccesssoriesListModel() { RigthItem = accesssoriesRigth, LeftItem = accesssoriesLeft });
            //    accesssoriesRigth = null;
            //    accesssoriesLeft = null;
            //}

            //ProductsCommand = new Command<int>((itemid) =>
            //{
            //    var ii = itemid;
            //   // AccesssoriesModel model = MasterProduct.Where(u => u.id == itemid).FirstOrDefault();
            //   // Navigation.PushAsync(new AccesssoriesDetailsPage(model));
            //});

            //CheckOutCommand = new Command(async () =>
            //{

            //    await Navigation.PushAsync(new CheckoutPage("cart"));
            //});
            AccessoryManagementSL accessoryManagementSL = new AccessoryManagementSL();

            List<AccessoryResponse> accessoryResponses = await accessoryManagementSL.GetAvailableAccessories(CommonAttribute.CustomeProfile.CountryId);
            if (accessoryResponses.Count == 0)
            {
                IsAccessoryAvailable = true;
            }
            else
            {
                IsAccessoryAvailable = false;
                for (int i = 0; i < accessoryResponses.Count; i++)
                {
                    var RigthItem = accessoryResponses[i];
                    RigthItem.IsVisible = true;
                    MasterProduct.Add(RigthItem);
                    AccessoryResponse LeftItem = new AccessoryResponse();
                    if (accessoryResponses.Count > i + 1)
                    {
                        LeftItem.IsVisible = true;
                        LeftItem = accessoryResponses[i + 1];
                        MasterProduct.Add(LeftItem);
                    }
                    else
                    {
                        LeftItem.IsVisible = false;
                    }


                    Products.Add(new AccesssoriesListModel() { RigthItem = LeftItem, LeftItem = RigthItem });
                    i = i + 1;
                }
            }

            //bannerdata
            if (BannersData == null)
                BannersData = new ObservableCollection<BannerData>();


            BannersData.Add(new BannerData() { UserProfile = true, id = 1, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/1.jpg" });
            BannersData.Add(new BannerData() { UserProfile = true, id = 2, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/2.jpg" });
            BannersData.Add(new BannerData() { UserProfile = true, id = 3, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/3.jpg" });
            BannersData.Add(new BannerData() { UserProfile = true, id = 4, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/4.jpg" });
            BannersData.Add(new BannerData() { UserProfile = true, id = 5, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/5.jpg" });

            //for location picker

            ServiceCentersManagementSL serviceCentersManagementSL = new ServiceCentersManagementSL();
            List<ServiceCenter> respServiceCenter = await serviceCentersManagementSL.GetServiceCentersNearestToLocation(CommonAttribute.CustomeProfile.CountryId, CommonAttribute.UserLocation.Latitude, CommonAttribute.UserLocation.Longitude);
            ServiceCentors = new List<ServiceCenter>(respServiceCenter);



        }

        public Command SearchAccessoriesCommand
        {
            get
            {
                return new Command(async () =>
                {
                    //AccessoriesLists = new List<AccesssoriesListModel>(Products.Where(u => u.RigthItem.Name == SelectedLocation).FirstOrDefault());
                    Products.Where(u => u.RigthItem.Name == SelectedLocation || u.LeftItem.Name == SelectedLocation).ToList();
                });
            }
        }

        public Command ProductsCommand
        {
            get
            {
                return new Command<long>((item) =>
                {
                    AccessoryResponse model = MasterProduct.Where(u => u.AccessoryMasterId == item).FirstOrDefault();
                    Navigation.PushAsync(new AccesssoriesDetailsPage(model));

                });
            }
        }
        public Command CheckOutCommand
        {
            get
            {
                return new Command(async () =>
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
                    AccessoryManagementSL accessoryManagementSL = new AccessoryManagementSL();

                    List<AccessoryResponse> accessoryResponses = await accessoryManagementSL.SearchAvailableAccessories(CommonAttribute.CustomeProfile.CountryId,1,item);
                    if (accessoryResponses.Count == 0)
                    {
                        Products.Clear();
                        IsAccessoryAvailable = true;
                    }
                    else
                    {
                        IsAccessoryAvailable = false;
                        if (accessoryResponses.Count > 0)
                            Products.Clear();
                        for (int i = 0; i < accessoryResponses.Count; i++)
                        {
                            var LeftItem = accessoryResponses[i];
                            AccessoryResponse RigthItem = null;
                            if (accessoryResponses.Count > i + 1)
                                RigthItem = accessoryResponses[i + 1];

                            Products.Add(new AccesssoriesListModel() { RigthItem = RigthItem, LeftItem = LeftItem });
                            i = i + 1;
                        }
                    }

                });
            }
        }
        // public ICommand CheckOutCommand { get; set; }
        //public ICommand ProductsCommand { get; set; }
        #region properties
        //AccesssoriesModel


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

        #endregion
    }
}

