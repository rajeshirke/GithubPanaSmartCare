using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Hepler;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.Views.Account;
using eWarranty.Views.Customer.Accesssories;
using eWarranty.Views.Customer.AMCRequest;
using eWarranty.Views.Customer.CommonPages;
using eWarranty.Views.Customer.InquiryView;
using eWarranty.Views.Customer.Products;
using eWarranty.Views.Customer.SRDetails;
using eWarranty.Views.ServiceCentorView;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer
{
    public class DashBoardViewModel : BaseViewModel
    {
        public ICommand SelectTileCommand { get; set; }

        public DashBoardViewModel(INavigation navigation) : base(navigation)
        {
            try
            {
                IsBusy = false;
                DashboardMasterTiles();
                SelectTileCommand = new Command(SelectionTileChangedEvent);

                MessagingCenter.Unsubscribe<SRSuccessPage>(this, "sendsrlist");
                MessagingCenter.Subscribe<SRSuccessPage>(this, "sendsrlist", (sender) =>
                {
                    navigation.PushAsync(new ServicesPage());
                    MessagingCenter.Unsubscribe<SRSuccessPage>(this, "sendsrlist");
                });
                ProductsCommand = new Command(() =>
                {
                    Navigation.PushAsync(new ProductsPage());
                });
                AddProductsCommand = new Command(() =>
                {
                    Navigation.PushAsync(new AddProductPage());
                });
                ServicesCommand = new Command(() =>
                {
                    Navigation.PushAsync(new ServicesPage());
                });

                FindServiceCenterCommand = new Command(() =>
                {
                    Navigation.PushAsync(new ServiceCentorsPage());
                });
                AMCRequestListCommand = new Command(() =>
                {
                    Navigation.PushAsync(new SelectProductsPage("AddAMCRequestPage"));
                });
                AccessoriesCommand = new Command(() =>
                {

                    Navigation.PushAsync(new AccesssoriesPage());
                });
                InquiryCommand = new Command(() =>
                {
                    Navigation.PushAsync(new ChatBotViewPage());
                    // Navigation.PushAsync(new SurveyPage());
                });
                SurveyCommand = new Command(() =>
                {
                    Navigation.PushAsync(new FeedBackPage(1, 1));
                });

                DashboardButtonCommand = new Command<DashboardButtonList>(async (item) =>
                {
                    if (item.ButtonName == "My Products")
                    {
                        await Navigation.PushAsync(new ProductsPage());
                    }

                });

                Device.BeginInvokeOnMainThread(async () => {

                    CommonAttribute.UserLocation = await Extensions.GetGeolocation();
                    if (CommonAttribute.UserLocation == null)
                    {
                        //await ErrorDisplayAlert(AppResources.lblErrorGPS);
                    }
                });

                if (BannersData == null)
                    BannersData = new ObservableCollection<BannerData>();


                BannersData.Add(new BannerData() { UserProfile = true, id = 1, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/1.jpg" });
                BannersData.Add(new BannerData() { UserProfile = true, id = 2, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/2.jpg" });
                BannersData.Add(new BannerData() { UserProfile = true, id = 3, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/3.jpg" });
                BannersData.Add(new BannerData() { UserProfile = true, id = 4, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/4.jpg" });
                BannersData.Add(new BannerData() { UserProfile = true, id = 5, Subject = "", Title = "", Imageurl = ServiceEndPoints.WebAppUri + "images/Banner/5.jpg" });

                lstDashboardButton = new ObservableCollection<DashboardButtonList>();
                lstDashboardButton.Add(new DashboardButtonList { ButtonName = AppResources.btnMyProducts, ButtonIcon = "dbproduct" });
                lstDashboardButton.Add(new DashboardButtonList { ButtonName = AppResources.btnRegisterProduct, ButtonIcon = "dbnoteadd" });
                lstDashboardButton.Add(new DashboardButtonList { ButtonName = AppResources.btnTrackService, ButtonIcon = "dbservices" });
                lstDashboardButton.Add(new DashboardButtonList { ButtonName = AppResources.btnServiceRequest, ButtonIcon = "dbaddsr" });
                lstDashboardButton.Add(new DashboardButtonList { ButtonName = AppResources.btnServiceCenter, ButtonIcon = "dblocation" });
                lstDashboardButton.Add(new DashboardButtonList { ButtonName = AppResources.btnSmartAssistant, ButtonIcon = "dbinquery" });

            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            

        }
        public async Task<int> BindingData()
        {
            UserManagementSL userManagementSL = new UserManagementSL();
            List<PersonNotificationResponse> personNotifications = await userManagementSL.GetUnreadNotifications(CommonAttribute.CustomeProfile.PersonId);
            if (personNotifications != null )
            {
                return personNotifications.Count;
            }
            return 0;
        }
        #region event
        public Command DashboardButtonCommand { get; set; }

        public ICommand ProductsCommand { get; set; }     
        public ICommand AddProductsCommand { get; set; }        
        public ICommand ServicesCommand { get; set; }
        public ICommand FindServiceCenterCommand { get; set; }
        public ICommand AMCRequestListCommand { get; set; }
        public ICommand AccessoriesCommand { get; set; }
        public ICommand InquiryCommand { get; set; }
        public ICommand SurveyCommand { get; set; }       
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
        public Command AddServiceRequestCommand
        {
            get
            {
                return new Command(() =>
                {

                    Navigation.PushAsync(new SelectProductsPage("Product"));
                });
            }
        }

        public Command OrdersCommand
        {
            get
            {
                return new Command(() =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    Navigation.PushAsync(new MyOrderHistoryPage());
                });
            }
        }

        public Command ChatHistoryCommand
        {
            get
            {
                return new Command(() =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    Navigation.PushAsync(new ChatBotHistoryPage());
                });
            }
        }
        //ChatHistoryCommand
        public Command AmcListCommand
        {
            get
            {
                return new Command(() =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    Navigation.PushAsync(new AMCRequestListPage());
                });
            }
        }

        public Command SurveyPageCommand
        {
            get
            {
                return new Command(() =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    Navigation.PushAsync(new SurveyPage());
                });
            }
        }
        #endregion
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

        private ObservableCollection<DashboardButtonList> _lstDashboardButton;
        public ObservableCollection<DashboardButtonList> lstDashboardButton
        {
            get { return _lstDashboardButton; }
            set
            {
                _lstDashboardButton = value;
                OnPropertyChanged("lstDashboardButton");
            }
        }

        //tiles

        private void SelectionTileChangedEvent(object obj)
        {
            var DashboarMasterTile1 = (DashboarMasterTile)obj;
            if (DashboarMasterTile1.Label1 == AppResources.btnMyProducts)
                Navigation.PushAsync(new ProductsPage());
            if (DashboarMasterTile1.Label1 == AppResources.btnRegisterProduct)
                Navigation.PushAsync(new AddProductPage());
            if (DashboarMasterTile1.Label1 == AppResources.btnTrackService)
                Navigation.PushAsync(new ServicesPage());
            if (DashboarMasterTile1.Label1 == AppResources.btnServiceRequest)
                Navigation.PushAsync(new SelectProductsPage("Product"));
            if (DashboarMasterTile1.Label1 == AppResources.btnServiceCenter)
                Navigation.PushAsync(new ServiceCentorsPage());
            if (DashboarMasterTile1.Label1 == AppResources.btnSmartAssistant)
                Navigation.PushAsync(new ChatBotViewPage());
        }

        public void DashboardMasterTiles()
        {
            try
            {
                ObservableCollection<DashboarMasterTile> dashboarMasterTiles = new ObservableCollection<DashboarMasterTile>();
                List<MobileAppModuleResponse> DBMobileAppModules = (List<MobileAppModuleResponse>)CommonAttribute.CustomeProfile.MobileAppModules;

                if (DBMobileAppModules != null)
                {
                    var DBMobileAppModulesAsc = DBMobileAppModules.ToList();

                    foreach (var MobileAppModule in DBMobileAppModulesAsc)
                    {
                        switch (MobileAppModule.Name)
                        {
                            //case "My Products":
                            //        dashboarMasterTiles.Add(new DashboarMasterTile
                            //        {
                            //            SrNo1 = 1,
                            //            Image1 = "dbproduct.png",
                            //            Label1 = "My Products"
                            //        });
                            //    break;

                            case "Register Product"://

                                dashboarMasterTiles.Add(new DashboarMasterTile
                                {
                                    SrNo1 = 1,
                                    Image1 = "dbnoteadd.png",
                                    Label1 = AppResources.btnRegisterProduct,
                                });

                                dashboarMasterTiles.Add(new DashboarMasterTile
                                {
                                    SrNo1 = 2,
                                    Image1 = "dbproduct.png",
                                    Label1 = AppResources.btnMyProducts,
                                });

                                break;

                            case "Track Service"://
                                dashboarMasterTiles.Add(new DashboarMasterTile
                                {
                                    SrNo1 = 3,
                                    Image1 = "dbservices.png",
                                    Label1 = AppResources.btnTrackService,
                                });
                                dashboarMasterTiles.Add(new DashboarMasterTile
                                {
                                    SrNo1 = 4,
                                    Image1 = "dbaddsr.png",
                                    Label1 = AppResources.btnServiceRequest,
                                });
                                break;

                            //case "Service Request":
                            //        dashboarMasterTiles.Add(new DashboarMasterTile
                            //        {
                            //            SrNo1 = 4,
                            //            Image1 = "dbaddsr.png",
                            //            Label1 = "Service Request"
                            //        });
                            //    break;

                            case "Service Center"://
                                dashboarMasterTiles.Add(new DashboarMasterTile
                                {
                                    SrNo1 = 5,
                                    Image1 = "dblocation.png",
                                    Label1 = AppResources.btnServiceCenter,
                                });
                                break;

                            case "Smart Assistant"://
                                dashboarMasterTiles.Add(new DashboarMasterTile
                                {
                                    SrNo1 = 6,
                                    Image1 = "dbinquery.png",
                                    Label1 = AppResources.btnSmartAssistant,
                                });
                                break;

                        }

                    }

                    if (dashboarMasterTiles != null && dashboarMasterTiles.Count > 0)
                    {
                        var list1 = dashboarMasterTiles.OrderBy(p => p.SrNo1).ToList();
                        DashboarMasterTileList = new ObservableCollection<DashboarMasterTile>(list1);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            
        }


        public ObservableCollection<DashboarMasterTile> _DashboarMasterTileList;
        public ObservableCollection<DashboarMasterTile> DashboarMasterTileList
        {
            get { return _DashboarMasterTileList; }
            set
            {
                _DashboarMasterTileList = value;
                OnPropertyChanged(nameof(DashboarMasterTileList));
            }
        }

    }
}

public class DashboarMasterTile
{
    public int SrNo1 { get; set; }
    public string Label1 { get; set; }
    public string Image1 { get; set; }

}

public class DashboardButtonList
{
    public string ButtonName { get; set; }
    public string ButtonIcon { get; set; }
}
