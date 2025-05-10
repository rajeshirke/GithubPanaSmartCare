using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Views.Customer.AMCRequest;
using eWarranty.Views.Customer.Products;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.AMCRequest
{
    public class AMCRequestListViewModel : BaseViewModel
    {
        public AMCRequestListViewModel(INavigation navigation) : base(navigation)
        {
            Device.BeginInvokeOnMainThread(async () => {
                await BindingData();
                IsBusy = false;
            });
            AddNewCommand = new Command(() =>
            {
                //AddAMCRequestPage
                Navigation.PushAsync(new SelectProductsPage("AddAMCRequestPage"));
            });
        }
        public async Task BindingData()
        {
            try
            {
                AmcRequestManagementSL amcRequestManagement = new AmcRequestManagementSL();
                List<AmcRequestCustomerLimitedResponse> response = await amcRequestManagement.GetAmcRequestsByCustomer(CommonAttribute.CustomeProfile.PersonId);
                if (response != null)
                {
                    AmcList = new ObservableCollection<AmcRequestCustomerLimitedResponse>(response.OrderByDescending(d => d.AmcRequestNumber));
                    rowHeight = AmcList.Count * 50;
                }
            }
            catch (Exception ex)
            {

            }
           
                
        }

        public Command AMCSelectedItemCommand
        {
            get
            {
                return new Command<AmcRequestCustomerLimitedResponse>(async (item) =>
                {
                    await PopupNavigation.Instance.PushAsync(new AMCSelectedItemPopupView(item));
                });
            }
        }
        #region events

        public ICommand AddNewCommand { get; set; }
        #endregion
        private double _rowHeight;
        public double rowHeight
        {
            get { return _rowHeight; }
            set
            {
                _rowHeight = value;
                OnPropertyChanged("rowHeight");
            }
        }
        private ObservableCollection<AmcRequestCustomerLimitedResponse> _AmcList;
        public ObservableCollection<AmcRequestCustomerLimitedResponse> AmcList
        {
            get { return _AmcList; }
            set
            {
                _AmcList = value;
                OnPropertyChanged("AmcList");
            }
        }
    }
}
