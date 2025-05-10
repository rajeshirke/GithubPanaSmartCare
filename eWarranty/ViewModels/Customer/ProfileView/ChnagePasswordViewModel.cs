using System;
using System.Text.RegularExpressions;
using eWarranty.Core.Enums;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.ProfileView
{
    public class ChnagePasswordViewModel : BaseViewModel
    {
        public ChnagePasswordViewModel(INavigation navigation) : base(navigation)
        {
            IsPassword = true;
            Email = CommonAttribute.CustomeProfile.Email;
            Name = CommonAttribute.CustomeProfile.FirstName + "" + CommonAttribute.CustomeProfile.LastName;
            //CommonAttribute.Custpwd

        }
        public Command UpdateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (string.IsNullOrEmpty(Password))
                        {
                            await ErrorDisplayAlert(AppResources.lblEnterPassword);
                            return;
                        }
                        string cPassword = Application.Current.Properties["currentpassword"].ToString();
                        if (Password != cPassword)
                        {
                            await ErrorDisplayAlert(AppResources.lblIncorrectPassword);
                            return;
                        }
                        if (string.IsNullOrEmpty(NewPassword))
                        {
                            await ErrorDisplayAlert(AppResources.lblPleaseEnterNewPassword);
                            return;
                        }
                        if (Password == NewPassword)
                        {
                            await ErrorDisplayAlert(AppResources.lblPasswordNotMatch);
                            return;
                        }

                        if (NewPassword != null)
                        {
                            var hasMiniMaxChars = new Regex(@".{4,15}");
                            if (!hasMiniMaxChars.IsMatch(NewPassword))
                            {
                                await ErrorDisplayAlert(AppResources.lblEnterNewPassword);
                                return;
                            }
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
                        passwordRequestModel.CurrentPassword = Password;
                        passwordRequestModel.ConfirmPassword = ConfirmPassword;
                        passwordRequestModel.NewPassword = NewPassword;
                        passwordRequestModel.Language = CommonAttribute.selectedLang.LongName;
                        passwordRequestModel.UserID = CommonAttribute.CustomeProfile.UserId;
                        var receiveContext = await userManagementSL.ChangePassword(passwordRequestModel);
                        if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
                        {
                            await DisplayAlert(AppResources.lblSuccess, AppResources.msgPasswordchangedsuccessfully);
                            await Navigation.PopAsync();
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
                        IsBusy = false;
                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }

                    
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
        private bool ValidatePassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception(AppResources.lblErrorEmptyPassword);
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = AppResources.lblErrorMoreCharacter;
                return false;
            }
            else if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = AppResources.lblErrorLowerCaseLetter;
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = AppResources.lblErrorUpperCaseLetter;
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = AppResources.lblErrorMoreCharacter;
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = AppResources.lblErrorNumericValue;
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = AppResources.lblErrorSpecialCharacter;
                return false;
            }
            else
            {
                return true;
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

    }
}
