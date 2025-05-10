using System;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.Views.Account;
using Xamarin.Forms;
using eWarranty.Core.Enums;
using eWarranty.Core.ResponseModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using eWarranty.Controls;
using Rg.Plugins.Popup.Services;
using System.Text.RegularExpressions;
using eWarranty.Views.Customer;
using System.Threading;

namespace eWarranty.ViewModels.Account
{
    public class SignUpViewModel : BaseViewModel
    {
        public SignUpViewModel(INavigation navigation) : base(navigation)
        {
           
            Device.BeginInvokeOnMainThread( async() =>
            {
                await  BindingData();
               
            });
        }
        public async Task BindingData()
        {
            try
            {
                IsBusy = true;
                Thread.Sleep(1000);
                //PhoneCode = "+971";
                if (AccountDetails == null)
                    AccountDetails = new AccountDetails();
                MasterDataManagementSL dataManagementSL = new MasterDataManagementSL();
                CountryResponses = await dataManagementSL.GetActiveCountryList();
                if (CountryResponses != null)
                {
                    if (AllCountries == null)
                        AllCountries = new ObservableCollection<DropDownModel>();
                    foreach (var item in CountryResponses)
                    {

                        DropDownModel dropDownModel = new DropDownModel();
                        dropDownModel.Id = item.CountryId;
                        dropDownModel.Title = item.Name;
                        if (item.PhoneCode == 971)
                        {
                            SelectCountry = dropDownModel;
                            SelectedCountryResponse = item;
                        }
                        AllCountries.Add(dropDownModel);

                    }
                }
                else
                {
                  await   ErrorDisplayAlert(AppResources.servererror);
                }
                IsBusy = false;

                //country = await dataManagementSL.GetCountryDetailsByCode(CommonAttribute.UserLocation.CountryCode);
                //if (country != null)
                //{
                //    PhoneCode = "+" + country.PhoneCode.ToString();
                //}
                //else
                //{
                //    await ErrorDisplayAlert("GPS location not fount. Please try again.");
                //    await Navigation.PopAsync();
                //    PhoneCode = "+971";
                //}
            }
            catch (Exception ex)
            {
                await ErrorDisplayAlert(AppResources.servererror);
                await Navigation.PopAsync();
                IsBusy = false;
            }
            
            // AccountDetails.Name = "kumar";
           
        }
        #region Event
        public Command TermsConditionCommand
        {
            get
            {
                return new Command(async () =>
                {
                   
                    await Navigation.PushModalAsync(new TermsofServicePage("https://mastcgroup.com/privacy-policy/"));
                });
            }
        }
        public Command TermsConditionCommand2
        {
            get
            {
                return new Command(async () =>
                {
                  //  IsBusy = true;
                    await Navigation.PushModalAsync(new TermsofServicePage("https://mastcgroup.com/privacy-policy/"));
                });
            }
        }
        public Command LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Navigation.PopAsync();
                });
            }
        }
       
        public Command CountryChangeCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (AllCountries != null && AllCountries.Count > 0)
                        {
                            DropDownPopupPage dropDownPopup = new DropDownPopupPage();
                            dropDownPopup.Title = AppResources.lblSelectCountry;
                            dropDownPopup.DropDownSelectedItem += DropDownPopup_DropDownSelectedItem; ;
                            dropDownPopup.PickerItemsSource = AllCountries;
                            dropDownPopup.MasterData = AllCountries.ToList();
                            await PopupNavigation.PushAsync(dropDownPopup);
                        }
                        
                    }
                    catch (Exception ex)
                    {

                    }
                   
                    //SelectCountry = item;
                    //if (SelectCountry != null)
                    //{
                    //    SelectedCountryResponse = CountryResponses.Where(u => u.CountryId == SelectCountry.Id).FirstOrDefault();
                    //    //  Navigation.PushAsync(new ProductSuccessPage());
                    //}
                });
            }
        }
        private void DropDownPopup_DropDownSelectedItem(object sender, EventArgs e)
        {
            try
            {
                DropDownPopupPage control = sender as DropDownPopupPage;
                SelectCountry = control.SelectedItem as DropDownModel;
                SelectedCountryResponse = CountryResponses.Where(u => u.CountryId == SelectCountry.Id).FirstOrDefault();

            }
            catch (Exception ex)
            {

            }
           
        }
        public Command OTPCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (await Validation())
                        {
                            IsBusy = true;
                            string fname = string.Empty;
                            string lname = "";
                            string[] names = AccountDetails.Name.Split(' ');
                            if (names.Length != 0)
                                fname = names[0];

                            for (int i = 1; i < names.Length; i++)
                            {
                                lname = lname + names[i];
                            }


                            UserManagementSL userManagementSL = new UserManagementSL();
                            PersonRegisterRequest person = new PersonRegisterRequest();
                            person.Email = AccountDetails.Email;
                            if (!string.IsNullOrEmpty(AccountDetails.ContactNumber))
                            {
                                person.MobileNumber = PhoneCode + AccountDetails.ContactNumber;
                            }
                            person.FirstName = fname;
                            person.LastName = lname;
                            if(!string.IsNullOrEmpty(person.Email))
                              person.IsEmailValidated = true;
                            else
                                person.IsEmailValidated = false;
                            if (!string.IsNullOrEmpty(person.MobileNumber))
                                person.IsMobileValidated = true;
                            else
                                person.IsMobileValidated = false;

                           
                            person.PreferredLanguageId = CommonAttribute.selectedLang.lid;
                            person.CountryId = SelectedCountryResponse.CountryId;
                            person.PersonRoleId = Convert.ToInt16(PersonRoleEnum.Customer);
                            person.PersonPassword = Password;
                            ReceiveContext<PersonLoginResponse> receiveContext = await userManagementSL.Register(person);
                            if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
                            {
                                IsBusy = true;
                                CommonAttribute.CustomeProfile = receiveContext.data;
                                await Navigation.PushAsync(new VerifyPhonePage("signup"));
                            }
                            else
                            {
                                IsBusy = false;
                                if (receiveContext != null)
                                  await Application.Current.MainPage.DisplayAlert("", receiveContext.errorMessage, AppResources.lblCancel);

                                else
                                {
                                    IsBusy = false;
                                    await ErrorDisplayAlert(AppResources.lblAPIError);
                                }
                            }
                            IsBusy = false;
                        }
                        IsBusy = false;
                    }
                    catch (Exception ex)
                    {

                    }

                });
            }
        }
        public ICommand NextCommand { get; set; }

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
        //TermsConditionCommand
        async Task<bool> Validation()
        {
            try
            {
                if (string.IsNullOrEmpty(AccountDetails.Name))
                {
                    await ErrorDisplayAlert(AppResources.lblErrorName);
                    return false;
                }
                if (string.IsNullOrEmpty(AccountDetails.Email))
                {
                    await ErrorDisplayAlert(AppResources.lblErrorEmail);
                    return false;
                }
                if (string.IsNullOrEmpty(AccountDetails.Email) && string.IsNullOrEmpty(AccountDetails.ContactNumber))
                {
                    await ErrorDisplayAlert(AppResources.lblEnteremailormobileno);
                    return false;
                }
                else
                {
                    //if (!Extensions.EmailValidation(AccountDetails.Email))
                    //{
                    //    await ErrorDisplayAlert(AppResources.lblErrorValidEmail);
                    //    return false;
                    //}
                    //else
                    //{
                    if (!string.IsNullOrEmpty(AccountDetails.Email) && !Extensions.EmailValidation(AccountDetails.Email))
                    {
                        await ErrorDisplayAlert(AppResources.lblErrorValidEmail);
                        return false;
                    }
                    if (string.IsNullOrEmpty(AccountDetails.Email))
                    {
                        if (AccountDetails.ContactNumber != null && AccountDetails.ContactNumber.Length < 6)
                        {
                            await ErrorDisplayAlert(AppResources.lblValidMobileNo);
                            return false;
                        }
                    }
                    //}
                    if (SelectCountry == null)
                    {
                        await ErrorDisplayAlert(AppResources.lblSelectCountry);
                        return false;
                    }
                    //Password
                    if (string.IsNullOrEmpty(Password))
                    {
                        await ErrorDisplayAlert(AppResources.lblEnterPassword);
                        return false;
                    }
                    if (Password != null)
                    {
                        var hasMiniMaxChars = new Regex(@".{4,15}");
                        if (!hasMiniMaxChars.IsMatch(Password))
                        {
                            await ErrorDisplayAlert(AppResources.lblEnterNewPassword);
                            return false;
                        }

                    }
                    if (string.IsNullOrEmpty(ConfirmPassword))
                    {
                        await ErrorDisplayAlert(AppResources.lblConfirmPassword);
                        return false;
                    }
                    if (Password != ConfirmPassword)
                    {
                        await ErrorDisplayAlert(AppResources.lblPasswordNotMatch);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
           
            //if (!string.IsNullOrEmpty(AccountDetails.ContactNumber))
            //{
            //    if (string.IsNullOrEmpty(AccountDetails.Email))
            //    {
            //        await ErrorDisplayAlert(AppResources.lblErrorEmail);
            //        return false;
            //    }
            //    else
            //    {
            //        if (!Extensions.EmailValidation(AccountDetails.Email))
            //        {
            //            await ErrorDisplayAlert(AppResources.lblErrorValidEmail);
            //            return false;
            //        }
            //        if (AccountDetails.ContactNumber.Length < 6)
            //        {
            //            await ErrorDisplayAlert("Please enter valide mobile number.");
            //            return false;
            //        }
            //    }
            //}
            ////EmailValidation
            //if (!string.IsNullOrEmpty(AccountDetails.Email))
            //{
            //    if (string.IsNullOrEmpty(AccountDetails.ContactNumber))
            //    {
            //        await ErrorDisplayAlert(AppResources.lblErrorContactNumber);
            //        return false;
            //    }
            //    else
            //    {
            //        if (AccountDetails.ContactNumber.Length < 6)
            //        {
            //            await ErrorDisplayAlert("Please enter valide mobile number.");
            //            return false;
            //        }




            //    }
            //}
           
            return true;
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
                ErrorMessage = AppResources.lblNewPassword;
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
        public bool EmailorMobile()
        {

            return true;
        }


        #endregion

        #region properties

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

        public List<CountryResponse> CountryResponses  { get; set; }
        //public CountryResponse SelectedCountryResponse { get; set; }
        private CountryResponse _SelectedCountryResponse;
        public CountryResponse SelectedCountryResponse
        {
            get { return _SelectedCountryResponse; }
            set
            {
                _SelectedCountryResponse = value;
                PhoneCode = "+"+value.PhoneCode.ToString();
                OnPropertyChanged("SelectedCountryResponse");
            }
        }
        private ObservableCollection<DropDownModel> _AllCountries;
        public ObservableCollection<DropDownModel> AllCountries
        {
            get { return _AllCountries; }
            set
            {
                _AllCountries = value;
                OnPropertyChanged("AllCountries");
            }
        }
        private DropDownModel _SelectCountry;
        public DropDownModel SelectCountry
        {
            get { return _SelectCountry; }
            set
            {
                _SelectCountry = value;
                OnPropertyChanged("SelectCountry");
            }
        }
        public CountryResponse country { get; set; }
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
        //PhoneCode
        private string _PhoneCode;
        public string PhoneCode
        {
            get { return _PhoneCode; }
            set
            {
                _PhoneCode = value;
                OnPropertyChanged("PhoneCode");
            }
        }
        //Password
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
        private AccountDetails accountDetails;
        public AccountDetails AccountDetails
        {
            get { return accountDetails; }
            set
            {
                accountDetails = value;
                OnPropertyChanged("AccountDetails");
            }
        }

        //
        #endregion


    }
}
