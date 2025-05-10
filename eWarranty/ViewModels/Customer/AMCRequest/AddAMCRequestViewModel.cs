using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Controls;
using eWarranty.Core.Common;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.Views.Account;
using eWarranty.Views.Customer.AMCRequest;
using eWarranty.Views.Customer.InquiryView;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace eWarranty.ViewModels.Customer.AMCRequest
{
    public class AddAMCRequestViewModel : BaseViewModel
    {
        public ICommand SelectTileCommand { get; set; }

        public AddAMCRequestViewModel(INavigation navigation) : base(navigation)
        {
            BindingData();
            IsServices = true;
        }

        #region methods
        public void BindingData()
        {
            try
            {
                //{http://devsrv01.panasonic.ae:83/images/productImages/defaultprod.png}
                ProductModel = CommonAttribute.SRInputModel.ProductModelWarrantyResponse;
                if (Years == null)
                    Years = new List<DropDownModel>();
                Years.Add(new DropDownModel() { Id = 1, Title = "1" });
                Years.Add(new DropDownModel() { Id = 1, Title = "2" });
                Years.Add(new DropDownModel() { Id = 1, Title = "3" });
                Years.Add(new DropDownModel() { Id = 1, Title = "4" });

                if (Months == null)
                    Months = new List<DropDownModel>();
                for (int i = 1; i < 12; i++)
                {
                    Months.Add(new DropDownModel() { Id = 1, Title = i.ToString() });
                }

                SelectedYearCommand = new Command<object>((item) =>
                {
                    SelectedYear = item as DropDownModel;

                });
                SelectedMonthCommand = new Command<object>((item) =>
                {
                    SelectedMonth = item as DropDownModel;

                });
                AddPromoCodeCommand = new Command(() =>
                {


                });
                AddNewCommand = new Command(async () =>
                {
                    if (SelectedddServiceCentor == null)
                    {
                        await ErrorDisplayAlert(AppResources.lblErrorSelectServiceCenter);
                        return;
                    }
                    if (SelectedAmcRequestMaster == null)
                    {
                        await ErrorDisplayAlert(AppResources.lblErrorSelectAMCType);
                        return;
                    }
                    if (IsCheckTandC == false)
                    {
                        await ErrorDisplayAlert(AppResources.lblSelectTandC);
                        return;
                    }
                    AmcRequestManagementSL requestManagementSL = new AmcRequestManagementSL();
                    AmcRequestCustomerRequest amcRequestCustomer = new AmcRequestCustomerRequest();
                    amcRequestCustomer.AmcrequestMasterId = SelectedAmcRequestMaster.AmcRequestMasterId;
                    amcRequestCustomer.ProductModelId = ProductModel.ProductModelID;
                    amcRequestCustomer.RequestedDate = DateTime.Now;
                    amcRequestCustomer.CustomerId = CommonAttribute.CustomeProfile.PersonId;
                    if (promoCode != null)
                        amcRequestCustomer.PromoCodeId = promoCode.PromoCodeId;

                    APIResponse receiveContext = await requestManagementSL.AmcRequestCustomers(amcRequestCustomer);
                    if (receiveContext?.Status == Convert.ToInt16(APIResponseEnum.Success))
                    {
                        await Navigation.PushAsync(new FeedBackSuccessPage("amcrequest"));
                    }
                    else if (receiveContext?.Status == Convert.ToInt16(APIResponseEnum.Failure))
                    {
                        string msg = CommonFunctions.GetMessagesByLanguage(receiveContext, CommonAttribute.selectedLang.lid);
                        await DisplayAlert(AppResources.lblErrorAlert, msg);
                    }
                    else
                    {
                        if (receiveContext != null)
                        {
                            await DisplayAlert(AppResources.lblError, receiveContext.ErrorMessage);
                        }
                        else
                        {
                            await ErrorDisplayAlert(AppResources.lblAPIError);
                        }
                    }
                });
            }
            catch (Exception ex)
            {

            }
            
        }
        #endregion

        #region events
        public Command ServiceCentersCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        ServiceCentersManagementSL serviceCentersManagementSL = new ServiceCentersManagementSL();

                        //List<ServiceCenter> respServiceCenter = await serviceCentersManagementSL.GetServiceCentersNearestToLocation(CommonAttribute.CustomeProfile.CountryId, CommonAttribute.UserLocation.Latitude, CommonAttribute.UserLocation.Longitude);
                        if (ProductModel?.ProductCategoryID != null && ProductModel?.ProductCategoryID > 0)
                        {
                            var ServiceCenterList = await serviceCentersManagementSL.GetServiceCentersNearestToLocationByProductCategoryId(CommonAttribute.CustomeProfile.CountryId, CommonAttribute.UserLocation.Latitude, CommonAttribute.UserLocation.Longitude, (long)ProductModel.ProductCategoryID);

                            if (ServiceCenterList != null)
                            {
                                List<ServiceCenter> respServiceCenter = ServiceCenterList;
                                ObservableCollection<ServiceCenter> ServiceCentors = new ObservableCollection<ServiceCenter>();
                                if (respServiceCenter != null)
                                {
                                    ServiceCentors = new ObservableCollection<ServiceCenter>(respServiceCenter);
                                }
                                if (ddServiceCentors == null)
                                    ddServiceCentors = new ObservableCollection<DropDownModel>();
                                ddServiceCentors.Clear();
                                foreach (var item in ServiceCentors)
                                {
                                    ddServiceCentors.Add(new DropDownModel() { Id = item.ServiceCenterId, Title = item.Name });
                                }
                                DropDownPopupPage dropDownPopup = new DropDownPopupPage();
                                dropDownPopup.Title = AppResources.lblSelectServiceCentor;
                                if (serviceCenter != null)
                                    dropDownPopup.Title = serviceCenter.Name;
                                dropDownPopup.DropDownSelectedItem -= DropDownPopup_DropDownSelectedItem; ;
                                dropDownPopup.DropDownSelectedItem += DropDownPopup_DropDownSelectedItem; ;
                                dropDownPopup.PickerItemsSource = ddServiceCentors;
                                dropDownPopup.MasterData = ddServiceCentors.ToList();
                                await PopupNavigation.PushAsync(dropDownPopup);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    

                });
            }
        }

        private async void DropDownPopup_DropDownSelectedItem(object sender, EventArgs e)
        {
            try
            {
                DropDownPopupPage control = sender as DropDownPopupPage;
                SelectedddServiceCentor = control.SelectedItem as DropDownModel;
                AmcRequestManagementSL managementSL = new AmcRequestManagementSL();
                List<AmcRequestMasterResponse> responseAmcRequestMasters = new List<AmcRequestMasterResponse>();
                if (IsOnlyService)
                {
                    responseAmcRequestMasters = await managementSL.GetAmcMasterByProductCategory(SelectedddServiceCentor.Id, Convert.ToInt32(ProductModel.ProductCategoryID), (int)AmcTypeEnum.OnlyService);
                }
                else if (IsPartsandServices)
                {
                    responseAmcRequestMasters = await managementSL.GetAmcMasterByProductCategory(SelectedddServiceCentor.Id, Convert.ToInt32(ProductModel.ProductCategoryID), (int)AmcTypeEnum.PartAndService);
                }

                if (responseAmcRequestMasters != null)
                {
                    //AmcRequestMasters = new ObservableCollection<AmcRequestMasterResponse>(responseAmcRequestMasters);
                    var AmcRequestMasters1 = new ObservableCollection<AmcRequestMasterResponse>();
                    if (IsOnlyService)
                    {
                        AmcRequestMasters1 = new ObservableCollection<AmcRequestMasterResponse>((responseAmcRequestMasters).Where(x => x.AmcTypeId == (int)AmcTypeEnum.OnlyService));
                        AmcRequestMasters1.ForEach(c => c.CurrencyCode = CommonAttribute.CustomeProfile?.CountryResponse?.CurrencyCode);
                    }
                    else if (IsPartsandServices)
                    {
                        AmcRequestMasters1 = new ObservableCollection<AmcRequestMasterResponse>((responseAmcRequestMasters).Where(x => x.AmcTypeId == (int)AmcTypeEnum.PartAndService));
                        AmcRequestMasters1.ForEach(c => c.CurrencyCode = CommonAttribute.CustomeProfile?.CountryResponse?.CurrencyCode);
                    }

                    if (AmcRequestMasters1 != null)
                    {
                        AmcRequestMasters = AmcRequestMasters1;
                    }
                }
            }
            catch (Exception ex)
            {

            }
           
        }

        public async void OnlyService()
        {
            try
            {
                AmcRequestManagementSL managementSL = new AmcRequestManagementSL();
                List<AmcRequestMasterResponse> responseAmcRequestMasters = await managementSL.GetAmcMasterByProductCategory(SelectedddServiceCentor.Id, Convert.ToInt32(ProductModel.ProductCategoryID), (int)AmcTypeEnum.OnlyService);
                if (responseAmcRequestMasters != null)
                {
                    var AmcRequestMasters1 = new ObservableCollection<AmcRequestMasterResponse>((responseAmcRequestMasters).Where(x => x.AmcTypeId == (int)AmcTypeEnum.OnlyService));
                    AmcRequestMasters1.ForEach(c => c.CurrencyCode = CommonAttribute.CustomeProfile?.CountryResponse?.CurrencyCode);
                    AmcRequestMasters = AmcRequestMasters1;
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        public async void PartsandService()
        {
            try
            {
                AmcRequestManagementSL managementSL = new AmcRequestManagementSL();
                List<AmcRequestMasterResponse> responseAmcRequestMasters = await managementSL.GetAmcMasterByProductCategory(SelectedddServiceCentor.Id, Convert.ToInt32(ProductModel.ProductCategoryID), (int)AmcTypeEnum.PartAndService);
                if (responseAmcRequestMasters != null)
                {
                    var AmcRequestMasters1 = new ObservableCollection<AmcRequestMasterResponse>((responseAmcRequestMasters).Where(x => x.AmcTypeId == (int)AmcTypeEnum.PartAndService));
                    AmcRequestMasters1.ForEach(c => c.CurrencyCode = CommonAttribute.CustomeProfile?.CountryResponse?.CurrencyCode);
                    AmcRequestMasters = AmcRequestMasters1;
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        //public Command OnlyServiceAMCTypeCommand
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //        {
        //            AmcRequestMasters = (ObservableCollection<AmcRequestMasterResponse>)AmcRequestMasters.Where(x => x.AmcTypeId == (int)AmcTypeEnum.OnlyService);
        //            AmcRequestMasters.ForEach(c => c.CurrencyCode = CommonAttribute.CustomeProfile?.CountryResponse?.CurrencyCode);
                   
        //        });
        //    }
        //}

        //public Command PartsAMCTypeCommand
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //        {
        //             AmcRequestMasters = (ObservableCollection<AmcRequestMasterResponse>)AmcRequestMasters.Where(x => x.AmcTypeId == (int)AmcTypeEnum.PartAndService);
        //             AmcRequestMasters.ForEach(c => c.CurrencyCode = CommonAttribute.CustomeProfile?.CountryResponse?.CurrencyCode);
        //        });
        //    }
        //}

        public Command AmcSelectedItemCommand
        {
            get
            {
                return new Command<AmcRequestMasterResponse>((item) =>
                {
                    try
                    {
                        if (item?.Rate > 0)
                        {
                            SelectedAmcRequestMaster = item;

                            SubTotalAmount = item.Rate;

                            TaxAmount = Math.Round((TaxRate / 100) * SubTotalAmount, 2);

                            TotalAmount = SubTotalAmount + TaxAmount;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    
                });
            }
        }


        public Command PromoCodeCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        PromomsgColor = Color.Red;
                        if (string.IsNullOrEmpty(PromoCode))
                        {
                            Promomsg = AppResources.lblEnterPromoCode;
                            // await ErrorDisplayAlert("Please enter promoCode.");
                            PercentDiscount = ""; PromoDiscountAmount = 0;
                            TaxAmount = Math.Round((TaxRate / 100) * SubTotalAmount, 2);
                            TotalAmount = SubTotalAmount + TaxAmount;
                            return;
                        }
                        if (TotalAmount > 0)
                        {
                            TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
                            List<PromoCode> promoCodes = await technicianManagementSL.GetPromoCodeForCustomerProductmodel(CommonAttribute.CustomeProfile.CountryId, Convert.ToInt16(ProductModel.ProductCategoryID));
                            if (promoCodes.Count > 0)
                            {
                                var checkPromoCode = promoCodes.Where(u => u.Code == PromoCode.Trim()).ToList();
                                if (checkPromoCode.Count > 0)
                                {
                                    PromomsgColor = Color.Green;
                                    promoCode = checkPromoCode[0];

                                    if (promoCode.DiscountAmount != null && promoCode.DiscountAmount != 0)
                                    {
                                        PromoDiscountAmount = Convert.ToDecimal(promoCode.DiscountAmount);
                                        TotalAmount = SubTotalAmount - Convert.ToDecimal(promoCode.DiscountAmount);
                                        PercentDiscount = "";
                                    }
                                    else if (promoCode.DiscountPercentage != null && promoCode.DiscountPercentage != 0)
                                    {
                                        decimal discount = (Convert.ToDecimal(promoCode.DiscountPercentage) / 100) * SubTotalAmount;
                                        PercentDiscount = "(" + promoCode.DiscountPercentage.ToString() + "%" + ")";
                                        TotalAmount = SubTotalAmount - discount;
                                        PromoDiscountAmount = discount;
                                    }
                                    Promomsg = AppResources.lblPromocodeapplied;
                                    TaxAmount = Math.Round((TaxRate / 100) * SubTotalAmount, 2);
                                    TotalAmount = TotalAmount + TaxAmount;
                                }
                                else
                                {
                                    Promomsg = AppResources.lblValidPromoCode;
                                    PercentDiscount = ""; PromoDiscountAmount = 0;
                                    TaxAmount = Math.Round((TaxRate / 100) * SubTotalAmount, 2);
                                    TotalAmount = SubTotalAmount + TaxAmount;
                                }
                            }
                            else
                            {
                                Promomsg = AppResources.lblValidPromoCode;
                                PercentDiscount = ""; PromoDiscountAmount = 0;
                                TaxAmount = Math.Round((TaxRate / 100) * SubTotalAmount, 2);
                                TotalAmount = SubTotalAmount + TaxAmount;
                            }
                        }
                        else
                        {
                            await ErrorDisplayAlert("No amount available to apply promo code");
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    

                });
            }
        }

        public Command AMCTermsConditionCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        IsCheckTandC = true;

                        //AmcRequestManagementSL amcRequestManagementSL = new AmcRequestManagementSL();
                        //var AMCTermsAndConditions = await amcRequestManagementSL.GetAmcTermsByServicecenter(SelectedddServiceCentor.Id);
                        //if (AMCTermsAndConditions != null)
                            await Navigation.PushModalAsync(new TermsofServicePage("https://mastcgroup.com/privacy-policy/"));
                    }
                    catch (Exception ex)
                    {

                    }                  
                   
                });
            }
        }
        public ICommand SelectedYearCommand { get; set; }
        public ICommand SelectedMonthCommand { get; set; }
        public ICommand AddNewCommand { get; set; }
        public ICommand AddPromoCodeCommand { get; set; }
        #endregion

        #region Properties
        //ProductModelWarrantyResponse

        private bool _IsCheckTandC;
        public bool IsCheckTandC
        {
            get { return _IsCheckTandC; }
            set
            {
                _IsCheckTandC = value;
                OnPropertyChanged("IsCheckTandC");
            }
        }

        private string _PercentDiscount;
        public string PercentDiscount
        {
            get { return _PercentDiscount; }
            set
            {
                _PercentDiscount = value;
                OnPropertyChanged(nameof(PercentDiscount));
            }
        }

        private decimal _SubTotalAmount;
        public decimal SubTotalAmount
        {
            get { return _SubTotalAmount; }
            set
            {
                _SubTotalAmount = value;
                OnPropertyChanged("SubTotalAmount");
            }
        }

        private decimal _TotalAmount;
        public decimal TotalAmount
        {
            get { return _TotalAmount; }
            set
            {
                _TotalAmount = value;
                OnPropertyChanged("TotalAmount");
            }
        }

        private decimal _TaxAmount;
        public decimal TaxAmount
        {
            get { return _TaxAmount; }
            set
            {
                _TaxAmount = value;
                OnPropertyChanged(nameof(TaxAmount));
            }
        }
        private decimal _PromoDiscountAmount;
        public decimal PromoDiscountAmount
        {
            get { return _PromoDiscountAmount; }
            set
            {
                _PromoDiscountAmount = value;
                OnPropertyChanged("PromoDiscountAmount");
            }
        }

        private PromoCode _promoCode;
        public PromoCode promoCode
        {
            get { return _promoCode; }
            set
            {
                _promoCode = value;
                OnPropertyChanged("promoCode");
            }
        }
        private string _Promomsg;
        public string Promomsg
        {
            get { return _Promomsg; }
            set
            {
                _Promomsg = value;
                OnPropertyChanged("Promomsg");
            }
        }

        private int _RowHeight;
        public int RowHeight
        {
            get {
                _RowHeight = 0;
                if (AmcRequestMasters != null && AmcRequestMasters.Count() > 0)
                    _RowHeight = AmcRequestMasters.Count() * 100;
                return _RowHeight;
            }
        }

        private Color _PromomsgColor;
        public Color PromomsgColor
        {
            get { return _PromomsgColor; }
            set
            {
                _PromomsgColor = value;
                OnPropertyChanged("PromomsgColor");
            }
        }

        private ObservableCollection<AmcRequestMasterResponse> _AmcRequestMasters;
        public ObservableCollection<AmcRequestMasterResponse> AmcRequestMasters
        {
            get { return _AmcRequestMasters; }
            set
            {
                _AmcRequestMasters = value;
                OnPropertyChanged(nameof(AmcRequestMasters));
                OnPropertyChanged(nameof(RowHeight));
            }
        }

        private AmcRequestMasterResponse _SelectedAmcRequestMaster;
        public AmcRequestMasterResponse SelectedAmcRequestMaster
        {
            get { return _SelectedAmcRequestMaster; }
            set
            {
                _SelectedAmcRequestMaster = value;
                OnPropertyChanged("SelectedAmcRequestMaster");
            }
        }

        private ProductModelWarrantyResponse _ProductModel;
        public ServiceCenter serviceCenter { get; set; }
        public ProductModelWarrantyResponse ProductModel
        {
            get { return _ProductModel; }
            set
            {
                _ProductModel = value;
                OnPropertyChanged("ProductModel");
            }
        }
        private List<DropDownModel> _Years;
        public List<DropDownModel> Years
        {
            get { return _Years; }
            set
            {
                _Years = value;
                OnPropertyChanged("Years");
            }
        }
        private DropDownModel _SelectedYear;
        public DropDownModel SelectedYear
        {
            get { return _SelectedYear; }
            set
            {
                _SelectedYear = value;
                OnPropertyChanged("SelectedYear");
            }
        }
        private string _PromoCode;
        public string PromoCode
        {
            get { return _PromoCode; }
            set
            {
                _PromoCode = value;
                OnPropertyChanged("PromoCode");
            }
        }
        private List<DropDownModel> _Months;
        public List<DropDownModel> Months
        {
            get { return _Months; }
            set
            {
                _Months = value;
                OnPropertyChanged("Months");
            }
        }
        private DropDownModel _SelectedMonth;
        public DropDownModel SelectedMonth
        {
            get { return _SelectedMonth; }
            set
            {
                _SelectedMonth = value;
                OnPropertyChanged("SelectedMonth");
            }
        }

        private DropDownModel _SelectedddServiceCentor;
        public DropDownModel SelectedddServiceCentor
        {
            get { return _SelectedddServiceCentor; }
            set
            {
                _SelectedddServiceCentor = value;
                OnPropertyChanged("SelectedddServiceCentor");
            }
        }
        private ObservableCollection<DropDownModel> _ddServiceCentors;
        public ObservableCollection<DropDownModel> ddServiceCentors
        {
            get { return _ddServiceCentors; }
            set
            {
                _ddServiceCentors = value;
                OnPropertyChanged("ddServiceCentors");
            }
        }

        private bool _IsOnlyService;
        public bool IsOnlyService
        {
            get { return _IsOnlyService; }
            set
            {
                _IsOnlyService = value;
                OnPropertyChanged("IsOnlyService");
            }
        }

        private bool _IsPartsandServices;
        public bool IsPartsandServices
        {
            get { return _IsPartsandServices; }
            set
            {
                _IsPartsandServices = value;
                OnPropertyChanged("IsPartsandServices");
            }
        }


        #endregion
    }
}
