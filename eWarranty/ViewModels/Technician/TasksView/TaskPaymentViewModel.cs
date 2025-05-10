using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Views.Technician.TaskViews;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Technician.TasksView
{
    public class TaskPaymentViewModel : BaseViewModel
    {
        public event EventHandler SignaturePadViewItem;
        public TaskPaymentViewModel(INavigation navigation,decimal TotalAmount) : base(navigation)
        {
            try
            {
                if (PaymentModes == null)
                    PaymentModes = new ObservableCollection<DropDownModel>();
                PaymentModes.Add(new DropDownModel() { Id = Convert.ToInt16(PaymentModeEnum.CashPayment), Title = "Cash Payment" });
                PaymentModes.Add(new DropDownModel() { Id = Convert.ToInt16(PaymentModeEnum.CardPayment), Title = "Card Payment" });

                serviceRequest = CommonAttribute.TechEditServiceRequest;
                serviceRequest.EndDateTime = DateTime.Now;
                var ServiceCostEstimations = serviceRequest.ServiceCostEstimations.ToList();

                //Rate= ServiceCostEstimations.OrderByDescending(x=>x.ServiceCostEstimationId).FirstOrDefault().ServiceRequestCharges.Sum(u => u.ServiceChargeMaster.Rate);
                //Rate = Rate+ServiceCostEstimations.OrderByDescending(x => x.ServiceCostEstimationId).FirstOrDefault().ServiceCostEstimationPartCharges.Sum(u => u.Cost);
                Rate = TotalAmount;
                AmountToBePaid = TotalAmount;
                //CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyMasterResponse?.Code;
                CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode;

                //IsBusy = true;
                //Device.BeginInvokeOnMainThread(async () =>
                //{
                //    await GetTotalCostEstimationAmount();
                //    IsBusy = false;
                //});

                //if (serviceRequest.ProductModel.ActiveWarrantyCustomerProduct.WarrantyTypeId == 0)
                //    btnpayment = "Confirm Payment";
                //else
                    btnpayment = "Close Job";
            }
            catch (Exception ex)
            {

            }
            

        }

        public TaskPaymentViewModel(INavigation navigation) : base(navigation)
        {
            try
            {
                if (PaymentModes == null)
                    PaymentModes = new ObservableCollection<DropDownModel>();
                PaymentModes.Add(new DropDownModel() { Id = Convert.ToInt16(PaymentModeEnum.CashPayment), Title = "Cash Payment" });
                PaymentModes.Add(new DropDownModel() { Id = Convert.ToInt16(PaymentModeEnum.CardPayment), Title = "Card Payment" });

                serviceRequest = CommonAttribute.TechEditServiceRequest;
                serviceRequest.EndDateTime = DateTime.Now;

                IsBusy = true;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await GetTotalCostEstimationAmount();
                    IsBusy = false;
                });

                //if (serviceRequest.ProductModel.ActiveWarrantyCustomerProduct.WarrantyTypeId == 0)
                //    btnpayment = "Confirm Payment";
                //else
                    btnpayment = "Close Job";
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            

        }

        public Command PaymentModeCommand
        {
            get
            {
                return new Command<DropDownModel>((obj) =>
                {
                    SelectedPaymentMode = obj;


                });
            }
        }

        public async Task GetTotalCostEstimationAmount()
        {
            try
            {
                ServiceRequestSL serviceRequestSL = new ServiceRequestSL();
                ServiceCostEstimationCustomerResponse serviceCostEstimationCustomerResponse =
                   await serviceRequestSL.GetServiceRequestCostEstimationForCustomer((long)serviceRequest?.ServiceRequestId);
                if (serviceCostEstimationCustomerResponse != null)
                {
                    AmountToBePaid = (decimal)(serviceCostEstimationCustomerResponse?.TotalAmount);
                    Rate = (decimal)(serviceCostEstimationCustomerResponse?.TotalAmount);
                }                
            }
            catch(Exception ex)
            {
                IsBusy = false;
            }
            
        }

        public async Task ConfirmPayment()
        {
            try
            {
                if (IsSigBlank)
                {
                    await ErrorDisplayAlert("Please provide customer signature.");
                    return;
                }
                if (SelectedPaymentMode == null)
                {
                    await ErrorDisplayAlert("Please select payment mode.");
                    return;
                }
                if (AmountToBePaid > Rate)
                {
                    await ErrorDisplayAlert("Paid amount should be less than total amount.");
                    return;
                }
                //if(signatureBase64string==null || signatureBase64string == string.Empty)
                //{
                //    await ErrorDisplayAlert("Please enter the signature");
                //    return;
                //}
                EventHandler handler = SignaturePadViewItem;
                handler?.Invoke(this, null);


                TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
                CreateInvoiceRequest createInvoice = new CreateInvoiceRequest();
                createInvoice.PaymentModeId = SelectedPaymentMode.Id;
                createInvoice.ServiceRequestId = serviceRequest.ServiceRequestId;
                createInvoice.Sign = signatureBase64string;
                createInvoice.PaymentAmount = AmountToBePaid;
                createInvoice.IsServiceChargeable = IsChargeableJob;//serviceRequest.IsServiceChargeable;

                //  createInvoice.IsPromoCodeApplied = false;
                var receiveContext = await technicianManagementSL.SRCreateInvoice(createInvoice);
                if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
                {
                    await Navigation.PushAsync(new PaymentSuccessfulPage());
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
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            
            
        }

        public Command SubmitCommand
        {
            get
            {
                return new Command( () =>
                {
                    //IsBusy = true;
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        IsBusy = true;
                        await Task.Delay(TimeSpan.FromSeconds(1));
                        await ConfirmPayment();
                        IsBusy = false;
                    });

                });
            }
        }

        private string _btnpayment;
        public string btnpayment
        {
            get { return _btnpayment; }
            set
            {
                _btnpayment = value;
                OnPropertyChanged(nameof(btnpayment));
            }
        }


        public string signatureBase64string { get; set; }
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

        private bool _IsChargeableJob;
        public bool IsChargeableJob
        {
            get { return _IsChargeableJob; }
            set
            {
                _IsChargeableJob = value;
                OnPropertyChanged("IsChargeableJob");
            }
        }

        //IsBlank
        private bool _IsSigBlank;
        public bool IsSigBlank
        {
            get { return _IsSigBlank; }
            set
            {
                _IsSigBlank = value;
                OnPropertyChanged("IsSigBlank");
            }
        }
        private  decimal _AmountToBePaid;
        public  decimal AmountToBePaid
        {
            get { return _AmountToBePaid; }
            set
            {
                _AmountToBePaid = value;
                OnPropertyChanged("AmountToBePaid");
            }
        }
        private decimal _Rate;
        public decimal Rate
        {
            get { return _Rate; }
            set
            {
                _Rate = value;
                OnPropertyChanged("Rate");
            }
        }
        private ObservableCollection<DropDownModel> _PaymentModes;
        public ObservableCollection<DropDownModel> PaymentModes
        {
            get { return _PaymentModes; }
            set
            {
                _PaymentModes = value;
                OnPropertyChanged("PaymentModes");
            }
        }
        private DropDownModel _SelectedPaymentMode;
        public DropDownModel SelectedPaymentMode
        {
            get { return _SelectedPaymentMode; }
            set
            {
                _SelectedPaymentMode = value;
                OnPropertyChanged("SelectedPaymentMode");
            }
        }
        //SelectedPaymentMode
    }
}
