using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Common;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.DependencyServices;
using eWarranty.Hepler;
using eWarranty.Resx;
using eWarranty.Views.Account;
using eWarranty.Views.Customer;
using eWarranty.Views.Customer.CommonPages;
using Plugin.LocalNotification;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Text;
using NotificationRequest = Plugin.LocalNotification.NotificationRequest;
using System.Collections.ObjectModel;
using eWarranty.Core.Enums;
using eWarranty.Views.AppOnBoard;

namespace eWarranty.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public INavigation Navigation { get; set; }
        // public FlowDirection flowDirection { get; set; }
        public BaseViewModel(INavigation navigation)
        {
            if (Application.Current.Properties.ContainsKey("userpic"))
            {
                UserPic = Application.Current.Properties["userpic"] as ImageSource;
            }
            else
                UserPic = "defultuser";
            Device.BeginInvokeOnMainThread(async () => {
                var current = Connectivity.NetworkAccess;
                if (current != NetworkAccess.Internet)
                {
                    IsBusy = false;
                    await ErrorDisplayAlert(AppResources.lblErrorCheckInternet);
                    // Application.Current.MainPage = new NavigationPage(new LoginPage());

                }
            });
            if (CommonAttribute.CustomeProfile != null)
            {
                Person = CommonAttribute.CustomeProfile;
                CurrencyCode = CommonAttribute.CustomeProfile?.CountryResponse?.CurrencyCode;
                TaxRate = Convert.ToDecimal(CommonAttribute.CustomeProfile.CountryResponse?.CountryLevelSettingResponse?.TaxPercentage);
                TaxName = (CommonAttribute.CustomeProfile.CountryResponse?.CountryLevelSettingResponse?.TaxName);
            }
            VersionNumber = VersionTracking.CurrentVersion;
            ScreenWidth = CommonAttribute.ScreenWidth;
            ScreenHeight = CommonAttribute.ScreenHeight;
            Navigation = navigation;
            //if (CommonAttribute.selectedLang.LongCode == "ur")
            //{
            //    flowDirection = FlowDirection.RightToLeft;
            //    BtnRotationBack = 180;
            //}
            //else
            //{
            //    flowDirection = FlowDirection.LeftToRight;
            //    BtnRotationBack = 0;
            //}

            NotificationCenter.Current.NotificationReceived += Current_NotificationReceived;

            NotificationCenter.Current.NotificationTapped += Current_NotificationTapped;
            
            //Device.StartTimer(TimeSpan.FromMinutes(2),  () =>
            //{
            //    Device.BeginInvokeOnMainThread(async () => {
            //        UserManagementSL userManagementSL = new UserManagementSL();
            //        TechnicianLocationTrackingRequest locationTrackingRequest = new TechnicianLocationTrackingRequest();
            //        if (CommonAttribute.UserLocation != null)
            //        {
            //            locationTrackingRequest.Latitude = Convert.ToDecimal(CommonAttribute.UserLocation.Latitude);
            //            locationTrackingRequest.Longitude = Convert.ToDecimal(CommonAttribute.UserLocation.Longitude);
            //            locationTrackingRequest.PersonId = CommonAttribute.CustomeProfile.PersonId;

            //            await userManagementSL.PostTechnicianLocationTracking(locationTrackingRequest);
            //        }
            //    });

            //    return true;
            //});
            try
            {

                Device.StartTimer(TimeSpan.FromMinutes(2.5), () =>
                {
                    if(CommonAttribute.CustomeProfile != null && CommonAttribute.CustomeProfile?.PersonId != 0)
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            UserManagementSL _userManagementSL = new UserManagementSL();
                            List<PersonNotificationResponse> personNotifications = await _userManagementSL.GetUnreadNotifications((long)(CommonAttribute.CustomeProfile?.PersonId));
                            if (personNotifications != null && personNotifications.Count > 0)
                            {
                                var CustNotification = personNotifications[0];
                                ReceivedNotificationId = CustNotification.NotificationId;
                                var notification = new NotificationRequest
                                {
                                    BadgeNumber = 1,
                                    Description = CustNotification.NotificationContent,
                                    Title = CustNotification.MessageSubject,
                                    ReturningData = "Dummy Data",
                                    NotificationId = CustNotification.NotificationId,
                                    NotifyTime = DateTime.Now.AddSeconds(10),

                                };
                                NotificationCenter.Current.Show(notification);
                            }

                            if (CommonAttribute.CustomeProfile?.PersonRoleId == (int)PersonRoleEnum.Technician)
                            {
                                UserManagementSL userManagementSL = new UserManagementSL();

                                TechnicianLocationTrackingRequest locationTrackingRequest = new TechnicianLocationTrackingRequest();
                                if (CommonAttribute.UserLocation != null)
                                {
                                    locationTrackingRequest.Latitude = Convert.ToDecimal(CommonAttribute.UserLocation.Latitude);
                                    locationTrackingRequest.Longitude = Convert.ToDecimal(CommonAttribute.UserLocation.Longitude);
                                    locationTrackingRequest.PersonId = CommonAttribute.CustomeProfile.PersonId;

                                    await userManagementSL.PostTechnicianLocationTracking(locationTrackingRequest);
                                }

                            }

                        });
                    }
                    return true;
                });
            }
            catch (Exception ex)
            {
                DisplayAlert("Alert!", "Something went wrong.Try after sometime.");
            }





            //ChangeLangugeCommand = new Command<string>((val) =>
            //{
            //    LocalizationResourceManager.Instance.SetCulture(CultureInfo.GetCultureInfo(val));
            //    var languages = eWarranty.Hepler.Extensions.Getlanguages();
            //    CommonFunctions.LongCode = val;
            //    CommonAttribute.selectedLang = languages.Find(u => u.LongCode == val);
            //    CultureInfo cultureInfo = new CultureInfo(val);
            //    if (val == "ur")
            //        flowDirection = FlowDirection.RightToLeft;
            //    else
            //        flowDirection = FlowDirection.LeftToRight;

            //    MessagingCenter.Send<BaseViewModel>(this, "Lang");
            //    Application.Current.MainPage = new DashBoadMasterPage();
            //    //  DependencyService.Get<ILanguageService>().SetApplicationLanguage(cultureInfo);

            //    //  Application.Current.MainPage = new NavigationPage(new LoginPage());
            //    // LoadLanguage();
            //    // await App.Current.MainPage.DisplayAlert(AppResources.LanguageChanged, "", AppResources.Done);
            //});

            BackCommand = new Command(() =>
            {
                MessagingCenter.Send<object, string>(this, "Page", "Refresh");
                Navigation.PopAsync();

            });
            TermsConditionsCommand = new Command(() =>
            {
                Shell.Current.FlyoutIsPresented = false;
                Navigation.PushAsync(new TermsConditionsPage());
            });
            //TermsConditionsPage
            LogoutCommand = new Command(async () =>
            {
                var res = await YesorNoDisplayAlert(AppResources.lblErrorAlert, AppResources.lblLogoutmessage);
                if (res)
                {

                    //Application.Current.Properties.Remove("email");
                    Application.Current.Properties.Remove("password");
                    //  Application.Current.Properties.Clear();
                    await Application.Current.SavePropertiesAsync();
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                }

            });

            //if (Device.RuntimePlatform == Device.Android)
            //{
            //    HideBottomTab();
            //}

           
        }
        
        private async void Current_NotificationTapped(NotificationTappedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Notification tapped", e.Data);
            });

            UserManagementSL userManagementSL = new UserManagementSL();
            var personNotifications = await userManagementSL.UpdateNotificationReadDate(CommonAttribute.CustomeProfile.PersonId, ReceivedNotificationId);
            if (personNotifications)
            {
                await BindingData();
            }
        }

        private async void Current_NotificationReceived(NotificationReceivedEventArgs e)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    //await DisplayAlert(e.Title, e.Description);

                });
            }

            UserManagementSL userManagementSL = new UserManagementSL();
            var personNotifications = await userManagementSL.UpdateNotificationReadDate(CommonAttribute.CustomeProfile.PersonId, ReceivedNotificationId);
            
            if (personNotifications)
            {
                await BindingData();
            }
        }

        public void HideBottomTab()
        {
            if (Navigation.NavigationStack.Count == 0)//|| Navigation.NavigationStack.Last().GetType() != typeof(DashBoadMasterPage)
            {
                //await Navigation.PushAsync(new CustomerPage(), true);
                IsBottomTabHide = true;
            }
            else
            {
                IsBottomTabHide = false;

            }
        }

        public async Task BindingData()
        {
            UserManagementSL userManagementSL = new UserManagementSL();
            List<PersonNotificationResponse> personNotifications = await userManagementSL.GetUnreadNotifications(CommonAttribute.CustomeProfile.PersonId);
            if (personNotifications != null)
            {
                if (Notifications == null)
                    Notifications = new ObservableCollection<PersonNotificationResponse>();

                Notifications = new ObservableCollection<PersonNotificationResponse>(personNotifications);
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

        public void LoginLangChange(string val)
        {
            LocalizationResourceManager.Instance.SetCulture(CultureInfo.GetCultureInfo(val));
            var languages = eWarranty.Hepler.Extensions.Getlanguages();
            CommonFunctions.LongCode = val;
            CommonAttribute.selectedLang = languages.Find(u => u.LongCode == val);
            CultureInfo cultureInfo = new CultureInfo(val);
            if (val == "ur")
                flowDirection = FlowDirection.RightToLeft;
            else
                flowDirection = FlowDirection.LeftToRight;

            MessagingCenter.Send<BaseViewModel>(this, "Lang");
        }
        public async Task ErrorDisplayAlert(string msg)
        {
            await Application.Current.MainPage.DisplayAlert("", msg, AppResources.lblOk);
        }
        //
        public async Task DisplayAlert(string title, string msg)
        {
            await Application.Current.MainPage.DisplayAlert(title, msg, "Ok");
        }
        public async Task<bool> YesorNoDisplayAlert(string title, string msg)
        {
            return await Application.Current.MainPage.DisplayAlert(title, msg, AppResources.lblOk, AppResources.lblCancel);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand ChangeLangugeCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand TermsConditionsCommand { get; set; }
        public int BtnRotationBack { get; set; }
        //VersionNumber

        public Rectangle _HomeCircle;
        public Rectangle HomeCircle
        {
            get
            {
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    _HomeCircle = new Rectangle(0f, 0f, 500, 400);
                }
                else if (Device.Idiom == TargetIdiom.Tablet)
                {
                    _HomeCircle = new Rectangle(0f, 0f, 1200, 400);
                }
                else
                {
                    _HomeCircle = new Rectangle(0f, 0f, 500, AbsoluteLayout.AutoSize);
                }
                return _HomeCircle;
            }
            set
            {
                _HomeCircle = value;
                OnPropertyChanged("HomeCircle");
            }
        }

        private int _ReceivedNotificationId;
        public int ReceivedNotificationId
        {
            get { return _ReceivedNotificationId; }
            set
            {
                _ReceivedNotificationId = value;
                OnPropertyChanged(nameof(ReceivedNotificationId));
            }
        }

        private string _TaxName;
        public string TaxName
        {
            get { return _TaxName; }
            set
            {
                _TaxName = value;
                OnPropertyChanged(nameof(TaxName));
            }
        }

        private string _CurrencyCode;
        public string CurrencyCode
        {
            get { return _CurrencyCode; }
            set
            {
                _CurrencyCode = value;
                OnPropertyChanged("CurrencyCode");
            }
        }
        private decimal _TaxRate;
        public decimal TaxRate
        {
            get { return _TaxRate; }
            set
            {
                _TaxRate = value;
                OnPropertyChanged("TaxRate");
            }
        }
        private string _MobileVersionNumber;
        public string MobileVersionNumber
        {
            get { return _MobileVersionNumber; }
            set
            {
                _MobileVersionNumber = value;
                OnPropertyChanged("MobileVersionNumber");
            }
        }
        private ImageSource _UserPic;
        public ImageSource UserPic
        {
            get { return _UserPic; }
            set
            {
                _UserPic = value;
                OnPropertyChanged("UserPic");
            }
        }
        private int _ScreenWidth;
        public int ScreenWidth
        {
            get { return _ScreenWidth; }
            set
            {

                _ScreenWidth = value;
                OnPropertyChanged("ScreenWidth");


            }
        }
        private int _ScreenHeight;
        public int ScreenHeight
        {
            get { return _ScreenHeight; }
            set
            {

                _ScreenHeight = value;
                OnPropertyChanged("ScreenHeight");


            }
        }
        public bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                var hud = DependencyService.Get<IEWProgress>();
                if (value)
                {
                    hud.Show();
                }
                else
                {
                    hud.Dismiss();
                }
                _IsBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }
        public FlowDirection _flowDirection;
        public FlowDirection flowDirection
        {
            get { return _flowDirection; }
            set
            {
                CommonAttribute.flowDirection = value;
                if (value == FlowDirection.LeftToRight)
                    textAlignment = TextAlignment.Start;
                else
                    textAlignment = TextAlignment.Start;

                _flowDirection = value;
                OnPropertyChanged("flowDirection");


            }
        }
        public string _VersionNumber;
        public string VersionNumber
        {
            get { return _VersionNumber; }
            set
            {

                _VersionNumber = value;
                OnPropertyChanged("VersionNumber");


            }
        }
        public TextAlignment _textAlignment;
        public TextAlignment textAlignment
        {
            get { return _textAlignment; }
            set
            {

                _textAlignment = value;
                OnPropertyChanged("textAlignment");


            }
        }
        private PersonLoginResponse _Person;
        public PersonLoginResponse Person
        {
            get { return _Person; }
            set
            {

                _Person = value;
                OnPropertyChanged("Person");
            }
        }
        //public static TextAlignment TextAlignment { get; set; }

        #region DashBoardMenus

        private bool _IsBottomTabHide = false;
        public bool IsBottomTabHide
        {
            get { return _IsBottomTabHide; }
            set
            {

                _IsBottomTabHide = value;
                OnPropertyChanged(nameof(IsBottomTabHide));
            }
        }

        private bool _IsRegisterProduct = false;
        public bool IsRegisterProduct
        {
            get { return _IsRegisterProduct; }
            set
            {

                _IsRegisterProduct = value;
                OnPropertyChanged("IsRegisterProduct");
            }
        }

        private bool _IsServices = false;
        public bool IsServices
        {
            get { return _IsServices; }
            set
            {

                _IsServices = value;
                OnPropertyChanged("IsServices");
            }
        }

        private bool _IsChat = false;
        public bool IsChat
        {
            get { return _IsChat; }
            set
            {

                _IsChat = value;
                OnPropertyChanged("IsChat");
            }
        }

        private bool _IsSurvey = false;
        public bool IsSurvey
        {
            get { return _IsSurvey; }
            set
            {

                _IsSurvey = value;
                OnPropertyChanged("IsSurvey");
            }
        }

        private bool _IsTermsandCondition = false;
        public bool IsTermsandCondition
        {
            get { return _IsTermsandCondition; }
            set
            {

                _IsTermsandCondition = value;
                OnPropertyChanged("IsTermsandCondition");
            }
        }

        private bool _IsServiceCenter = false;
        public bool IsServiceCenter
        {
            get { return _IsServiceCenter; }
            set
            {

                _IsServiceCenter = value;
                OnPropertyChanged("IsServiceCenter");
            }
        }

        private bool _IsProfile = false;
        public bool IsProfile
        {
            get { return _IsProfile; }
            set
            {

                _IsProfile = value;
                OnPropertyChanged("IsProfile");
            }
        }

        private bool _IsOrders = false;
        public bool IsOrders
        {
            get { return _IsOrders; }
            set
            {

                _IsOrders = value;
                OnPropertyChanged("IsOrders");
            }
        }

        private bool _IsTrackService = false;
        public bool IsTrackService
        {
            get { return _IsTrackService; }
            set
            {

                _IsTrackService = value;
                OnPropertyChanged("IsTrackService");
            }
        }

        private bool _IsSmartAssistant = false;
        public bool IsSmartAssistant
        {
            get { return _IsSmartAssistant; }
            set
            {

                _IsSmartAssistant = value;
                OnPropertyChanged("IsSmartAssistant");
            }
        }

        private bool _IsPromotion = false;
        public bool IsPromotion
        {
            get { return _IsPromotion; }
            set
            {

                _IsPromotion = value;
                OnPropertyChanged("IsPromotion");
            }
        }

        private bool _IsAccessories = false;
        public bool IsAccessories
        {
            get { return _IsAccessories; }
            set
            {

                _IsAccessories = value;
                OnPropertyChanged("IsAccessories");
            }
        }

        private bool _IsTechnicianJobs = false;
        public bool IsTechnicianJobs
        {
            get { return _IsTechnicianJobs; }
            set
            {

                _IsTechnicianJobs = value;
                OnPropertyChanged("IsTechnicianJobs");
            }
        }

        private bool _IsTechnicianPartStock = false;
        public bool IsTechnicianPartStock
        {
            get { return _IsTechnicianPartStock; }
            set
            {

                _IsTechnicianPartStock = value;
                OnPropertyChanged("IsTechnicianPartStock");
            }
        }

        private bool _IsTechnicianPartRequests = false;
        public bool IsTechnicianPartRequests
        {
            get { return _IsTechnicianPartRequests; }
            set
            {

                _IsTechnicianPartRequests = value;
                OnPropertyChanged("IsTechnicianPartRequests");
            }
        }

        private bool _IsTechnicianChat = false;
        public bool IsTechnicianChat
        {
            get { return _IsTechnicianChat; }
            set
            {

                _IsTechnicianChat = value;
                OnPropertyChanged("IsTechnicianChat");
            }
        }

        private bool _IsTechnicianServiceManuals = false;
        public bool IsTechnicianServiceManuals
        {
            get { return _IsTechnicianServiceManuals; }
            set
            {

                _IsTechnicianServiceManuals = value;
                OnPropertyChanged("IsTechnicianServiceManuals");
            }
        }

        private bool _IsTechnicianRepairTips = false;
        public bool IsTechnicianRepairTips
        {
            get { return _IsTechnicianRepairTips; }
            set
            {

                _IsTechnicianRepairTips = value;
                OnPropertyChanged("IsTechnicianRepairTips");
            }
        }

        private bool _IsTechnicianFAQ = false;
        public bool IsTechnicianFAQ
        {
            get { return _IsTechnicianFAQ; }
            set
            {

                _IsTechnicianFAQ = value;
                OnPropertyChanged("IsTechnicianFAQ");
            }
        }

        private bool _IsTechnicianQueries = false;
        public bool IsTechnicianQueries
        {
            get { return _IsTechnicianQueries; }
            set
            {

                _IsTechnicianQueries = value;
                OnPropertyChanged("IsTechnicianQueries");
            }
        }



        //Technician Dashboard
        private bool _IsMyJobs = false;
        public bool IsMyJobs
        {
            get { return _IsMyJobs; }
            set
            {

                _IsMyJobs = value;
                OnPropertyChanged(nameof(IsMyJobs));
            }
        }

        private bool _IsPartStock = false;
        public bool IsPartStock
        {
            get { return _IsPartStock; }
            set
            {

                _IsPartStock = value;
                OnPropertyChanged(nameof(IsPartStock));
            }
        }

        private bool _IsServiceManual = false;
        public bool IsServiceManual
        {
            get { return _IsServiceManual; }
            set
            {

                _IsServiceManual = value;
                OnPropertyChanged(nameof(IsServiceManual));
            }
        }


        private bool _IsTips = false;
        public bool IsTips
        {
            get { return _IsTips; }
            set
            {

                _IsTips = value;
                OnPropertyChanged(nameof(IsTips));
            }
        }

        private bool _IsFAQ = false;
        public bool IsFAQ
        {
            get { return _IsFAQ; }
            set
            {

                _IsFAQ = value;
                OnPropertyChanged(nameof(IsFAQ));
            }
        }

        private bool _IsMyOrders = false;
        public bool IsMyOrders
        {
            get { return _IsMyOrders; }
            set
            {

                _IsMyOrders = value;
                OnPropertyChanged(nameof(IsMyOrders));
            }
        }

        private bool _IsMyProfile = false;
        public bool IsMyProfile
        {
            get { return _IsMyProfile; }
            set
            {

                _IsMyProfile = value;
                OnPropertyChanged(nameof(IsMyProfile));
            }
        }

        #endregion

    }
}
