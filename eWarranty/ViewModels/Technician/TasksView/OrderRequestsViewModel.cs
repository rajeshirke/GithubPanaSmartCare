using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Technician.TasksView
{
    public class OrderRequestsViewModel : BaseViewModel
    {
        public OrderRequestsViewModel(INavigation navigation):base(navigation)
        {
            //IsBusy = true;
            //DataBinding();

            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () => {
                await DataBinding();
                IsBusy = false;
            });
        }
        public ICommand AdressdirectionCommand { get; set; }
        public async Task DataBinding()
        {

            await TechnicianOrderRequests();
            AdressdirectionCommand = new Command<AccessoryOrderDetailResponse>(async (AccessoryOrderDetail) =>  await GetAddress(AccessoryOrderDetail));//async () =>
            //{
            //    await ErrorDisplayAlert("Na data found");
            //});
            //IsBusy = false;
        }

        private async Task GetAddress(AccessoryOrderDetailResponse AccessoryOrderDetail)
        {
             //ErrorDisplayAlert("Na data found");
            if (AccessoryOrderDetail?.DeliveryAddress?.Longitude != null && AccessoryOrderDetail?.DeliveryAddress?.Latitude != null)
            {

                var location = new Xamarin.Essentials.Location(Convert.ToDouble(AccessoryOrderDetail.DeliveryAddress.Latitude), Convert.ToDouble(AccessoryOrderDetail.DeliveryAddress.Longitude));
                var placemark = new Placemark
                {

                    AdminArea = AccessoryOrderDetail.DeliveryAddress.Street,
                    Thoroughfare = AccessoryOrderDetail.DeliveryAddress.City,
                    Locality = AccessoryOrderDetail.DeliveryAddress.Area,

                };

                var options = new MapLaunchOptions { Name = AccessoryOrderDetail.DeliveryAddress.BuildingName };

                await Xamarin.Essentials.Map.OpenAsync(location, options);
            }
        }

        public async Task TechnicianOrderRequests()
        {
            TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();

            List<AccessoryOrderDetailResponse> accessoryOrderDetails  = await technicianManagementSL.GetTechnicianOrderRequests(CommonAttribute.CustomeProfile.PersonId);

            accessoryOrderDetailResponses = new ObservableCollection<AccessoryOrderDetailResponse>(accessoryOrderDetails);
            //OrderDetails = new ObservableCollection<OrderDetailResponse>(OrderResponses.OrderDetails);

            
        }

        //public Command AdressdirectionCommand
        //{
        //    get
        //    {
        //        return new Command<AccessoryOrderDetailResponse>(async (item) =>
        //        {
                    
        //            await ErrorDisplayAlert(item.OrderId.ToString());

        //            //if(AccessoryOrderDetail?.DeliveryAddress?.Longitude != null && AccessoryOrderDetail?.DeliveryAddress?.Latitude != null)
        //            //{

        //            //    var location = new Xamarin.Essentials.Location(Convert.ToDouble(AccessoryOrderDetail.DeliveryAddress.Latitude), Convert.ToDouble(AccessoryOrderDetail.DeliveryAddress.Longitude));
        //            //    var placemark = new Placemark
        //            //    {

        //            //        AdminArea = AccessoryOrderDetail.DeliveryAddress.Street,
        //            //        Thoroughfare = AccessoryOrderDetail.DeliveryAddress.City,
        //            //        Locality = AccessoryOrderDetail.DeliveryAddress.Area,

        //            //    };

        //            //    var options = new MapLaunchOptions { Name = AccessoryOrderDetail.DeliveryAddress.BuildingName };

        //            //    await Xamarin.Essentials.Map.OpenAsync(location, options);
        //            //}

        //        });
        //    }
        //}

        private OrderResponse _OrderResponses;
        public OrderResponse OrderResponses
        {
            get { return _OrderResponses; }
            set
            {
                _OrderResponses = value;
                OnPropertyChanged("OrderResponses");
            }
        }

        //private AccessoryOrderDetailResponse _AccessoryOrderDetail;
        //public AccessoryOrderDetailResponse AccessoryOrderDetail
        //{
        //    get { return _AccessoryOrderDetail; }
        //    set
        //    {
        //        _AccessoryOrderDetail = value;
        //        OnPropertyChanged("AccessoryOrderDetail");
        //    }
        //}

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

        private ObservableCollection<OrderDetailResponse> _OrderDetails;
        public ObservableCollection<OrderDetailResponse> OrderDetails
        {
            get { return _OrderDetails; }
            set
            {
                _OrderDetails = value;
                OnPropertyChanged("OrderDetails");
            }
        }

        private ObservableCollection<AccessoryOrderDetailResponse> _accessoryOrderDetailResponses;
        public ObservableCollection<AccessoryOrderDetailResponse> accessoryOrderDetailResponses
        {
            get { return _accessoryOrderDetailResponses; }
            set
            {
                _accessoryOrderDetailResponses = value;
                OnPropertyChanged("accessoryOrderDetailResponses");
            }
        }

    }
}

