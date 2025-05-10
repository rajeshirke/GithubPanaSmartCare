using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.SRDetails
{
    public class SREditDetailsViewModel : BaseViewModel
    {
        public SREditDetailsViewModel(INavigation navigation, long sid, int tabid) : base(navigation)
        {
            ServiceRequestId = sid;
            Tabid = tabid;
            IsBusy = true;
            Device.BeginInvokeOnMainThread( async() => {
                 await BindingData();
            IsBusy = false;
             });
        }
        #region Method
        public async Task BindingData()
        {
            try
            {
                TabOptions = new List<TabOption>()
                    {
                        {new TabOption(){  Name=AppResources.lblSRDetails,IsSelected=true,id=1} },
                        {new TabOption(){  Name=AppResources.lblFollowUp,id=2} },
                        {new TabOption(){  Name=AppResources.lblProductDetails,id=3} },                       
                        {new TabOption(){  Name=AppResources.lblCostEstimation,id=4} },

                     //   {new TabOption(){  Name="Cost Estimation",id=4} },
                      //  {new TabOption(){  Name="Invoice",id=5} }
                    };
                if (Tabid == 2)
                {
                    UpdateSelectedItem(AppResources.lblFollowUp);
                }
                //MessagingCenter.Unsubscribe<ServicesViewModel, string>(this, "tab");
                //MessagingCenter.Subscribe<ServicesViewModel, string>(this, "tab", (sender, arg) =>
                //{
                //    if (arg == "SR Details")
                //    {
                //        UpdateSelectedItem("SR Details");
                //    }
                //    else if (arg == "Product Deatils")
                //    {
                //        UpdateSelectedItem("Product Deatils");
                //        MessagingCenter.Send<SREditDetailsViewModel, string>(this, "uitab", "ProductDeatils");
                //    }
                //    else
                //    {
                //        UpdateSelectedItem("Follow-Up");
                //        MessagingCenter.Send<SREditDetailsViewModel, string>(this, "uitab", "followupView");
                //    }
                //    MessagingCenter.Unsubscribe<ServicesViewModel, string>(this, "tab");
                //});

                AddProductCommand = new Command(() =>
                {

                });

                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            
        }
        public async Task Getdata(long SRequestId)
        {
            IsBusy = true;
            ServiceRequestSL serviceRequestSL = new ServiceRequestSL();
            //serviceRequest = await serviceRequestSL.GetServiceRequestImprovedAllDetails(SRequestId); // before by kumar - ServiceRequestId

            //new by anu
            serviceRequestNew = new ServiceRequestDetailsNewResponse();
            serviceRequestNew = await serviceRequestSL.GetServiceRequestImprovedAllDetailsNew(CommonAttribute.CustomerSRidSelected);

            //TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
            // serviceRequest = await technicianManagementSL.GetTechnicianServiceRequestDetails(ServiceRequestId);
            if (serviceRequestNew != null)
            {
                CommonAttribute.EditServiceRequest = serviceRequestNew;
                //GetServiceRequestDetails
                //   ProductModel = CommonAttribute.EditServiceRequest.ProductModelWarrantyResponse;
                //RegistrationNumber = ProductModel.RegistrationNumber;
                //ModelNumber = ProductModel.ModelNumber;
                //SerialNumber = "45345654DSDSF";
                //PurchaseInvoiceDate = Convert.ToDateTime(ProductModel.PurchaseInvoiceDate).ToString("MMM:dd:yyyy");
                //PurchaseInvoiceNumber = ProductModel.PurchaseInvoiceNumber;
            }
            else
            {
                await ErrorDisplayAlert(AppResources.lblAPIError);
            }
            IsBusy = false;

        }
        public Command CallServiceCentorCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (serviceRequest?.ServiceCenter?.ContactNumber1 != null && serviceRequest?.ServiceCenter?.ContactNumber1 != string.Empty && serviceRequest?.ServiceCenter?.ContactNumber1 != "")
                        {
                            Extensions.PlacePhoneCall(serviceRequest?.ServiceCenter?.ContactNumber1);
                        }
                        else if (serviceRequest?.ServiceCenter?.ContactNumber2 != null && serviceRequest?.ServiceCenter?.ContactNumber2 != string.Empty && serviceRequest?.ServiceCenter?.ContactNumber2 != "")
                        {
                            Extensions.PlacePhoneCall(serviceRequest?.ServiceCenter?.ContactNumber2);
                        }
                        else
                        {
                            await ErrorDisplayAlert(AppResources.ErrorMsgMobilenumberisnotavailable);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    
                });
            }
        }
        public void UpdateSelectedItem(string tabName)
        {
            List<TabOption> items = new List<TabOption>();
            foreach (var item in TabOptions)
            {
                item.IsSelected = false;
                if (item.Name == tabName)
                {
                    item.IsSelected = true;
                    SelectedTabOption = item;
                }
                items.Add(item);
            }
            TabOptions = items;
        }
        #endregion
        #region events
        public ICommand AddProductCommand { get; set; }
        #endregion
        #region Properties

        private ServiceRequestDetailsNewResponse _serviceRequestNew;
        public ServiceRequestDetailsNewResponse serviceRequestNew
        {
            get { return _serviceRequestNew; }
            set
            {
                _serviceRequestNew = value;
                OnPropertyChanged(nameof(serviceRequestNew));
            }
        }


        public int Tabid { get; set; }
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
        //private ProductModelWarrantyResponse _ProductModel;
        //public ProductModelWarrantyResponse ProductModel
        //{
        //    get { return _ProductModel; }
        //    set
        //    {
        //        _ProductModel = value;
        //        OnPropertyChanged("ProductModel");
        //    }
        //}
        private List<TabOption> _TabOptions;
        public List<TabOption> TabOptions
        {
            get { return _TabOptions; }
            set
            {
                _TabOptions = value;
                OnPropertyChanged("TabOptions");
            }
        }
        private TabOption _SelectedTabOption;
        public TabOption SelectedTabOption
        {
            get { return _SelectedTabOption; }
            set
            {
                _SelectedTabOption = value;
                OnPropertyChanged("SelectedTabOption");
            }
        }
        private long _ServiceRequestId;
        public long ServiceRequestId
        {
            get { return _ServiceRequestId; }
            set
            {
                _ServiceRequestId = value;
                OnPropertyChanged("ServiceRequestId");
            }
        }
        #endregion
    }
}
