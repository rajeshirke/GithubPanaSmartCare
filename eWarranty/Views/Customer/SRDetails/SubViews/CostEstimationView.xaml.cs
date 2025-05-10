using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Resx;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.SRDetails.SubViews
{
    public partial class CostEstimationView : ContentView
    {
        public List<ServiceChargeMasterResponse> costEstimations { get; set; }
        public List<ServiceCostEstimationOtherChargeResponse> ServiceRequestCharges { get; set; } 
        public List<ServiceCostEstimationPartChargeResponse> EstimationPartCharges { get; set; }

        private string _Currency;
        public string Currency
        {
            get { return _Currency; }
            set
            {
                _Currency = value;
                OnPropertyChanged(nameof(Currency));
            }
        }


        public CostEstimationView()
        {
            InitializeComponent();
            
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {                   
                    Currency = CommonAttribute.CustomeProfile?.CountryResponse?.CurrencyCode;
                    await BindingData();

                    var ServiceCostEstimation = CommonAttribute.EditServiceRequest?.ServiceCostEstimations?.OrderByDescending(d => d.ServiceCostEstimationId).FirstOrDefault();

                    if ((CommonAttribute.EditServiceRequest?.StatusId == (int)ServiceRequestStatusEnum.EstimationConfirmed) || (CommonAttribute.EditServiceRequest?.StatusId == (int)ServiceRequestStatusEnum.JobClosed))
                    {

                        if (ServiceCostEstimation != null)
                        {
                            grCostEstimation.IsVisible = true;
                            grNoCostEstimation.IsVisible = false;
                        }
                        else
                        {
                            grCostEstimation.IsVisible = false;
                            grNoCostEstimation.IsVisible = true;

                        }

                    }
                    else
                    {

                        grCostEstimation.IsVisible = false;
                        grNoCostEstimation.IsVisible = true;
                        //return;
                    }

                    if (ServiceCostEstimation != null)
                    {
                        //EstimationPartCharges = ServiceCostEstimation.ServiceCostEstimationPartCharges?.ToList();
                        ////List<ServiceChargeMasterResponse> ServiceRequestCharges = CommonAttribute.EditServiceRequest?.ServiceChargeMasterResponse.ToList();
                        ////if (costEstimations != null && costEstimations.Count > 0)
                        ////{
                        ////    ServiceRequestCharges = costEstimations;//CommonAttribute.EditServiceRequest?.ServiceChargeMasterResponse.ToList();
                        ////    ServiceRequestCharges.ForEach(x => x.CurrencyName = CommonAttribute.CustomeProfile.CountryResponse.CurrencyCode);                       
                        ////}

                        //EstimationPartCharges.ForEach(x => x.CurrencyName = CommonAttribute.CustomeProfile.CountryResponse.CurrencyCode);

                        cvSRCharges.ItemsSource = ServiceRequestCharges;
                        cvSRPartCharges.ItemsSource = EstimationPartCharges;
                        if (ServiceRequestCharges?.Count > 0)
                            cvSRCharges.HeightRequest = (ServiceRequestCharges.Count * 40) + 50;
                        else
                            cvSRCharges.HeightRequest = 0;

                        if (EstimationPartCharges?.Count > 0)
                            cvSRPartCharges.HeightRequest = (EstimationPartCharges.Count * 40) + 70;
                        else
                            cvSRPartCharges.HeightRequest = 0;

                        if (ServiceCostEstimation.EstimationCreationDate.Date != null)
                        {
                            lblEstimationCreationDate.Text = " " + ServiceCostEstimation.EstimationCreationDate.Date.ToString("MMM dd, yyyy");
                        }
                        else
                        {
                            lblEstimationCreationDate.Text = "-";
                        }
                        if (ServiceCostEstimation.EstimationApprovalDate != null)
                        {
                            lblEstimationApprovalDate.Text = " " + Convert.ToDateTime(ServiceCostEstimation.EstimationApprovalDate).Date.ToString("MMM dd, yyyy");
                        }
                        else
                        {
                            lblEstimationApprovalDate.Text = "-";
                        }
                        if (Convert.ToBoolean(ServiceCostEstimation.IsApprovedByCustomer))
                        {
                            lblApprovalStatus.Text = " " + AppResources.lblApproved;
                        }
                        else
                        {
                            lblApprovalStatus.Text = " " + AppResources.lblPending;
                        }
                    }
                    else
                    {
                        cvSRCharges.HeightRequest = 0;
                        cvSRPartCharges.HeightRequest = 0;
                        ApprovalStatus = " " + AppResources.lblPending;
                    }
                }
                catch (Exception ex)
                {

                }
                
            });
            
            BindingContext = this;
        }

        public async Task BindingData()
        {
            try
            {
                ServiceRequestSL serviceRequestSL = new ServiceRequestSL();

                //costEstimations = await technicianManagementSL.GetServiceChargeMasterForCostEstimationCustomer
                //  ((int)CommonAttribute.EditServiceRequest?.TypeId, (int)(CommonAttribute.CustomeProfile?.CountryId),
                //   (int)CommonAttribute.EditServiceRequest?.ServiceCenterId,
                //   (int)Convert.ToInt32(CommonAttribute.EditServiceRequest?.ProductModel.ProductCategoryId),
                //   (int)CommonAttribute.EditServiceRequest?.ServiceRequestId);
                if (CommonAttribute.EditServiceRequest != null)
                {
                    ServiceCostEstimationCustomerResponse serviceCostEstimationCustomerResponse =
                                    await serviceRequestSL.GetServiceRequestCostEstimationForCustomer((long)CommonAttribute.EditServiceRequest?.ServiceRequestId);
                    if (serviceCostEstimationCustomerResponse != null)
                    {
                        EstimationPartCharges = serviceCostEstimationCustomerResponse.ServiceCostEstimationPartCharges.ToList();
                        ServiceRequestCharges = serviceCostEstimationCustomerResponse.ServiceCostEstimationOtherCharges.ToList();


                        //txtDiscountAmt.Text = string.Format("{0:F2}", (decimal)serviceCostEstimationCustomerResponse.DiscountByAmount); //(serviceCostEstimationCustomerResponse.DiscountByAmount).ToString("F2");
                        if (serviceCostEstimationCustomerResponse.DiscountByPercentage != null)
                        {
                            txtOtherDiscountPercent.Text = "(" + serviceCostEstimationCustomerResponse.DiscountByPercentage + "%" + ")";
                            txtDiscountAmt.Text = string.Format("{0:F2}", (decimal)serviceCostEstimationCustomerResponse.DiscountAmount);
                        }
                        else
                        {
                            txtOtherDiscountPercent.Text = "";
                            txtDiscountAmt.Text = string.Format("{0:F2}", (decimal)serviceCostEstimationCustomerResponse.DiscountAmount);
                        }
                        lblTaxPercent.Text = "(" + serviceCostEstimationCustomerResponse?.TaxPercentage + "%" + ")";
                        txtTaxValue.Text = string.Format("{0:F2}", (decimal)serviceCostEstimationCustomerResponse?.TaxAmount);
                        txtTotalAmount.Text = string.Format("{0:F2}", (decimal)(serviceCostEstimationCustomerResponse.TotalAmount));

                        if (serviceCostEstimationCustomerResponse.PromoCodeResponse != null)
                        {
                            if (serviceCostEstimationCustomerResponse.PromoCodeResponse?.Code != null)
                            {
                                txtPromocode.Text = serviceCostEstimationCustomerResponse.PromoCodeResponse?.Code;
                            }
                            else
                            {
                                txtPromocode.Text = "-";
                            }

                            if (serviceCostEstimationCustomerResponse.PromoCodeResponse?.PromoCodeAmountCalculated != null)
                            {
                                txtPromocodeDiscount.Text = string.Format("{0:F2}", (decimal)(serviceCostEstimationCustomerResponse.PromoCodeResponse.PromoCodeAmountCalculated));
                            }
                            else
                            {
                                txtPromocodeDiscount.Text = "0.0";
                            }
                            if (serviceCostEstimationCustomerResponse.PromoCodeResponse?.DiscountPercentage != null)
                            {
                                txtDiscountPercentage.Text = "(" + serviceCostEstimationCustomerResponse.PromoCodeResponse?.DiscountPercentage.ToString() + "%" + ")";
                            }
                            else
                            {
                                txtDiscountPercentage.Text = "";
                            }

                        }
                        else
                        {
                            txtPromocode.Text = " -";
                            txtPromocodeDiscount.Text = "0.0";
                            txtDiscountPercentage.Text = "";
                        }

                        EstimationPartCharges.ForEach(x => x.CurrencyName = CommonAttribute.CustomeProfile.CountryResponse.CurrencyCode);
                        ServiceRequestCharges.ForEach(x => x.CurrencyName = CommonAttribute.CustomeProfile.CountryResponse.CurrencyCode);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public string EstimationCreationDate { get; set; }

        public string EstimationApprovalDate { get; set; }

        public string ApprovalStatus { get; set; }

    }
}
