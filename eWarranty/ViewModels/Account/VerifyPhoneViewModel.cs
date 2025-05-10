using System;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Enums;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Resx;
using eWarranty.Views.Account;
using eWarranty.Views.Customer;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Account
{
    public class VerifyPhoneViewModel : BaseViewModel
    {
        public string rootPageName { get; set; }
        public VerifyPhoneViewModel(INavigation navigation, string pageName) : base(navigation)
        {
            rootPageName = pageName;
            MobileNumber = CommonAttribute.CustomeProfile.MobileNumber;
            Email = CommonAttribute.CustomeProfile.Email;

            NextCommand = new Command(async () =>
            {
                IsBusy = true;
                try
                {
                   if(N1 == null && N1 == null && N1 == null && N1 == null)
                    {
                        await ErrorDisplayAlert(AppResources.lblEnterOTP);
                        IsBusy = false;
                        return;
                    }
                    UserManagementSL userManagementSL = new UserManagementSL();
                    UserTokenValidateReq userToken = new UserTokenValidateReq();
                  //  userToken.tokenId = 0;
                  //  userToken.tokenContextId = 1;
                    userToken.userId = CommonAttribute.CustomeProfile.UserId.ToString();
                    userToken.value = N1 + "" + N2 + "" + N3 + "" + N4;
                    userToken.email = CommonAttribute.CustomeProfile.Email;
                    userToken.phoneNumber = CommonAttribute.CustomeProfile.MobileNumber;
                    userToken.tokenContextId = Convert.ToInt16(TokenContextEnum.OneTimePassword);
                    ValidateTokenResponse tokenResponse = null;
                    //VerifyEmailMobileTokenForgetPassword
                    if (rootPageName == "signup")
                         tokenResponse = await userManagementSL.UserTokenValidate(userToken);
                    else
                        tokenResponse = await userManagementSL.VerifyEmailMobileTokenForgetPassword(userToken);

                    if (tokenResponse.Success)
                    {
                        // Application.Current.MainPage = new DashBoadMasterPage();
                        //if(rootPageName == "signup") 
                        //   await navigation.PushAsync(new SingUpProfileUpdatePage());
                        //  else if (rootPageName == "forgot")
                        //      await navigation.PushAsync(new ForgotPagePasswordUpdate());

                        await navigation.PushAsync(new AccountVerifiedSuccessPage());
                    }
                    else
                    {
                       await Application.Current.MainPage.DisplayAlert("", AppResources.lblErrorIncorrectToken, AppResources.lblCancel);
                    }
                    IsBusy = false;
                }
                catch (Exception ex)
                {
                    IsBusy = false;
                }
               
            });
        }
        public async Task ResendOtp()
        {
            IsBusy = true;
            try
            {
                N1 = null;
                N2 = null;
                N3 = null;
                N4 = null;

                UserManagementSL userManagementSL = new UserManagementSL();
                UserTokenValidateReq userToken = new UserTokenValidateReq();
                //  userToken.tokenId = 0;
               
                var tokenResponse = await userManagementSL.ResendOTP(CommonAttribute.CustomeProfile.UserId.ToString());
                if (tokenResponse.Status == 1)
                {
                  await  DisplayAlert("", AppResources.lblNewOTP);
                    // Application.Current.MainPage = new DashBoadMasterPage();
                   // await Navigation.PushAsync(new SingUpProfileUpdatePage());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("", tokenResponse.ErrorMessage, AppResources.lblCancel);
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
        }
        public async Task<bool> Validation()
        {
            if(N1 != 0 && N2 !=0 & N3 !=0 & N4 !=0)
            {
                await Application.Current.MainPage.DisplayAlert("", AppResources.lblEnterOTP, AppResources.lblCancel);
                return false;
            }
            return true;
        }
        #region events
        public ICommand NextCommand { get; set; }
        public Command ReSendCommand
        {
            get
            {
                return new Command(() =>
                {
                    ///api/UserToken/GenerateToken
                });
            }
        }
        #endregion
        private int? _N1;
        public int? N1
        {
            get { return _N1; }
            set
            {
                _N1 = value;
                OnPropertyChanged("N1");
            }
        }
        private int? _N2;
        public int? N2
        {
            get { return _N2; }
            set
            {
                _N2 = value;
                OnPropertyChanged("N2");
            }
        }
        private int? _N3;
        public int? N3
        {
            get { return _N3; }
            set
            {
                _N3 = value;
                OnPropertyChanged("N3");
            }
        }
        private int? _N4;
        public int? N4
        {
            get { return _N4; }
            set
            {
                _N4 = value;
                OnPropertyChanged("N4");
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
    }
}
