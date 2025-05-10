using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Views.Customer.Accesssories;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace eWarranty.ViewModels.Customer.Accesssories
{
    public class MyOrderHistoryViewModel : BaseViewModel
    {
        public MyOrderHistoryViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;
            //Device.BeginInvokeOnMainThread(async () => {
            //    await BindingData();
            //    IsBusy = false;
            //});

        }
        public async Task BindingData()
        {
            try
            {
                AccessoryManagementSL accessoryManagementSL = new AccessoryManagementSL();
                var orders = await accessoryManagementSL.GetOrderListByPersonId(CommonAttribute.CustomeProfile.PersonId);
                OrderResponses = new ObservableCollection<OrderListResponse>(orders);
                //if (CommonAttribute.selectedLang.lid == 2)
                //{
                //    OrderResponses.ForEach(r => r.Rotation = 180);
                //}
                //else
                //{
                //    OrderResponses.ForEach(r => r.Rotation = 0);
                //}
            }
            catch(Exception ex)
            {

            }
            IsBusy = false;
        }
        public Command SelectedItemCommand
        {
            get
            {
                return new Command<OrderListResponse>(async (item) =>
                {
                     await  Navigation.PushAsync(new MyOrderDetailsPage(item));
                });
            }
        }

        
        private ObservableCollection<OrderListResponse> _OrderResponses;
        public ObservableCollection<OrderListResponse> OrderResponses
        {
            get { return _OrderResponses; }
            set
            {
                _OrderResponses = value;
                OnPropertyChanged("OrderResponses");
            }
        }
        //private ObservableCollection<OrderResponse> _OrderResponses;
        //public ObservableCollection<OrderResponse> OrderResponses
        //{
        //    get { return _OrderResponses; }
        //    set
        //    {
        //        _OrderResponses = value;
        //        OnPropertyChanged("OrderResponses");
        //    }
        //}
    }
}
