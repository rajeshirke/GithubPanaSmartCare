using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Controls;
using eWarranty.Core.Common;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.DependencyServices;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.Views.Account;
using eWarranty.Views.AppOnBoard;
using eWarranty.Views.Customer;
using eWarranty.Views.Customer.DashBoardView;
using eWarranty.Views.Supervisor;
using eWarranty.Views.Technician;
using Xamarin.Essentials;
using Xamarin.Forms;
using Extensions = eWarranty.Hepler.Extensions;

namespace eWarranty.ViewModels.Account
{
    public class LoginViewModel: BaseViewModel
    {
        public LoginViewModel(INavigation navigation) : base(navigation)
        {
            try
            {
                IsPassword = true;
                IspsswordSave = true;
                languages = Extensions.Getlanguages();
                Device.BeginInvokeOnMainThread(async () => {
                    await BindingData();
                    IsBusy = false;
                });
                IsBusy = false;
            }
            catch (Exception ex)
            {

            }
        }
        public async Task BindingData()
        {
            try
            {
                CommonAttribute.selectedLang = languages[0];
                //if (Application.Current.Properties.ContainsKey("email") && Application.Current.Properties.ContainsKey("password"))
                //{
                //    if (loginRequest == null)
                //        loginRequest = new LoginRequest();

                //    loginRequest.email = Application.Current.Properties["email"].ToString();
                //    loginRequest.username = Application.Current.Properties["email"].ToString();
                //    loginRequest.password = Application.Current.Properties["password"].ToString();
                //  //  await SiginSubmit();
                //}
            }
            catch (Exception ex)
            {

            }
            //Application.Current.Properties["password"] = loginRequest.email;


        }
        public LoginRequest loginRequest { get; set; }
        public async Task SiginSubmit()
        {
            try
            {
                IsBusy = true;

                Device.BeginInvokeOnMainThread(async () => {
                    
                    await  Task.Delay(20);
                    String CurrentVersionStr = VersionTracking.CurrentVersion;
                    int CurrentVersionInt = 0;

                    if (!string.IsNullOrEmpty(CurrentVersionStr))
                    {
                        String[] CurrentVersionArr = CurrentVersionStr.Split('.');
                        if (CurrentVersionArr.Length >= 3)
                        {
                            int.TryParse(CurrentVersionArr[2], out CurrentVersionInt);
                        }
                    }

                    // UserDialogs.Instance.ShowLoading("Loading..");
                    UserManagementSL userManagementSL = new UserManagementSL();
                    if(loginRequest == null)
                        loginRequest = new LoginRequest();
#if (DEBUG)
                    //if (string.IsNullOrEmpty(Email))
                    //{
                    //    Email = "akash.customer@gmail.com";
                    //    Password = "Password.01";
                    //}
                    //else
                    //{
                    //    Email = "akash.tech2@gmail.com";
                    //    Password = "Password.01";
                    //}
#else
                    loginRequest.email = Email;
                    loginRequest.username = Email;
                    loginRequest.password = Password;
                    loginRequest.versionNumber = CurrentVersionInt;
#endif

                    loginRequest.email = Email;
                    loginRequest.username = Email;
                    loginRequest.password = Password;
                    loginRequest.versionNumber = CurrentVersionInt;

                    if (!await validation())
                    {
                        IsBusy = false;
                        return;
                    }



                    ReceiveContext<PersonLoginResponse> receiveContext = await userManagementSL.ValidateUser(loginRequest);
                    //role tech 
                    if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
                    {
                       
                        CommonAttribute.Custpwd = loginRequest.password;
                        CommonAttribute.CustomeProfile = receiveContext.data;                        

                        Application.Current.Properties["currentpassword"] = loginRequest.password;
                        //  CommonAttribute.Custpwd = Password;
                        if (IspsswordSave)
                        {
                            Application.Current.Properties["email"] = loginRequest.email;
                            Application.Current.Properties["password"] = loginRequest.password;
                        }
                        if (receiveContext.data.PersonRoleId == Convert.ToInt16(PersonRoleEnum.Customer))
                        {
                            try
                            {
                                if (VersionTracking.IsFirstLaunchEver)
                                {
                                    Navigation.PushAsync(new AppOnBoardPage());
                                }
                                else
                                    Application.Current.MainPage = new DashBoadMasterPage();
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        else if (receiveContext.data.PersonRoleId == Convert.ToInt16(PersonRoleEnum.Technician))
                        {
                            //CommonAttribute.CustomeProfile = receiveContext.data;
                            Application.Current.MainPage = new TechMasterPage();
                        }
                        else if (receiveContext.data.PersonRoleId == Convert.ToInt16(PersonRoleEnum.Supervisor))
                        {
                            //CommonAttribute.CustomeProfile = receiveContext.data;
                            Application.Current.MainPage = new SupDashboardLeftSideMenu();
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("", AppResources.msgInvalidloginattempt, AppResources.lblCancel);
                        }

                        IsBusy = false;
                    }
                    else if (receiveContext != null)
                    {
                        IsBusy = false;
                        if (receiveContext.errorMessage.ToLower().Contains("invalid login attempt"))
                        {
                            await Application.Current.MainPage.DisplayAlert("", AppResources.msgInvalidloginattempt, AppResources.lblCancel);
                        }
                        else if (receiveContext.errorMessage.ToLower().Contains("with entered details"))
                        {
                            await Application.Current.MainPage.DisplayAlert("", AppResources.msgUserwiththeentereddetailsdoesnotexists, AppResources.lblCancel);
                        }
                        else if (receiveContext.errorMessage.ToLower().Contains("password is incorrect"))
                        {
                            await Application.Current.MainPage.DisplayAlert("", AppResources.msgYourpasswordisincorrect, AppResources.lblCancel);
                        }
                        else if (receiveContext.errorMessage.ToLower().Contains("update the App"))
                        {
                            await Application.Current.MainPage.DisplayAlert("", AppResources.msgUpdatetheapp, AppResources.lblCancel);
                        }

                        //if (!receiveContext.errorMessage.ToLower().Contains("create password"))                       
                        //await Application.Current.MainPage.DisplayAlert("", receiveContext.errorMessage, AppResources.lblCancel);
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("", receiveContext.errorMessage, AppResources.lblCancel);
                        }
                    }
                    else
                    {
                        await ErrorDisplayAlert(AppResources.servererror);
                        IsBusy = false;
                    }

                   //  string str = Email;
                   // string strPwd = Password;
                   //  CustomNavigationPage navigationPage = new CustomNavigationPage(new DashBoadMasterPage());
                   // masterPage.navigationPage
                   //   navigationPage.BarBackgroundColor = Color.Transparent;
               
                });
                //  Navigation.PushAsync(new Views.Customer.Products.ProductsPage());

            }
            catch (Exception ex)
            {

            }
        }
        public async Task<bool>  validation()
        {
            if (string.IsNullOrEmpty(Email))
            {
             await   Application.Current.MainPage.DisplayAlert(Resx.AppResources.lblErrorTitle, AppResources.lblEnteremailormobileno, Resx.AppResources.lblCancel);
                return false;
            }
            //if (!eWarranty.Hepler.Extensions.EmailValidation(Email))
            //{
            //  await  Application.Current.MainPage.DisplayAlert(Resx.AppResources.lblErrorTitle, "Please enter email or mobile number.", Resx.AppResources.lblCancel);
            //    return false;
            //}
            if (string.IsNullOrEmpty(Password))
            {
              await  Application.Current.MainPage.DisplayAlert(Resx.AppResources.lblErrorTitle, AppResources.lblCheckEnteredEmailMob, Resx.AppResources.lblCancel);
                return false;
            }
            return true;
        }
        //
        #region Events
        public Command SignUpCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new SignUpPage());
                });
            }
        }
        public Command ForgotPwdCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new ForgotPasswordPage(Email));
                });
            }
        }
        public Command SelectedSavePasswordCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (IspsswordSave)
                        IspsswordSave = false;
                    else
                        IspsswordSave = true;
                });
            }
        }

        public Command SignInCommand
        {
            get
            {
                return new Command(async () =>
                {
                    //if (await validation())
                    //{
                        await SiginSubmit();
                   // }

                });
            }
        }
        public Command IsPasswordCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsPassword = !IsPassword;
                });
            }
        }
        #endregion


        #region Properties
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
        private bool  _IspsswordSave;
        public bool IspsswordSave
        {
            get { return _IspsswordSave; }
            set
            {
                _IspsswordSave = value;
                OnPropertyChanged("IspsswordSave");
            }
        }
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged("Password");
            }
        }

        private bool _IsPassword;
        public bool IsPassword
        {
            get { return _IsPassword; }
            set
            {
                _IsPassword = value;
                OnPropertyChanged(nameof(IsPassword));
                OnPropertyChanged(nameof(IsPasswordIcon));
            }
        }
        private string _IsPasswordIcon;
        public string IsPasswordIcon
        {
            get
            {
                if (IsPassword)
                {
                    // _IsPasswordIcon = "eyeshow";
                    _IsPasswordIcon = Solid.Eye;
                }
                else
                {
                    //_IsPasswordIcon = "eyehide";
                    _IsPasswordIcon = Solid.Eye_Slash;

                }
                return _IsPasswordIcon;
            }
        }

        public List<LanguageModel> languages { get; set; }
        public LanguageModel SelectedLanguage { get; set; }
        #endregion
    }
}
