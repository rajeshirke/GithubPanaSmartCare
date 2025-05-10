using System;
using System.Windows.Input;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Resx;
using eWarranty.Views.Account;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Account
{
    public class ForgotPasswordViewModel:BaseViewModel
    {
        public ForgotPasswordViewModel(INavigation navigation) : base(navigation)
        {
            BindingData();
        }
        public void BindingData()
        {
            try
            {
                SuccessView = false;
                FirstView = true;
                SendRequestCommand = new Command(async () =>
                {
                    if (validation())
                    {
                        IsBusy = true;
                        UserManagementSL userManagement = new UserManagementSL();
                        ForgotPasswordRequest forgotPassword = new ForgotPasswordRequest();
                        forgotPassword.username = Email;
                        ReceiveContext<PersonLoginResponse> receiveContext = await userManagement.ForgotPassword(forgotPassword);
                        if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
                        {
                            IsBusy = false;
                            SuccessView = true;
                            FirstView = false;
                            CommonAttribute.CustomeProfile = receiveContext.data;

                            await Navigation.PushAsync(new VerifyPhonePage("forgot"));
                        }
                        else if (receiveContext != null)
                        {
                            IsBusy = false;

                            await Application.Current.MainPage.DisplayAlert("", AppResources.msgUserwiththeentereddetailsdoesnotexists, AppResources.lblOk);
                        }
                        else
                        {
                            await ErrorDisplayAlert(AppResources.lblAPIError);
                            IsBusy = false;
                        }

                    }
                    // Navigation.PushAsync(new ForgotPasswordPage());
                });
            }
            catch (Exception ex)
            {

            }
            
        }
        public ICommand SendRequestCommand { get; set; }
        public bool validation()
        {
            if (string.IsNullOrEmpty(Email))
            {
               // await Application.Current.MainPage.DisplayAlert(Resx.AppResources.lblErrorTitle, , Resx.AppResources.lblCancel);
                Application.Current.MainPage.DisplayAlert(Resx.AppResources.lblErrorTitle, AppResources.lblEnteremailormobileno, Resx.AppResources.lblCancel);
                return false;
            }
           
            return true;
        }
        public Command SignInCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await   Navigation.PopAsync();

                });
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
        private bool _SuccessView;
        public bool SuccessView
        {
            get { return _SuccessView; }
            set
            {
                _SuccessView = value;
                OnPropertyChanged("SuccessView");
            }
        }
        private bool _FirstView;
        public bool FirstView
        {
            get { return _FirstView; }
            set
            {
                _FirstView = value;
                OnPropertyChanged("FirstView");
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

    }
}
