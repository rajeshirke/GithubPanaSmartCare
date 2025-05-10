using System;
using System.Windows.Input;
using eWarranty.Core.Enums;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Resx;
using eWarranty.Views.Customer;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Account
{
    public class PasswordSetupViewModel : BaseViewModel
    {
        public PasswordSetupViewModel(INavigation navigation) : base(navigation)
        {
           
        }
        #region events

        public Command NextCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (string.IsNullOrEmpty(Password))
                    {
                        await Application.Current.MainPage.DisplayAlert("", AppResources.lblEnteremailormobileno, AppResources.lblCancel);
                        return;
                    }

                    if (string.IsNullOrEmpty(ConfirmPassword))
                    {
                        await Application.Current.MainPage.DisplayAlert("", AppResources.lblConfirmPassword, AppResources.lblCancel);
                        return;
                    }
                    if (Password != ConfirmPassword)
                    {
                        await ErrorDisplayAlert(AppResources.lblPasswordNotMatch);
                        return;
                    }
                    IsBusy = true;
                    UserManagementSL userManagementSL = new UserManagementSL();
                    PasswordRequestModel passwordRequest = new PasswordRequestModel();
                    passwordRequest.NewPassword = Password;
                    passwordRequest.CurrentPassword = Password;
                    passwordRequest.ConfirmPassword = ConfirmPassword;
                    passwordRequest.Email = CommonAttribute.CustomeProfile.Email;
                    passwordRequest.Language = CommonAttribute.selectedLang.LongCode;
                    passwordRequest.UserID = CommonAttribute.CustomeProfile.UserId;
                    var receiveContext = await userManagementSL.ChangePassword(passwordRequest);
                    IsBusy = false;
                    if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
                    {
                        Application.Current.MainPage = new DashBoadMasterPage();
                    }
                    else if (receiveContext != null && receiveContext.status == -1)
                    {
                        await ErrorDisplayAlert(receiveContext.message);
                    }
                    else if (receiveContext != null)
                    {
                        await ErrorDisplayAlert(receiveContext.errorMessage);
                    }
                    else
                    {
                        await ErrorDisplayAlert(Resx.AppResources.lblErrorTitle);
                    }
                    

                });
            }
        }
        #endregion

        #region Properties
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged("Name");
            }
        }

        private string _ConfirmPassword;
        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set
            {
                _ConfirmPassword = value;
                OnPropertyChanged("ConfirmPassword");
            }
        }
        #endregion
    }
}
