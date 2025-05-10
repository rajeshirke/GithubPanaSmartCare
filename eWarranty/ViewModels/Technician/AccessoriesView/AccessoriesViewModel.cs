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
using eWarranty.Models;
using eWarranty.Resx;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Technician.AccessoriesView
{
    public class AccessoriesViewModel : BaseViewModel
    {
        public AccessoriesViewModel(INavigation navigation) : base(navigation)
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
                ProductsManagementSL productsManagement = new ProductsManagementSL();

                List<ProductModelWarrantyResponse> resproductModels = await productsManagement.GetCustomerDeliveryItems();
                if (resproductModels != null && resproductModels.Count > 0)
                    MasterProductModels = new ObservableCollection<ProductModelWarrantyResponse>(resproductModels);

                //if (MasterProductModels != null && MasterProductModels.Count > 0)
                //    ProductModels = MasterProductModels;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            
        }

        public void SearchModelNumber(string skey)
        {
            if (!string.IsNullOrEmpty(skey))
            {
                if (MasterProductModels != null && MasterProductModels.Count > 0)
                {
                    var Modelnumberitems = MasterProductModels.Where(u => u.ModelNumber.ToLower().Contains(skey.ToLower()));
                    ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(Modelnumberitems);
                }

            }
            else
            {
                ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(MasterProductModels);
            } 
        }

        public Command CallServiceCentorCommand
        {
            get
            {
                return new Command<ProductModelWarrantyResponse>(async (item) =>
                {
                    if (item.ContactNumber != null)
                    {
                        Extensions.PlacePhoneCall(item.ContactNumber);
                    }
                    else
                    {
                        await ErrorDisplayAlert(AppResources.ErrorMsgMobilenumberisnotavailable);
                    }
                });
            }
        }

        public Command SearchProductCommand
        {
            get
            {
                return new Command( () =>
                {
                   
                    List<ProductModelWarrantyResponse> ProductSerach = MasterProductModels.ToList();

                    if (!string.IsNullOrEmpty(CustName))
                    {
                        if (ProductSerach != null && ProductSerach.Count > 0)
                        {
                            var SerachByCustomer = ProductSerach.Where(u => u.CustomerName !=null && Convert.ToString(u.CustomerName).ToLower().Contains(CustName.ToString().ToLower())).ToList();
                            ProductSerach = SerachByCustomer.ToList();
                            //ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(ProductSerach)
                        }
                    }
                    if (!string.IsNullOrEmpty(ModelNumber))
                    {
                        if (ProductSerach != null && ProductSerach.Count > 0)
                        {
                            ProductSerach = ProductSerach.Where(u => u.ModelNumber != null && u.ModelNumber.ToLower().Contains(ModelNumber.ToLower())).ToList();
                            //ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(Modelnumberitems);
                        }
                    }
                    if (!string.IsNullOrEmpty(SerialNumber))
                    {
                        if (ProductSerach != null && ProductSerach.Count > 0)
                        {
                            ProductSerach = ProductSerach.Where(u => u.SerialNumber != null && u.SerialNumber.ToLower().Contains(SerialNumber.ToLower())).ToList();
                            //ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(Modelnumberitems);
                        }
                    }

                    ProductModels = new ObservableCollection<ProductModelWarrantyResponse>(ProductSerach);

                    if ((CustName == string.Empty || CustName == null) && (ModelNumber == string.Empty || ModelNumber == null) && (SerialNumber == string.Empty || SerialNumber == null))
                    {
                        ProductModels = new ObservableCollection<ProductModelWarrantyResponse>();
                    }

                });
            }
        }

        #region events
        //AddProductPage
        public ICommand AddProductCommand { get; set; }

        #endregion
        #region Properties

        public string _CustName;
        public string CustName
        {
            get { return _CustName; }
            set
            {
                _CustName = value;
                OnPropertyChanged(nameof(CustName));
            }
        }

        public string _ModelNumber;
        public string ModelNumber
        {
            get { return _ModelNumber; }
            set
            {
                _ModelNumber = value;
                OnPropertyChanged(nameof(ModelNumber));
            }
        }

        public string _SerialNumber;
        public string SerialNumber
        {
            get { return _SerialNumber; }
            set
            {
                _SerialNumber = value;
                OnPropertyChanged(nameof(SerialNumber));
            }
        }

        private ObservableCollection<ProductModelWarrantyResponse> _MasterProductModels;
        public ObservableCollection<ProductModelWarrantyResponse> MasterProductModels
        {
            get { return _MasterProductModels; }
            set
            {
                _MasterProductModels = value;
                OnPropertyChanged("MasterProductModels");
            }
        }

        private ObservableCollection<ProductModelWarrantyResponse> _ProductModels;
        public ObservableCollection<ProductModelWarrantyResponse> ProductModels
        {
            get { return _ProductModels; }
            set
            {
                _ProductModels = value;
                OnPropertyChanged("ProductModels");
            }
        }

        //private List<ProductModel> _ProductModels;
        //public List<ProductModel> ProductModels
        //{
        //    get { return _ProductModels; }
        //    set
        //    {
        //        _ProductModels = value;
        //        OnPropertyChanged("ProductModels");
        //    }
        //}
        #endregion
    }
}
