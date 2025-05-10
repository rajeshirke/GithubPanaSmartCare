using System;
using System.Collections.ObjectModel;
using eWarranty.Core.ResponseModels;
using eWarranty.Hepler;
using eWarranty.Models;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.Accesssories
{
    public class AccesssoriesOderHistoryViewModel : BaseViewModel
    {
        public AccesssoriesOderHistoryViewModel(INavigation navigation) : base(navigation)
        {
            SelectedProducts = new ObservableCollection<AccessoryResponse>(CommonAttribute.SelectedAccesssories);

        }
        private ObservableCollection<AccessoryResponse> _SelectedProducts;
        public ObservableCollection<AccessoryResponse> SelectedProducts
        {
            get { return _SelectedProducts; }
            set
            {
                _SelectedProducts = value;
                OnPropertyChanged("SelectedProducts");
            }
        }
    }
}
