using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Hepler;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace eWarranty.ViewModels.Customer.SRDetails.SubViews
{
    public class CustomerSparePartsViewModel : BaseViewModel
    {
        public CustomerSparePartsViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;

            Device.BeginInvokeOnMainThread(async () => {
                await BindingData();
                IsBusy = false;
            });
        }
        public async Task BindingData()
        {
            try
            {
                if (SpareParts == null)
                    SpareParts = new ObservableCollection<PartStockMaster>();
                var ServiceCostEstimation = CommonAttribute.EditServiceRequest.Invoices.ToList();
                if (ServiceCostEstimation.Count != 0)
                {
                    InvoiceResponse = ServiceCostEstimation[0];
                    InvoiceResponse.InvoiceLineItems.ForEach(c => c.CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode);
                    RowHeight = InvoiceResponse.InvoiceLineItems.Count * 40;
                    NoInvoice = false;
                }
                else
                {
                    NoInvoice = true;
                }
                //if(ServiceCostEstimation.Count != 0)
                //{
                //    var ServiceRequestCharges = ServiceCostEstimation[0].ServiceRequestCharges.ToList();
                //    int scId = Convert.ToInt16(ChargeTypeEnum.ServiceCharge);
                //    var scIdItem = ServiceRequestCharges.Where(u => u.ServiceChargeMaster?.ChargeTypeId == scId).FirstOrDefault();
                //    ServiceCharge = Convert.ToDecimal(scIdItem?.ServiceChargeMaster.Rate);

                //    int icId = Convert.ToInt16(ChargeTypeEnum.InspectionCharge);
                //    var icIdItem = ServiceRequestCharges.Where(u => u.ServiceChargeMaster?.ChargeTypeId == icId).FirstOrDefault();
                //    InspectionCharge = Convert.ToDecimal(icIdItem?.ServiceChargeMaster.Rate);

                //    int tpcId = Convert.ToInt16(ChargeTypeEnum.TransportationCharge);
                //    var tpcIdItem = ServiceRequestCharges.Where(u => u.ServiceChargeMaster?.ChargeTypeId == tpcId).FirstOrDefault();
                //    TransportationCharge = Convert.ToDecimal(tpcIdItem?.ServiceChargeMaster.Rate);


                //    var ServiceRequestPartCharges = ServiceCostEstimation[0].ServiceCostEstimationPartCharges.ToList();
                //    foreach (var item in ServiceRequestPartCharges)
                //    {
                //        PartStockMaster partStock = new PartStockMaster();
                //        partStock.Cost = item.Cost;
                //        partStock.PartNumber = item.PartNumber;
                //        partStock.Quantity = item.Quantity;
                //        SpareParts.Add(partStock);
                //        PartCharge = PartCharge + item.Cost;
                //    }
                //    TotalCharge = ServiceCharge + InspectionCharge + TransportationCharge + PartCharge;

                //}


            }
            catch (Exception ex)
            {

            }
            

        }
        //PartCharge
        private InvoiceResponse _InvoiceResponse;
        public InvoiceResponse InvoiceResponse
        {
            get { return _InvoiceResponse; }
            set
            {
                _InvoiceResponse = value;
                OnPropertyChanged("InvoiceResponse");
            }
        }
        private decimal _TransportationCharge;
        public decimal TransportationCharge
        {
            get { return _TransportationCharge; }
            set
            {
                _TransportationCharge = value;
                OnPropertyChanged("TransportationCharge");
            }
        }
        private bool _NoInvoice;
        public bool NoInvoice
        {
            get { return _NoInvoice; }
            set
            {
                _NoInvoice = value;
                OnPropertyChanged("NoInvoice");
            }
        }
        private decimal _RowHeight;
        public decimal RowHeight
        {
            get { return _RowHeight; }
            set
            {
                _RowHeight = value;
                OnPropertyChanged("RowHeight");
            }
        }
        private decimal _InspectionCharge;
        public decimal InspectionCharge
        {
            get { return _InspectionCharge; }
            set
            {
                _InspectionCharge = value;
                OnPropertyChanged("InspectionCharge");
            }
        }
        private decimal _ServiceCharge;
        public decimal ServiceCharge
        {
            get { return _ServiceCharge; }
            set
            {
                _ServiceCharge = value;
                OnPropertyChanged("ServiceCharge");
            }
        }
        private decimal _TotalCharge;
        public decimal TotalCharge
        {
            get { return _TotalCharge; }
            set
            {
                _TotalCharge = value;
                OnPropertyChanged("TotalCharge");
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
    }
}
