using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Supervisor
{
    public class ServiceRequestDetailsViewModel : BaseViewModel
    {

        public ServiceRequestDetailsViewModel(INavigation navigation, int SelectedSRRequest) : base(navigation)
        {
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
                await BindingData(SelectedSRRequest);
            });
        }

        public async Task BindingData(int selectedid)
        {
            try
            {
                ServiceRequestDetails = new ServiceRequestDetailsSupervisorResponse();
                ServiceRequestSL serviceRequestSL = new ServiceRequestSL();
                ServiceRequestDetails = await serviceRequestSL.GetServiceRequestWithoutInvoiceDetails(selectedid);

                if (ServiceRequestDetails != null)
                {
                    CustName = ServiceRequestDetails.SupervisorName;
                    Location = ServiceRequestDetails?.ServiceRequestAddress?.BuildingName + ", " + ServiceRequestDetails?.ServiceRequestAddress?.Area;
                    RequestDate = ServiceRequestDetails.CreationDate;
                    CustPreferredDateTime = ServiceRequestDetails.CustomerSrpreferredDateTime;
                    RequestType = ServiceRequestDetails.ServiceRequestTypeName;

                    ModelNumber = ServiceRequestDetails.ModelNumber;
                    SerialNumber = ServiceRequestDetails.SerialNumber;
                    ProductCategory = ServiceRequestDetails.ProductClassificationName;
                    ModelWarranty = ServiceRequestDetails.ProductModelWarrantyTypeName;
                    PurchaseDate = ServiceRequestDetails.PurchaseDate;
                }

                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
           
        }

        #region Properties
        public ServiceRequestDetailsSupervisorResponse ServiceRequestDetails { get; set; }

        //Customer Details

        private string _CustName;
        public string CustName
        {
            get { return _CustName; }
            set
            {
                _CustName = value;
                OnPropertyChanged(nameof(CustName));
            }
        }

        private string _Location;
        public string Location
        {
            get { return _Location; }
            set
            {
                _Location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        private DateTime _RequestDate;
        public DateTime RequestDate
        {
            get { return _RequestDate; }
            set
            {
                _RequestDate = value;
                OnPropertyChanged(nameof(RequestDate));
            }
        }

        private string _RequestType;
        public string RequestType
        {
            get { return _RequestType; }
            set
            {
                _RequestType = value;
                OnPropertyChanged(nameof(RequestType));
            }
        }

        private DateTime? _CustPreferredDateTime;
        public DateTime? CustPreferredDateTime
        {
            get { return _CustPreferredDateTime; }
            set
            {
                _CustPreferredDateTime = value;
                OnPropertyChanged(nameof(CustPreferredDateTime));
            }
        }

        //Product Details
        private string _ModelNumber;
        public string ModelNumber
        {
            get { return _ModelNumber; }
            set
            {
                _ModelNumber = value;
                OnPropertyChanged(nameof(ModelNumber));
            }
        }

        private string _SerialNumber;
        public string SerialNumber
        {
            get { return _SerialNumber; }
            set
            {
                _SerialNumber = value;
                OnPropertyChanged(nameof(SerialNumber));
            }
        }

        private string _ProductCategory;
        public string ProductCategory
        {
            get { return _ProductCategory; }
            set
            {
                _ProductCategory = value;
                OnPropertyChanged(nameof(ProductCategory));
            }
        }

        private string _ModelWarranty;
        public string ModelWarranty
        {
            get { return _ModelWarranty; }
            set
            {
                _ModelWarranty = value;
                OnPropertyChanged(nameof(ModelWarranty));
            }
        }

        private DateTime? _PurchaseDate;
        public DateTime? PurchaseDate
        {
            get { return _PurchaseDate; }
            set
            {
                _PurchaseDate = value;
                OnPropertyChanged(nameof(PurchaseDate));
            }
        }

        #endregion

    }
}

