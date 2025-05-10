using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.Views.Account;
using eWarranty.Views.Customer.Accesssories;
using eWarranty.Views.Customer.InquiryView;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.Accesssories
{
    public class FinalCheckoutViewModel : BaseViewModel
    {
        public int flag;
        public AddressResponse SelectedAddress { get; set; }
        public string Domestic { get; set; } = "https://mastcgroup.com/privacy-policy/";
        public string International { get; set; } = "https://mastcgroup.com/privacy-policy/";
        public string ExtendedWarranty { get; set; } = "https://mastcgroup.com/privacy-policy/";

        public FinalCheckoutViewModel(INavigation navigation, AddressResponse address) : base(navigation)
        {
            SelectedAddress = address;
            ProductHeight = 240;

            DataBinding();
            if (flag == 1)
                IsCheckTandC = true;
        }

        public FinalCheckoutViewModel(INavigation navigation) : base(navigation)
        {
            try
            {
                ProductHeight = 240;
                CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode;

                SelectedProducts = new ObservableCollection<AccessoryResponse>(CommonAttribute.SelectedAccesssories);
                foreach (var item in SelectedProducts)
                {
                    SubTotalAmount = SubTotalAmount + (item.CartCount * item.Price);
                    item.CurrencyCode = CurrencyCode;
                }
                if (SelectedProducts.Count == 1)
                    ProductHeight = 110;

                SubTotalAmount = Math.Round(SubTotalAmount, 2);
                //  SubTotalAmount=Math.Round(SelectedProducts.Sum(u => u.Price),2);
                // TotalAmount = SelectedProducts.Sum(u => u.Price);
                ShippingFee = 0;
                PromoDiscountAmount = 0;
                TaxAmount = Math.Round((TaxRate / 100) * SubTotalAmount + ShippingFee, 2);
                // decimal discount = (Convert.ToDecimal(promoCode.DiscountPercentage) / 100) * TotalAmount;
                TotalAmount = Math.Round(SubTotalAmount + ShippingFee + TaxAmount, 2);
                //CurrencyCode = "PKR "; by kumar

                if (flag == 1)
                    IsCheckTandC = true;

                if (CommonAttribute.CustomeProfile != null)
                {
                    TaxName = (CommonAttribute.CustomeProfile.CountryResponse?.CountryLevelSettingResponse?.TaxName);
                }
                else
                {
                    TaxName = "-";
                }

                CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode;
            }
            catch (Exception ex)
            {

            }
           
        }
        public void DataBinding()
        {
            try
            {
                if (!string.IsNullOrEmpty(SelectedAddress.ApartmentNumber))
                    AddressString = SelectedAddress.ApartmentNumber;
                if (!string.IsNullOrEmpty(SelectedAddress.BuildingName))
                    AddressString = AddressString + ", " + SelectedAddress.BuildingName;
                if (!string.IsNullOrEmpty(SelectedAddress.Area))
                    AddressString = AddressString + ", " + SelectedAddress.Area;
                if (!string.IsNullOrEmpty(SelectedAddress.City))
                    AddressString = AddressString + ", " + SelectedAddress.City;
                if (!string.IsNullOrEmpty(SelectedAddress.CountryName))
                    AddressString = AddressString + ", " + SelectedAddress.CountryName;

                SelectedProducts = new ObservableCollection<AccessoryResponse>(CommonAttribute.SelectedAccesssories);
                foreach (var item in SelectedProducts)
                {
                    SubTotalAmount = SubTotalAmount + (item.CartCount * item.Price);
                }
                if (SelectedProducts.Count == 1)
                    ProductHeight = 110;

                SubTotalAmount = Math.Round(SubTotalAmount, 2);
                //  SubTotalAmount=Math.Round(SelectedProducts.Sum(u => u.Price),2);
                // TotalAmount = SelectedProducts.Sum(u => u.Price);
                ShippingFee = 0;
                PromoDiscountAmount = 0;
                TaxAmount = Math.Round((TaxRate / 100) * SubTotalAmount + ShippingFee, 2);
                // decimal discount = (Convert.ToDecimal(promoCode.DiscountPercentage) / 100) * TotalAmount;
                TotalAmount = Math.Round(SubTotalAmount + ShippingFee + TaxAmount, 2);

                //CurrencyCode = "PKR "; by kumar

                CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode;
            }
            catch (Exception ex)
            {

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
                        PercentDiscount = "";
                        if (string.IsNullOrEmpty(PromoCode))
                        {
                            Promomsg = AppResources.lblEnterPromoCode;
                            PercentDiscount = "";
                            // await ErrorDisplayAlert("Please enter promoCode.");                        
                            PromoDiscountAmount = 0;

                            decimal OnlySubTotal = SubTotalAmount;
                            TaxAmount = Math.Round((TaxRate / 100) * ((OnlySubTotal)), 2);
                            TotalAmount = Math.Round(OnlySubTotal + TaxAmount + ShippingFee, 2);
                            return;
                        }

                        TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
                        List<PromoCode> promoCodes = await technicianManagementSL.GetPromoCodeForCustomerProductmodel(CommonAttribute.CustomeProfile.CountryId, 0);
                        if (promoCodes.Count > 0)
                        {
                            var checkPromoCode = promoCodes.Where(u => u.Code == PromoCode.Trim()).ToList();
                            if (checkPromoCode.Count > 0)
                            {
                                decimal OnlySubTotal = SubTotalAmount;  //TotalAmount - ShippingFee - TaxAmount;

                                PromomsgColor = Color.Green;
                                promoCode = checkPromoCode[0];
                                if (promoCode.DiscountAmount != null && promoCode.DiscountAmount != 0)
                                {
                                    PromoDiscountAmount = Convert.ToDecimal(promoCode.DiscountAmount);
                                    OnlySubTotal = OnlySubTotal - Convert.ToDecimal(promoCode.DiscountAmount);
                                    //   SelectedPromoCode = promoCode;

                                    PercentDiscount = "";
                                }
                                else if (promoCode.DiscountPercentage != null && promoCode.DiscountPercentage != 0)
                                {
                                    PercentDiscount = "(" + promoCode.DiscountPercentage.ToString() + "%" + ")";
                                    decimal discount = (Convert.ToDecimal(promoCode.DiscountPercentage) / 100) * OnlySubTotal;
                                    OnlySubTotal = OnlySubTotal - discount;
                                    PromoDiscountAmount = discount;
                                    //  SelectedPromoCode = promoCode;
                                }
                                Promomsg = AppResources.lblPromocodeapplied;

                                TaxAmount = Math.Round((TaxRate / 100) * ((OnlySubTotal)), 2);
                                TotalAmount = Math.Round(OnlySubTotal + TaxAmount + ShippingFee, 2);

                                //TaxAmount = Math.Round((TaxRate / 100) * ((SubTotalAmount + ShippingFee)- PromoDiscountAmount), 2);
                                //// decimal discount = (Convert.ToDecimal(promoCode.DiscountPercentage) / 100) * TotalAmount;
                                //TotalAmount = Math.Round(TotalAmount + TaxAmount, 2);
                                ////  PromoDiscountAmount=
                            }
                            else
                            {
                                Promomsg = AppResources.lblValidPromoCode;
                                PercentDiscount = "";
                                PromoDiscountAmount = 0;

                                decimal OnlySubTotal = SubTotalAmount;
                                TaxAmount = Math.Round((TaxRate / 100) * ((OnlySubTotal)), 2);
                                TotalAmount = Math.Round(OnlySubTotal + TaxAmount + ShippingFee, 2);
                            }
                        }
                        else
                        {
                            Promomsg = AppResources.lblValidPromoCode;
                            PercentDiscount = "";
                            PromoDiscountAmount = 0;

                            decimal OnlySubTotal = SubTotalAmount;
                            TaxAmount = Math.Round((TaxRate / 100) * ((OnlySubTotal)), 2);
                            TotalAmount = Math.Round(OnlySubTotal + TaxAmount + ShippingFee, 2);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    
                   

                });
            }
        }
        public Command SubmitItemCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        IsBusy = true;
                        if (IsCheckTandC == true)
                        {
                            AccessoryManagementSL accessoryManagement = new AccessoryManagementSL();
                            OrderRequest orderRequest = new OrderRequest();
                            orderRequest.CountryId = CommonAttribute.CustomeProfile.CountryId;
                            orderRequest.CustomerPersonId = CommonAttribute.CustomeProfile.PersonId;
                            orderRequest.DeliveryAddressId = SelectedAddress.AddressId;
                            orderRequest.PromoCodeId = promoCode?.PromoCodeId;
                            orderRequest.PaymentModeId = Convert.ToInt32(PaymentModeEnum.CashPayment);
                            orderRequest.OrderDetails = new List<OrderDetailRequest>();

                            foreach (var item in SelectedProducts)
                            {
                                OrderDetailRequest orderDetail = new OrderDetailRequest();
                                orderDetail.AccessoryMasterId = item.AccessoryMasterId;
                                orderDetail.Quantity = item.CartCount;
                                orderRequest.ServiceCenterID = item.ServiceCenterId;
                                orderRequest.OrderDetails.Add(orderDetail);
                            }
                            var receiveContext = await accessoryManagement.PostOrder(orderRequest);
                            if (receiveContext?.Status == Convert.ToInt16(APIResponseEnum.Success))
                            {
                                IsBusy = false;
                                CommonAttribute.SelectedAccesssories = null;
                                await Navigation.PushAsync(new FeedBackSuccessPage("accesssories"));
                            }
                            else if (receiveContext != null)
                            {
                                IsBusy = false;

                                await Application.Current.MainPage.DisplayAlert("", receiveContext.ErrorMessage, "Cancel");
                            }
                            else
                            {
                                await ErrorDisplayAlert(AppResources.servererror);
                                IsBusy = false;
                            }
                        }
                        else
                        {
                            await ErrorDisplayAlert(AppResources.lblSelectTandC);
                            IsBusy = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                    
                });
            }
        }
        public Command TermsConditionCommand
        {
            get
            {
                return new Command(async () =>
                {
                    flag = 1;
                    IsCheckTandC = true;
                    await Navigation.PushModalAsync(new TermsofServicePage("https://mastcgroup.com/privacy-policy/"));                   
                    
                });
            }
        }
        public Command ShowTaxesCommand
        {
            get
            {
                return new Command(async () =>
                {
                    //await DisplayAlert(AppResources.lblTax, AppResources.lblRate + ":" + TaxRate.ToString());
                    await PopupNavigation.Instance.PushAsync(new TaxDetailsPopupView(TaxAmount));
                });
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

        private double _ProductHeight;
        public double ProductHeight
        {
            get { return _ProductHeight; }
            set
            {
                _ProductHeight = value;
                OnPropertyChanged("ProductHeight");
            }
        }


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
        private decimal _ShippingFee;
        public decimal ShippingFee
        {
            get { return _ShippingFee; }
            set
            {
                _ShippingFee = value;
                OnPropertyChanged("ShippingFee");
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
        private string _AddressString;
        public string AddressString
        {
            get { return _AddressString; }
            set
            {
                _AddressString = value;
                OnPropertyChanged("AddressString");
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
        //taxAmount
        private decimal _TaxAmount;
        public decimal TaxAmount
        {
            get { return _TaxAmount; }
            set
            {
                _TaxAmount = value;
                OnPropertyChanged("TaxAmount");
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
        private ObservableCollection<AccessoryResponse> _SelectedProducts;
        public ObservableCollection<AccessoryResponse> SelectedProducts
        {
            get { return _SelectedProducts; }
            set
            {
                _SelectedProducts = value;
                OnPropertyChanged(nameof(SelectedProducts));
                OnPropertyChanged(nameof(SelectedProductsLength));
            }
        }

        private int _SelectedProductsLength;
        public int SelectedProductsLength
        {
            get
            {
                _SelectedProductsLength = SelectedProducts.Count * 120;
                return _SelectedProductsLength;
            }
        }
    }
}
