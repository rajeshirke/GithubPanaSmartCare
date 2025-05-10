using System;
using System.Text.RegularExpressions;
using eWarranty.Core.Enums;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Resx;
using eWarranty.Views.Account;
using eWarranty.Views.Customer;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Account
{
    public class ForgotPagePasswordViewModel : BaseViewModel
    {
        public ForgotPagePasswordViewModel(INavigation navigation) : base(navigation)
        {
            Name = CommonAttribute.CustomeProfile.FirstName + " " + CommonAttribute.CustomeProfile.LastName;
        }
        public Command SubmitCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (string.IsNullOrEmpty(NewPassword))
                        {
                            await ErrorDisplayAlert(AppResources.lblEnterPassword);
                            return;
                        }
                        var hasMiniMaxChars = new Regex(@".{4,15}");
                        if (!hasMiniMaxChars.IsMatch(NewPassword))
                        {
                            await ErrorDisplayAlert(AppResources.lblEnterNewPassword);
                            return;
                        }
                        if (string.IsNullOrEmpty(ConfirmPassword))
                        {
                            await ErrorDisplayAlert(AppResources.lblConfirmPassword);
                            return;
                        }
                        if (NewPassword != ConfirmPassword)
                        {
                            await ErrorDisplayAlert(AppResources.lblPasswordNotMatch);
                            return;
                        }
                        IsBusy = true;
                        UserManagementSL userManagementSL = new UserManagementSL();
                        PasswordRequestModel passwordRequestModel = new PasswordRequestModel();
                        passwordRequestModel.Email = CommonAttribute.CustomeProfile.Email;
                        passwordRequestModel.CurrentPassword = "";
                        passwordRequestModel.ConfirmPassword = ConfirmPassword;
                        passwordRequestModel.NewPassword = NewPassword;
                        passwordRequestModel.Language = CommonAttribute.selectedLang.LongName;
                        passwordRequestModel.UserID = CommonAttribute.CustomeProfile.UserId;
                        var receiveContext = await userManagementSL.ChangePassword(passwordRequestModel);
                        if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
                        {
                            Application.Current.MainPage = new LoginPage();      //DashBoadMasterPage();
                        }
                        else if (receiveContext != null)
                        {
                            IsBusy = false;

                            await Application.Current.MainPage.DisplayAlert("", receiveContext.errorMessage, AppResources.lblCancel);
                        }
                        else
                        {
                            await ErrorDisplayAlert(AppResources.lblAPIError);
                            IsBusy = false;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                   
                });
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
        private string _NewPassword;
        public string NewPassword
        {
            get { return _NewPassword; }
            set
            {
                _NewPassword = value;
                OnPropertyChanged("NewPassword");
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
    }
}
