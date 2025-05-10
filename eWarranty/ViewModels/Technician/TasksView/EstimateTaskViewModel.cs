using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Resx;
using eWarranty.Views.Technician;
using eWarranty.Views.Technician.SparePartsViews;
using eWarranty.Views.Technician.TaskViews;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Technician.SparePartsView
{
    public class EstimateTaskViewModel:BaseViewModel
    {
        public EstimateTaskViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;

            Device.BeginInvokeOnMainThread(async () =>
            {
                await BindingData();
                IsBusy = false;
            });
            CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode;
        }
        public async Task BindingData()
        {
            try
            {
                btnVisible = true;
                if (SpareParts == null)
                    SpareParts = new ObservableCollection<PartStockMaster>();
                serviceRequest = CommonAttribute.TechEditServiceRequest;

                var JobStatus = serviceRequest.ServiceRequestStatusName.ToLower().ToString();
                if (JobStatus == "estimation confirmed")
                {
                    BtnEstimation = "Re-Estimate";
                }
                else
                {
                    BtnEstimation = "Estimate";
                }

                TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();

                List<ServiceChargeMaster> costEstimations = await technicianManagementSL.GetServiceChargeMasterForCostEstimation(CommonAttribute.TechEditServiceRequest.TypeId, CommonAttribute.CustomeProfile.CountryId, CommonAttribute.TechEditServiceRequest.ServiceCenterId, Convert.ToInt32(CommonAttribute.TechEditServiceRequest.ProductModel.ProductCategoryId), serviceRequest.ServiceRequestId);
                PartCastEstimation = 0;
                ExistingServiceCostEstimation = new ObservableCollection<ServiceCostEstimationResponse>(serviceRequest.ServiceCostEstimations);
                //if (ExistingServiceCostEstimation.Count == 0) //kumar
                if (costEstimations != null && costEstimations.Count > 0)
                {
                    //BtnEstimation = "Regenerate";

                    //========SERVICE REQUEST COST ESTIMATION CHARGES

                    //  ServiceCostEstimations Count = 3
                    //  serviceRequest.ServiceCostEstimations
                    //  CommonAttribute.SelectedServiceRequest.ServiceLocationTypeId
                    //  CommonAttribute.SelectedServiceRequest.TypeId

                    IsJobCloseVisible = true; //if estimation is done
                    int scId = Convert.ToInt16(ChargeTypeEnum.ServiceCharge);
                    var Scitem = costEstimations.Where(u => u.ChargeTypeId == scId).FirstOrDefault();
                    // Scitem.Country?.Currency?.Code;
                    SCCastEstimation = new ServiceChargeMasterResponse();
                    if (Scitem != null)
                    {
                        SCCastEstimation.ChargeTypeId = (int)Scitem?.ChargeTypeId;
                        SCCastEstimation.ServiceChargeMasterId = (int)Scitem?.ServiceChargeMasterId;
                        SCCastEstimation.ChargeTypeName = Scitem.ChargeType?.Name;
                        SCCastEstimation.Rate = (decimal)Scitem?.Rate;
                        SCCast = Math.Round(Scitem.Rate, 2);
                    }


                    int icId = Convert.ToInt16(ChargeTypeEnum.InspectionCharge);
                    var ICCastEstItem = costEstimations.Where(u => u.ChargeTypeId == icId).FirstOrDefault();
                    ICCastEstimation = new ServiceChargeMasterResponse();
                    if (ICCastEstItem != null)
                    {
                        ICCastEstimation.ChargeTypeId = (int)ICCastEstItem?.ChargeTypeId;
                        ICCastEstimation.ServiceChargeMasterId = (int)ICCastEstItem?.ServiceChargeMasterId;
                        ICCastEstimation.ChargeTypeName = ICCastEstItem?.ChargeType?.Name;
                        ICCastEstimation.Rate = (decimal)ICCastEstItem?.Rate;
                        ICCast = Math.Round((decimal)ICCastEstItem?.Rate, 2);
                    }


                    int tpcId = Convert.ToInt16(ChargeTypeEnum.TransportationCharge);
                    var TPCCastEstItem = costEstimations?.Where(u => u.ChargeTypeId == tpcId).FirstOrDefault();
                    if (TPCCastEstItem != null)
                    {
                        TPCCastEstimation = new ServiceChargeMasterResponse();
                        TPCCastEstimation.ChargeTypeId = (int)TPCCastEstItem?.ChargeTypeId;
                        TPCCastEstimation.ChargeTypeName = TPCCastEstItem?.ChargeType?.Name;
                        TPCCastEstimation.ServiceChargeMasterId = (int)TPCCastEstItem?.ServiceChargeMasterId;
                        TPCCastEstimation.Rate = (decimal)TPCCastEstItem?.Rate;
                        TPCCast = Math.Round((decimal)TPCCastEstItem?.Rate, 2);
                    }


                    if (SCCastEstimation != null)
                        TotalAmount = Math.Round((decimal)SCCastEstimation?.Rate, 2);
                    if (ICCastEstimation != null)
                        TotalAmount = TotalAmount + Math.Round((decimal)ICCastEstimation?.Rate, 2);
                    if (TPCCastEstimation != null)
                        TotalAmount = TotalAmount + Math.Round((decimal)TPCCastEstimation?.Rate, 2);
                    // serviceRequest.ServiceRequestNumber


                    //prajakta
                    if (ExistingServiceCostEstimation != null && ExistingServiceCostEstimation.Count > 0)
                    {
                        var ServiceRequestPartCharges = ExistingServiceCostEstimation.OrderByDescending(x => x.ServiceCostEstimationId)
                          .FirstOrDefault();

                        //if (ServiceRequestPartCharges != null)
                        //{
                        //    var ExistingParts = ServiceRequestPartCharges.ServiceCostEstimationPartCharges.ToList();

                        //    if (SpareParts == null)
                        //        SpareParts = new ObservableCollection<PartStockMaster>();
                        //    foreach (var item in ExistingParts)
                        //    {
                        //        PartCastEstimation = PartCastEstimation + item.Cost;
                        //        PartStockMaster partStock = new PartStockMaster();
                        //        partStock.Cost =Math.Round( item.Cost,2);
                        //        partStock.PartNumber = item.PartNumber;
                        //        partStock.Quantity = item.Quantity;
                        //        partStock.TotalAmount = item.Quantity * Math.Round(item.Cost, 2);
                        //        SpareParts.Add(partStock);
                        //    }
                        //    PartCastEstimation = Math.Round(PartCastEstimation, 2);
                        //    TotalAmount = TotalAmount + PartCastEstimation;
                        //    TotalAmount = Math.Round(TotalAmount, 2);
                        //}


                    }


                }
                else
                {
                    //BtnEstimation = "Generate";
                    if (ExistingServiceCostEstimation != null && ExistingServiceCostEstimation.Count > 0)
                    {
                        //========SERVICE REQUEST MASTER CHARGES
                        //btnVisible = false;
                        IsJobCloseVisible = false; //if estimation is not done
                        var ServiceRequestCharges = ExistingServiceCostEstimation[0]?.ServiceRequestCharges?.ToList();
                        int scId = Convert.ToInt16(ChargeTypeEnum.ServiceCharge);
                        var scIdItem = ServiceRequestCharges.Where(u => u.ServiceChargeMaster?.ChargeTypeId == scId).FirstOrDefault();
                        if (scIdItem != null)
                        {
                            SCCastEstimation = scIdItem?.ServiceChargeMaster;
                            SCCast = Math.Round((decimal)SCCastEstimation?.Rate, 2);
                        }

                        int icId = Convert.ToInt16(ChargeTypeEnum.InspectionCharge);
                        var icIdItem = ServiceRequestCharges.Where(u => u.ServiceChargeMaster?.ChargeTypeId == icId).FirstOrDefault();
                        if (icIdItem != null)
                        {
                            ICCastEstimation = icIdItem?.ServiceChargeMaster;
                            ICCast = Math.Round((decimal)ICCastEstimation?.Rate, 2);
                        }

                        int tpcId = Convert.ToInt16(ChargeTypeEnum.TransportationCharge);
                        var tpcIdItem = ServiceRequestCharges.Where(u => u.ServiceChargeMaster?.ChargeTypeId == tpcId).FirstOrDefault();
                        if (tpcIdItem != null)
                        {
                            TPCCastEstimation = tpcIdItem?.ServiceChargeMaster;
                            TPCCast = Math.Round((decimal)TPCCastEstimation?.Rate, 2);
                        }


                        if (SCCastEstimation != null)
                            TotalAmount = (decimal)SCCastEstimation?.Rate;
                        if (ICCastEstimation != null)
                            TotalAmount = TotalAmount + (decimal)ICCastEstimation?.Rate;
                        if (TPCCastEstimation != null)
                            TotalAmount = TotalAmount + (decimal)TPCCastEstimation?.Rate;

                        TotalAmount = Math.Round(TotalAmount, 2);

                        //var ServiceRequestPartCharges = ExistingServiceCostEstimation[0]?.ServiceCostEstimationPartCharges?.ToList();
                        //if (SpareParts == null)
                        //    SpareParts = new ObservableCollection<PartStockMaster>();
                        //if(ServiceRequestPartCharges!=null && ServiceRequestPartCharges.Count>0)
                        //{
                        //    foreach (var item in ServiceRequestPartCharges)
                        //    {
                        //        PartCastEstimation = PartCastEstimation + item.Cost;
                        //        PartStockMaster partStock = new PartStockMaster();
                        //        partStock.Cost = Math.Round(item.Cost, 2);
                        //        partStock.PartNumber = item.PartNumber;
                        //        partStock.Quantity = item.Quantity;
                        //        partStock.TotalAmount = item.Quantity * Math.Round(item.Cost, 2);
                        //        SpareParts.Add(partStock);
                        //    }

                        //}
                        //PartCastEstimation = Math.Round(PartCastEstimation, 2);
                        //TotalAmount = TotalAmount + PartCastEstimation;
                        //TotalAmount = Math.Round(TotalAmount, 2);
                    }

                    else
                    {
                        IsJobCloseVisible = false;
                        int scId = Convert.ToInt16(ChargeTypeEnum.ServiceCharge);

                        SCCast = 0;
                        ICCast = 0;
                        TPCCast = 0;

                        if (SCCastEstimation != null)
                            TotalAmount = (decimal)SCCastEstimation?.Rate;
                        if (ICCastEstimation != null)
                            TotalAmount = TotalAmount + (decimal)ICCastEstimation?.Rate;
                        if (TPCCastEstimation != null)
                            TotalAmount = TotalAmount + (decimal)TPCCastEstimation?.Rate;

                        TotalAmount = Math.Round(TotalAmount, 2);
                        if (SpareParts == null)
                            SpareParts = new ObservableCollection<PartStockMaster>();

                        PartCastEstimation = Math.Round(PartCastEstimation, 2);
                        TotalAmount = TotalAmount + PartCastEstimation;
                        TotalAmount = Math.Round(TotalAmount, 2);
                    }

                }

                ServiceRequestSL serviceRequestSL = new ServiceRequestSL();
                ServiceCostEstimationCustomerResponse serviceCostEstimationCustomerResponse =
                   await serviceRequestSL.GetServiceRequestCostEstimationForCustomer((long)serviceRequest?.ServiceRequestId);

                SelectedPromoCode = new PromoCode();
                if (serviceCostEstimationCustomerResponse != null)
                {
                    if (serviceCostEstimationCustomerResponse.ServiceCostEstimationPartCharges != null && serviceCostEstimationCustomerResponse.ServiceCostEstimationPartCharges.Count != 0)
                    {
                        var ExistingParts = serviceCostEstimationCustomerResponse.ServiceCostEstimationPartCharges.ToList();

                        if (SpareParts == null)
                            SpareParts = new ObservableCollection<PartStockMaster>();
                        foreach (var item in ExistingParts)
                        {
                            PartCastEstimation = PartCastEstimation + item.Cost;
                            PartStockMaster partStock = new PartStockMaster();
                            partStock.Cost = Math.Round(item.Cost, 2);
                            partStock.PartNumber = item.PartNumber;
                            partStock.Quantity = item.Quantity;
                            partStock.TotalAmount = item.Quantity * Math.Round(item.Cost, 2);
                            SpareParts.Add(partStock);
                        }
                        PartCastEstimation = Math.Round(PartCastEstimation, 2);
                        TotalAmount = TotalAmount + PartCastEstimation;
                        TotalAmount = Math.Round(TotalAmount, 2);
                    }

                    if (serviceCostEstimationCustomerResponse.PromoCodeResponse != null && serviceCostEstimationCustomerResponse.PromoCodeResponse.PromoCodeId != 0)
                    {
                        PromoCode = serviceCostEstimationCustomerResponse.PromoCodeResponse?.Code;
                        SelectedPromoCode.Code = serviceCostEstimationCustomerResponse.PromoCodeResponse?.Code;
                        SelectedPromoCode.PromoCodeId = (int)serviceCostEstimationCustomerResponse.PromoCodeResponse?.PromoCodeId;

                        if (serviceCostEstimationCustomerResponse.PromoCodeResponse?.DiscountPercentage != null && serviceCostEstimationCustomerResponse.PromoCodeResponse?.DiscountPercentage != 0)
                            PercentDiscount = "(" + serviceCostEstimationCustomerResponse.PromoCodeResponse?.DiscountPercentage.ToString() + "%" + ")";
                        else
                            PercentDiscount = "";

                        PromoDiscountAmount = (decimal)(serviceCostEstimationCustomerResponse.PromoCodeResponse?.PromoCodeAmountCalculated);
                    }

                    if (serviceCostEstimationCustomerResponse.DiscountByPercentage != null && serviceCostEstimationCustomerResponse.DiscountByPercentage != 0)
                    {
                        DiscountType = true;
                        DiscountAmount = (decimal)serviceCostEstimationCustomerResponse.DiscountByPercentage;
                        OtherDiscountAmount = Math.Round((decimal)serviceCostEstimationCustomerResponse.DiscountAmount, 2);
                    }
                    else
                    {
                        DiscountAmount = Math.Round((decimal)serviceCostEstimationCustomerResponse.DiscountAmount, 2);
                    }

                }

                calculateTotalAmount();
                CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            finally
            {
                IsBusy = false;
            }


        }
        public Command TabSelectedCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (!partTab)
                    {
                        partTab = true;
                    }
                    else
                    {
                        partTab = false;
                    }
                });
            }
        }
        public Command JobCloseCommand
        {
            get
            {
                return new Command(async () =>
                {
                    //await SaveEstimateTaskForJobClose();
                    await Navigation.PushAsync(new TaskPaymentPage(TotalAmount));
                });
            }
        }
        public void calculateTotalAmount()
        {
            try
            {
                TotalAmount = 0;
                if (SCCast > 0)
                    TotalAmount = TotalAmount + SCCast;
                if (ICCast > 0)
                    TotalAmount = TotalAmount + ICCast;
                if (TPCCast > 0)
                    TotalAmount = TotalAmount + TPCCast;

                if (SpareParts?.Count > 0)
                    //TotalAmount = TotalAmount+ SpareParts.Sum(u => u.Cost); kumar 
                    TotalAmount = TotalAmount + SpareParts.Sum(u => u.TotalAmount);

                var subtotal = TotalAmount;

                if (DiscountType)
                {
                    decimal discount = (DiscountAmount / 100) * subtotal;
                    OtherDiscountAmount = discount;
                    subtotal = subtotal - OtherDiscountAmount;// discount percentage amt
                }
                else
                {
                    subtotal = subtotal - DiscountAmount;
                }

                var TotalAmountAfterDiscount = subtotal - PromoDiscountAmount;

                TaxAmount = ((TaxRate / 100) * TotalAmountAfterDiscount);

                var TotalAmountAfterTax = TotalAmountAfterDiscount + TaxAmount;
                TotalAmount = TotalAmountAfterTax;//TotalAmount + TaxAmount;
                TotalAmount = Math.Round(TotalAmount, 2);
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
                        IsBusy = true;

                        PromomsgColor = Color.Red;
                        if (string.IsNullOrEmpty(PromoCode))
                        {
                            Promomsg = "Please enter promoCode.";
                            // await ErrorDisplayAlert("Please enter promoCode.");
                            PercentDiscount = ""; PromoDiscountAmount = 0;
                            calculateTotalAmount();
                            return;
                        }
                        TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
                        List<PromoCode> promoCodes = await technicianManagementSL.GetPromoCodeForCustomerProductmodel(CommonAttribute.CustomeProfile.CountryId, Convert.ToInt16(serviceRequest.ProductModel.ProductCategoryId));
                        if (promoCodes != null && promoCodes.Count > 0)
                        {
                            var checkPromoCode = promoCodes.Where(u => u.Code == PromoCode.Trim()).ToList();
                            if (checkPromoCode.Count > 0)
                            {
                                PromomsgColor = Color.Green;
                                promoCode = checkPromoCode[0];


                                SubTotalAmount = 0;
                                if (SCCast > 0)
                                    SubTotalAmount = SubTotalAmount + SCCast;
                                if (ICCast > 0)
                                    SubTotalAmount = SubTotalAmount + ICCast;
                                if (TPCCast > 0)
                                    SubTotalAmount = SubTotalAmount + TPCCast;

                                if (SpareParts?.Count > 0)
                                    SubTotalAmount = SubTotalAmount + SpareParts.Sum(u => u.TotalAmount);


                                //decimal OnlySubTotal = TotalAmount - TaxAmount;

                                if (promoCode.DiscountAmount != null && promoCode.DiscountAmount != 0)
                                {
                                    PromoDiscountAmount = Convert.ToDecimal(promoCode.DiscountAmount);
                                    // TotalAmount = TotalAmount - Convert.ToDecimal(promoCode.DiscountAmount);
                                    SelectedPromoCode = promoCode;
                                    PercentDiscount = "";
                                }
                                else if (promoCode.DiscountPercentage != null && promoCode.DiscountPercentage != 0)
                                {
                                    decimal discount = (Convert.ToDecimal(promoCode.DiscountPercentage) / 100) * SubTotalAmount;
                                    PercentDiscount = "(" + promoCode.DiscountPercentage.ToString() + "%" + ")";
                                    //TotalAmount = TotalAmount - discount;
                                    PromoDiscountAmount = discount;
                                    SelectedPromoCode = promoCode;

                                }
                                Promomsg = AppResources.lblPromocodeapplied;
                                //  PromoDiscountAmount=
                            }
                            else
                            {
                                Promomsg = AppResources.lblValidPromoCode;
                                PercentDiscount = ""; PromoDiscountAmount = 0;
                            }
                        }
                        else
                        {
                            Promomsg = AppResources.lblValidPromoCode;
                            PercentDiscount = ""; PromoDiscountAmount = 0;
                        }
                        calculateTotalAmount();
                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                    finally
                    {
                        IsBusy = false;
                    }
                });
            }
        }
        //Promomsg
        public Command SavedCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await SaveEstimateTask();
                 //   CreateCostEstimationPartCharges createCostEstimation = new CreateCostEstimationPartCharges();
                 //   createCostEstimation.ServiceRequestId = serviceRequest.ServiceRequestId;
                 //   createCostEstimation.EstimationCreationDate = DateTime.Now;
                 //   createCostEstimation.EstimationApprovalDate = DateTime.Now;

                    //   createCostEstimation.IsApprovedByCustomer = true;
                    //   createCostEstimation.Status = true;
                    //   createCostEstimation.ServiceRequestCharges = new List<ServiceRequestCharges>();

                    //   ServiceRequestCharges InputserviceRequest = new ServiceRequestCharges();
                    //   //  InputserviceRequest.ServiceRequestChargeId = SCCastEstimation.chargeTypeId; ?
                    //   //   InputserviceRequest.ServiceChargeMasterId = SCCastEstimation.serviceRequestTypeId;?

                    //   createCostEstimation.ServiceRequestCharges.Add(new ServiceRequestCharges() { ServiceChargeMasterId = SCCastEstimation.ServiceChargeMasterId });
                    //   createCostEstimation.ServiceRequestCharges.Add(new ServiceRequestCharges() { ServiceChargeMasterId = ICCastEstimation.ServiceChargeMasterId });
                    //   createCostEstimation.ServiceRequestCharges.Add(new ServiceRequestCharges() { ServiceChargeMasterId = TPCCastEstimation.ServiceChargeMasterId });


                    //   createCostEstimation.ServiceCostEstimationPartCharges = new List<ServiceCostEstimationPartCharges>();
                    //   foreach (var item in SpareParts)
                    //   {
                    //       int qty = SpareParts.Where(u => u.PartStockBucketId == item.PartStockBucketId).Count();
                    //       ServiceCostEstimationPartCharges serviceCostEstimationPart = new ServiceCostEstimationPartCharges();
                    //       serviceCostEstimationPart.Cost = item.Cost;
                    //       serviceCostEstimationPart.PartNumber = item.PartNumber;
                    //       serviceCostEstimationPart.PartTotalCost = item.Cost* qty;
                    //       serviceCostEstimationPart.Quantity = qty;
                    //       // serviceCostEstimationPart.ServiceCostEstimationId = ?
                    //       //  serviceCostEstimationPart.ServiceCostEstimationId = ?
                    //       createCostEstimation.ServiceCostEstimationPartCharges.Add(serviceCostEstimationPart);
                    //   }

                    //   TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
                    //ReceiveContext<ResponseWithID> receiveContext=  await technicianManagementSL.CreateServiceCostEstimations(createCostEstimation);
                    //   if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
                    //   {
                    //       await  DisplayAlert("Success", receiveContext.message);
                    //   }
                    //   else if(receiveContext != null)
                    //   {
                    //      await ErrorDisplayAlert(receiveContext.errorMessage);
                    //   }
                    //   else
                    //   {
                    //       await ErrorDisplayAlert("Please contact admin.");
                    //   }

                });
            }
        }

        public async Task SaveEstimateTask()
        {
            try
            {
                IsBusy = true;

                if (SCCast == 0)
                {
                    await DisplayAlert("Alert", "Kindly enter service charge to proceed.");
                    return;
                }

                if (ICCast == 0)
                {
                    await DisplayAlert("Alert", "Kindly enter inspection charge to proceed.");
                    return;
                }

                if (TPCCast == 0)
                {
                    await DisplayAlert("Alert", "Kindly enter transportation charge to proceed.");
                    return;
                }

                ServiceCostEstimationRequest serviceCostEstimation = new ServiceCostEstimationRequest();
                if (DiscountType == true)
                {
                    serviceCostEstimation.DiscountByPercentage = Convert.ToInt16(DiscountAmount);//percentage
                    serviceCostEstimation.DiscountAmount = OtherDiscountAmount;
                }
                else
                {
                    serviceCostEstimation.DiscountByAmount = DiscountAmount;
                    serviceCostEstimation.DiscountAmount = DiscountAmount;
                }

                serviceCostEstimation.estimationCreationDate = DateTime.Now;
                serviceCostEstimation.estimationApprovalDate = DateTime.Now;
                if (SelectedPromoCode != null && PromoCode != string.Empty)
                {
                    serviceCostEstimation.PromoCode = PromoCode;
                    //serviceCostEstimation.PromoCodeId = SelectedPromoCode.PromoCodeId == 0 ? null : SelectedPromoCode.PromoCodeId;

                    if (SelectedPromoCode.PromoCodeId == 0)
                    {
                        serviceCostEstimation.PromoCodeId = null;
                    }
                    else
                    {
                        serviceCostEstimation.PromoCodeId = SelectedPromoCode.PromoCodeId;
                    }
                }
                serviceCostEstimation.isApprovedByCustomer = true;
                serviceCostEstimation.status = true;
                serviceCostEstimation.serviceRequestId = CommonAttribute.TechEditServiceRequest.ServiceRequestId;
                serviceCostEstimation.serviceRequestCharges = new List<ServiceRequestChargeRequest>();

                if (SCCastEstimation != null)
                    serviceCostEstimation.serviceRequestCharges.Add(new ServiceRequestChargeRequest() { ServiceChargeMasterId = (int)(SCCastEstimation?.ServiceChargeMasterId) });

                if (ICCastEstimation != null)
                    serviceCostEstimation.serviceRequestCharges.Add(new ServiceRequestChargeRequest() { ServiceChargeMasterId = (int)(ICCastEstimation?.ServiceChargeMasterId) });

                if (TPCCastEstimation != null)
                    serviceCostEstimation.serviceRequestCharges.Add(new ServiceRequestChargeRequest() { ServiceChargeMasterId = (int)(TPCCastEstimation?.ServiceChargeMasterId) });

                serviceCostEstimation.ServiceCostEstimationOtherCharges = new List<ServiceCostEstimationOtherChargeRequest>();

                serviceCostEstimation.ServiceCostEstimationOtherCharges.Add(new ServiceCostEstimationOtherChargeRequest() { ChargeTypeId = Convert.ToInt16(ChargeTypeEnum.ServiceCharge), OtherRate = SCCast, ServiceRequestId = CommonAttribute.TechEditServiceRequest.ServiceRequestId });
                serviceCostEstimation.ServiceCostEstimationOtherCharges.Add(new ServiceCostEstimationOtherChargeRequest() { ChargeTypeId = Convert.ToInt16(ChargeTypeEnum.InspectionCharge), OtherRate = ICCast, ServiceRequestId = CommonAttribute.TechEditServiceRequest.ServiceRequestId });
                serviceCostEstimation.ServiceCostEstimationOtherCharges.Add(new ServiceCostEstimationOtherChargeRequest() { ChargeTypeId = Convert.ToInt16(ChargeTypeEnum.TransportationCharge), OtherRate = TPCCast, ServiceRequestId = CommonAttribute.TechEditServiceRequest.ServiceRequestId });


                serviceCostEstimation.serviceCostEstimationPartCharges = new List<ServiceCostEstimationPartChargeRequest>();
                foreach (var item in SpareParts)
                {
                    //int qty = SpareParts.Where(u => u.PartStockBucketId == item.PartStockBucketId).Count();
                    ServiceCostEstimationPartChargeRequest serviceCostEstimationPart = new ServiceCostEstimationPartChargeRequest();
                    serviceCostEstimationPart.Cost = item.Cost;
                    serviceCostEstimationPart.PartNumber = item.PartNumber;
                    serviceCostEstimationPart.PartTotalCost = item.TotalAmount; //item.Cost * qty; Kumar
                    serviceCostEstimationPart.Quantity = item.Quantity; //qty; kumar
                                                                        // serviceCostEstimationPart.ServiceCostEstimationId = ?
                                                                        //  serviceCostEstimationPart.ServiceCostEstimationId = ?
                    serviceCostEstimation.serviceCostEstimationPartCharges.Add(serviceCostEstimationPart);
                }
                TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
                ReceiveContext<ResponseWithID> receiveContext = await technicianManagementSL.CreateServiceCostEstimations(serviceCostEstimation);
                if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
                {

                    await DisplayAlert(AppResources.lblSuccess, receiveContext.message);
                    //await Navigation.PushAsync(new TechMasterPage());
                    MessagingCenter.Send<string>("EstimationSuccess", "EstimationDone");
                }
                else if (receiveContext != null)
                {
                    await ErrorDisplayAlert(receiveContext.errorMessage);
                }
                else
                {
                    await ErrorDisplayAlert(AppResources.lblPleaseContactAdmin);
                }

                //IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            finally
            {
                IsBusy = false;
            }
            
        }

        //public async Task SaveEstimateTaskForJobClose()
        //{
        //    try
        //    {
        //        IsBusy = true;

        //        if (SCCast == 0)
        //        {
        //            await DisplayAlert("Alert", "Kindly enter service charge to proceed.");
        //            return;
        //        }

        //        if (ICCast == 0)
        //        {
        //            await DisplayAlert("Alert", "Kindly enter inspection charge to proceed.");
        //            return;
        //        }

        //        if (TPCCast == 0)
        //        {
        //            await DisplayAlert("Alert", "Kindly enter transportation charge to proceed.");
        //            return;
        //        }

        //        ServiceCostEstimationRequest serviceCostEstimation = new ServiceCostEstimationRequest();
        //        if (DiscountType == true)
        //        {
        //            serviceCostEstimation.DiscountByPercentage = Convert.ToInt16(DiscountAmount);//percentage
        //            serviceCostEstimation.DiscountAmount = OtherDiscountAmount;
        //        }
        //        else
        //        {
        //            serviceCostEstimation.DiscountByAmount = DiscountAmount;
        //            serviceCostEstimation.DiscountAmount = DiscountAmount;
        //        }

        //        serviceCostEstimation.estimationCreationDate = DateTime.Now;
        //        serviceCostEstimation.estimationApprovalDate = DateTime.Now;
        //        if (SelectedPromoCode != null && PromoCode != string.Empty)
        //        {
        //            serviceCostEstimation.PromoCode = PromoCode;
        //            //serviceCostEstimation.PromoCodeId = SelectedPromoCode.PromoCodeId == 0 ? null : SelectedPromoCode.PromoCodeId;

        //            if (SelectedPromoCode.PromoCodeId == 0)
        //            {
        //                serviceCostEstimation.PromoCodeId = null;
        //            }
        //            else
        //            {
        //                serviceCostEstimation.PromoCodeId = SelectedPromoCode.PromoCodeId;
        //            }
        //        }
        //        serviceCostEstimation.isApprovedByCustomer = true;
        //        serviceCostEstimation.status = true;
        //        serviceCostEstimation.serviceRequestId = CommonAttribute.TechEditServiceRequest.ServiceRequestId;
        //        serviceCostEstimation.serviceRequestCharges = new List<ServiceRequestChargeRequest>();

        //        if (SCCastEstimation != null)
        //            serviceCostEstimation.serviceRequestCharges.Add(new ServiceRequestChargeRequest() { ServiceChargeMasterId = (int)(SCCastEstimation?.ServiceChargeMasterId) });

        //        if (ICCastEstimation != null)
        //            serviceCostEstimation.serviceRequestCharges.Add(new ServiceRequestChargeRequest() { ServiceChargeMasterId = (int)(ICCastEstimation?.ServiceChargeMasterId) });

        //        if (TPCCastEstimation != null)
        //            serviceCostEstimation.serviceRequestCharges.Add(new ServiceRequestChargeRequest() { ServiceChargeMasterId = (int)(TPCCastEstimation?.ServiceChargeMasterId) });

        //        serviceCostEstimation.ServiceCostEstimationOtherCharges = new List<ServiceCostEstimationOtherChargeRequest>();

        //        serviceCostEstimation.ServiceCostEstimationOtherCharges.Add(new ServiceCostEstimationOtherChargeRequest() { ChargeTypeId = Convert.ToInt16(ChargeTypeEnum.ServiceCharge), OtherRate = SCCast, ServiceRequestId = CommonAttribute.TechEditServiceRequest.ServiceRequestId });
        //        serviceCostEstimation.ServiceCostEstimationOtherCharges.Add(new ServiceCostEstimationOtherChargeRequest() { ChargeTypeId = Convert.ToInt16(ChargeTypeEnum.InspectionCharge), OtherRate = ICCast, ServiceRequestId = CommonAttribute.TechEditServiceRequest.ServiceRequestId });
        //        serviceCostEstimation.ServiceCostEstimationOtherCharges.Add(new ServiceCostEstimationOtherChargeRequest() { ChargeTypeId = Convert.ToInt16(ChargeTypeEnum.TransportationCharge), OtherRate = TPCCast, ServiceRequestId = CommonAttribute.TechEditServiceRequest.ServiceRequestId });


        //        serviceCostEstimation.serviceCostEstimationPartCharges = new List<ServiceCostEstimationPartChargeRequest>();
        //        foreach (var item in SpareParts)
        //        {
        //            //int qty = SpareParts.Where(u => u.PartStockBucketId == item.PartStockBucketId).Count();
        //            ServiceCostEstimationPartChargeRequest serviceCostEstimationPart = new ServiceCostEstimationPartChargeRequest();
        //            serviceCostEstimationPart.Cost = item.Cost;
        //            serviceCostEstimationPart.PartNumber = item.PartNumber;
        //            serviceCostEstimationPart.PartTotalCost = item.TotalAmount; //item.Cost * qty; Kumar
        //            serviceCostEstimationPart.Quantity = item.Quantity; //qty; kumar
        //                                                                // serviceCostEstimationPart.ServiceCostEstimationId = ?
        //                                                                //  serviceCostEstimationPart.ServiceCostEstimationId = ?
        //            serviceCostEstimation.serviceCostEstimationPartCharges.Add(serviceCostEstimationPart);
        //        }
        //        TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
        //        ReceiveContext<ResponseWithID> receiveContext = await technicianManagementSL.CreateServiceCostEstimations(serviceCostEstimation);
        //        if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
        //        {
        //            await DisplayAlert(AppResources.lblSuccess, receiveContext.message);                   
        //        }
        //        else if (receiveContext != null)
        //        {
        //            await ErrorDisplayAlert(receiveContext.errorMessage);
        //        }
        //        else
        //        {
        //            await ErrorDisplayAlert(AppResources.lblPleaseContactAdmin);
        //        }

        //        //IsBusy = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        IsBusy = false;
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }

        //}

        public Command AddPartsCommand
        {
            get
            {
                return new Command(() =>
                {
                    try
                    {
                        IsBusy = true;
                        MessagingCenter.Unsubscribe<SparePartsViewModel, PartStockMaster>(this, "selectpart");
                        MessagingCenter.Subscribe<SparePartsViewModel, PartStockMaster>(this, "selectpart", (sender, arg) =>
                        {
                            var existingItem = SpareParts.Where(u => u.PartStockBucketId == arg.PartStockBucketId).FirstOrDefault();
                            //if(existingItem != null)
                            //{
                            //    SpareParts.Add(arg);
                            //    MasterSpareParts.Add(arg);
                            //}

                            //else
                            //{
                            //    SpareParts.Remove(existingItem);
                            // //   existingItem.Cost = existingItem.Cost+ arg.Cost;
                            //    existingItem.Quantity = existingItem.Quantity + arg.Quantity;
                            //    existingItem.TotalAmount = existingItem.Cost + arg.Cost;
                            //    SpareParts.Add(existingItem);
                            //    MasterSpareParts.Add(existingItem);
                            //}
                            SpareParts.Add(arg);
                            //MasterSpareParts.Add(arg);

                            PartCastEstimation = SpareParts.Sum(u => u.Cost);
                            PartCastEstimation = Math.Round(PartCastEstimation, 2);
                            TotalAmount = TotalAmount + PartCastEstimation;
                            calculateTotalAmount();
                            CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode;

                        });
                        IsBusy = false;
                        Navigation.PushAsync(new SparePartsPage(2));
                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                    finally
                    {
                        IsBusy = false;
                    }
                   
                });
            }
        }

        public Command DeletePartsCommand
        {
            get
            {
                return new Command<PartStockMaster>(async(item) =>
                {
                    try
                    {
                        IsBusy = true;

                        ReturnSpareParts = new PartRequest();
                        TechnicianManagementSL managementSL = new TechnicianManagementSL();
                        ReturnSpareParts.ServiceRequestId = CommonAttribute.SelectedServiceRequest?.ServiceRequestId;
                        if (item.ServiceCenterId != 0)
                            ReturnSpareParts.ServiceCenterId = item.ServiceCenterId;
                        else
                            ReturnSpareParts.ServiceCenterId = (int)(CommonAttribute.CustomeProfile?.PersonServiceCenters?.FirstOrDefault().ServiceCenterId);
                        ReturnSpareParts.RequestDate = DateTime.Now;
                        ReturnSpareParts.RequestedByTechnicianId = CommonAttribute.CustomeProfile.PersonId;
                        ReturnSpareParts.PartUsedInServiceFromBucketId = (int)PartStockBucketEnum.AllocatedStock;
                        ReturnSpareParts.PartRequestTypeId = Convert.ToInt16(PartRequestTypeEnum.ReturnRequest);
                        ReturnSpareParts.PartRequestStatusId = Convert.ToInt16(PartRequestStatusEnum.Open);
                        ReturnSpareParts.UpdatedDate = DateTime.Now;
                        ReturnSpareParts.PartNumber = item.PartNumber;
                        ReturnSpareParts.RequestedPartQuantity = item.Quantity;
                        TotalAmount = TotalAmount - (item.TotalAmount);
                        var receiveContext = await managementSL.AddPartRequests(ReturnSpareParts);
                        if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
                        {
                            await DisplayAlert(AppResources.lblSuccess, receiveContext.message);
                        }
                        else if (receiveContext != null)
                        {
                            await ErrorDisplayAlert(receiveContext.errorMessage);
                        }
                        else
                        {
                            await ErrorDisplayAlert(Resx.AppResources.lblErrorTitle);
                        }

                        SpareParts.Remove(item);
                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;

                    }
                    finally
                    {
                        IsBusy = false;

                    }

                });
            }
        }

        private PartRequest _ReturnSpareParts;
        public PartRequest ReturnSpareParts
        {
            get { return _ReturnSpareParts; }
            set
            {
                _ReturnSpareParts = value;
                OnPropertyChanged("ReturnSpareParts");
            }
        }

        private decimal _SubTotalAmount;
        public decimal SubTotalAmount
        {
            get { return _SubTotalAmount; }
            set
            {
                _SubTotalAmount = value;
                OnPropertyChanged(nameof(SubTotalAmount));
            }
        }

        public PromoCode SelectedPromoCode { get; set; }
        private bool _partTab;
        public bool partTab
        {
            get { return _partTab; }
            set
            {
                _partTab = value;
                OnPropertyChanged("partTab");
            }
        }
        private bool _DiscountType;
        public bool DiscountType
        {
            get { return _DiscountType; }
            set
            {
                _DiscountType = value;
                calculateTotalAmount();
                OnPropertyChanged(nameof(DiscountType));
            }
        }
        //DiscountAmount
        private decimal _DiscountAmount;
        public decimal DiscountAmount
        {
            get { return _DiscountAmount; }
            set
            {
                _DiscountAmount = value;
                if (DiscountType)
                {
                    decimal discount = (DiscountAmount / 100) * TotalAmount;
                    OtherDiscountAmount =Math.Round(discount);
                }
                calculateTotalAmount();
                OnPropertyChanged("DiscountAmount");
            }
        }
        private decimal _OtherDiscountAmount;
        public decimal OtherDiscountAmount
        {
            get { return _OtherDiscountAmount; }
            set
            {
                _OtherDiscountAmount = value;
                OnPropertyChanged("OtherDiscountAmount");
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
        private bool _btnVisible;
        public bool btnVisible
        {
            get { return _btnVisible; }
            set
            {
                _btnVisible = value;
                OnPropertyChanged("btnVisible");
            }
        }

        private bool _IsJobCloseVisible;
        public bool IsJobCloseVisible
        {
            get { return _IsJobCloseVisible; }
            set
            {
                _IsJobCloseVisible = value;
                OnPropertyChanged("IsJobCloseVisible");
            }
        }

        private ServiceRequestDetailsResponse _serviceRequest;
        public ServiceRequestDetailsResponse serviceRequest
        {
            get { return _serviceRequest; }
            set
            {
                _serviceRequest = value;
                OnPropertyChanged("serviceRequest");
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

        //ServiceCostEstimation
        private ObservableCollection<ServiceCostEstimationResponse> _ExistingServiceCostEstimation;
        public ObservableCollection<ServiceCostEstimationResponse> ExistingServiceCostEstimation
        {
            get { return _ExistingServiceCostEstimation; }
            set
            {
                _ExistingServiceCostEstimation = value;
                OnPropertyChanged("ExistingServiceCostEstimation");
            }
        }
        private ObservableCollection<PartStockMaster> _SpareParts;
        public ObservableCollection<PartStockMaster> SpareParts
        {
            get { return _SpareParts; }
            set
            {
                _SpareParts = value;
                OnPropertyChanged("SpareParts");
            }
        }
        private ObservableCollection<PartStockMaster> _MasterSpareParts;
        public ObservableCollection<PartStockMaster> MasterSpareParts
        {
            get { return _SpareParts; }
            set
            {
                _SpareParts = value;
                OnPropertyChanged("SpareParts");
            }
        }
        private decimal _PartCastEstimation;
        public decimal PartCastEstimation
        {
            get { return _PartCastEstimation; }
            set
            {
                _PartCastEstimation = value;
                OnPropertyChanged("PartCastEstimation");
            }
        }
        private decimal _SCCast;
        public decimal SCCast
        {
            get { return _SCCast; }
            set
            {
                _SCCast = value;
                calculateTotalAmount();
                OnPropertyChanged("SCCast");
            }
        }
        private decimal _ICCast;
        public decimal ICCast
        {
            get { return _ICCast; }
            set
            {
                _ICCast = value;
                calculateTotalAmount();
                OnPropertyChanged("ICCast");
            }
        }
        private decimal _TPCCast;
        public decimal TPCCast
        {
            get { return _TPCCast; }
            set
            {
                _TPCCast = value;
                calculateTotalAmount();
                OnPropertyChanged("TPCCast");
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
        private ServiceChargeMasterResponse _SCCastEstimation;
        public ServiceChargeMasterResponse SCCastEstimation
        {
            get { return _SCCastEstimation; }
            set
            {
                _SCCastEstimation = value;
                OnPropertyChanged("SCCastEstimation");
            }
        }
        private ServiceChargeMasterResponse _ICCastEstimation;
        public ServiceChargeMasterResponse ICCastEstimation
        {
            get { return _ICCastEstimation; }
            set
            {
                _ICCastEstimation = value;
                OnPropertyChanged("ICCastEstimation");
            }
        }
        private ServiceChargeMasterResponse _TPCCastEstimation;
        public ServiceChargeMasterResponse TPCCastEstimation
        {
            get { return _TPCCastEstimation; }
            set
            {
                _TPCCastEstimation = value;
                OnPropertyChanged("TPCCastEstimation");
            }
        }

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

        private string _BtnEstimation;
        public string BtnEstimation
        {
            get { return _BtnEstimation; }
            set
            {
                _BtnEstimation = value;
                OnPropertyChanged(nameof(BtnEstimation));
            }
        }

    }
}
