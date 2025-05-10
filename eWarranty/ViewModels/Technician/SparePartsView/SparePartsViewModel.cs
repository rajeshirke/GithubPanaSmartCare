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
using eWarranty.Views.Technician.SparePartsViews;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace eWarranty.ViewModels.Technician.SparePartsView
{
    public class SparePartsViewModel : BaseViewModel
    {
        public string SparePartModelNo { get; set; }
        public int FlagSwipeRight { get; set; }

        public SparePartsViewModel(INavigation navigation, int Flag) : base(navigation)
        {
            IsBusy = true;
            FlagSwipeRight = Flag;
            Device.BeginInvokeOnMainThread(async () => {
                await BindingData();
                if (CommonAttribute.TechEditServiceRequest != null)
                {
                    ServiceRequestDetailsResponse serviceRequestDetailsResponse = CommonAttribute.TechEditServiceRequest;
                    if (serviceRequestDetailsResponse != null)
                        SparePartModelNo = serviceRequestDetailsResponse.ProductModel?.ModelNumber;
                }
                
                IsBusy = false;
            });
        }

        public Command SearchSparePartsCommand
        {
            get
            {
                return new Command<string>(async (item) =>
                {
                    try
                    {
                        SpareParts = new ObservableCollection<PartStockMaster>
                        (SpareParts.Where(x => x.PartNumber.ToLower().Contains(item.ToString().ToLower())).ToList());
                        IsBusy = false;
                    }
                    catch (Exception ex)
                    {

                    }
                    
                });
            }
        }

        public SparePartsViewModel(INavigation navigation,PartStockMaster partStockMaster) : base(navigation)
        {
            PartsStockMaster = new PartStockMaster();
            PartsStockMaster = partStockMaster;
        }
        public async Task BindingData()
        {
            try
            {
                await GetTechnicianStock();
                if (SpareParts == null)
                    SpareParts = new ObservableCollection<PartStockMaster>();

                SpareParts.ForEach(x => x.CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse.CurrencyCode);

            }
            catch (Exception ex)
            {

            }

          
        }
        //AddNewCommand  HandOverPartsPage
        public Command AddNewCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new AddSparePartPage());
                });
            }
        }
        public Command SelectedCommand
        {
            get
            {
                return new Command<PartStockMaster>((obj) =>
                {
                    Navigation.PushAsync(new HandOverPartsPage());
                });
            }
        }
        public Command AddPartCommand
        {
            get
            {
                return new Command<PartStockMaster>(async (obj) =>
                {
                    //MessagingCenter.Send<SparePartsViewModel, PartStockMaster>(this, "selectpart", obj);
                    //Navigation.PopAsync();

                    await PopupNavigation.Instance.PushAsync(new AddPartsQuantityPopupPage(obj));

                });
            }
        }
        public Command AddPartQtyCommand
        {
            get
            {
                return new Command(async() =>
                {
                    try
                    {
                        IsBusy = true;
                        if (PartsStockMaster != null)
                        {
                            int availQTY = PartsStockMaster.Quantity;
                            if (Convert.ToInt32(PartQty) > availQTY)
                            {
                                await ErrorDisplayAlert("Quantity should be less than the available quantity.");
                            }
                            else
                            {
                                PartsStockMaster.Quantity = Convert.ToInt32(PartQty);
                                PartsStockMaster.TotalAmount = PartsStockMaster.Cost * Convert.ToInt32(PartQty);
                                MessagingCenter.Send<SparePartsViewModel, PartStockMaster>(this, "selectpart", PartsStockMaster);
                                await Navigation.PopAsync();
                                await PopupNavigation.Instance.PopAsync();
                            }
                        }
                        IsBusy = false;
                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                                       
                });
            }
        }


        public Command ReturnPartCommand
        {
            get
            {
                return new Command<PartStockMaster>(async (item) =>
                {
                    IsBusy = true;
                        await PopupNavigation.Instance.PushAsync(new ReturnPartPopupView(item));
                    IsBusy = false;
                });
            }
        }

        public Command SCTabSelectedCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        IsBusy = true;
                        await GetServiceCenterStock();
                        if (SpareParts != null && SpareParts.Count > 0)
                        {
                            if (CommonAttribute.CustomeProfile?.CountryResponse?.CurrencyCode != null)
                                SpareParts.ForEach(x => x.CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse.CurrencyCode);
                        }


                        IsBusy = false;
                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                    
                });
            }
        }
        public Command TechTabSelectedCommand
        {
            get
            {
                return new Command(async() =>
                {
                    IsBusy = true;
                    await GetTechnicianStock();
                    if (SpareParts != null && SpareParts.Count > 0)
                    {
                        if (CommonAttribute.CustomeProfile?.CountryResponse?.CurrencyCode != null)
                            SpareParts.ForEach(x => x.CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse.CurrencyCode);
                    }
                    IsBusy = false;
                });
            }
        }
        public async Task GetTechnicianStock()
        {
            try
            {
                IsBusy = true;
                //pass model no here
                if (CommonAttribute.TechEditServiceRequest != null)
                {
                    ServiceRequestDetailsResponse serviceRequestDetailsResponse = CommonAttribute.TechEditServiceRequest;
                    SparePartModelNo = serviceRequestDetailsResponse.ProductModel?.ModelNumber;
                }
                TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
                List<PartStockMaster> partStockMasters = new List<PartStockMaster>();
                if (FlagSwipeRight != 2) //(string.IsNullOrEmpty(SparePartModelNo) && FlagSwipeRight == 1)
                {
                    partStockMasters = await technicianManagementSL.GetTechnicianStock(CommonAttribute.CustomeProfile.PersonId);
                    if (partStockMasters != null && partStockMasters.Count > 0)
                    {
                        SpareParts = null;
                        SpareParts = new ObservableCollection<PartStockMaster>(partStockMasters);
                        if (FlagSwipeRight == 1)
                        {
                            SpareParts.ForEach(s => s.IsVisibleSwipeRight = false);
                            IsAddPartLabelVisible = false;
                        }
                        else
                        {
                            SpareParts.ForEach(s => s.IsVisibleSwipeRight = true);
                            IsAddPartLabelVisible = true;
                        }
                    }

                }
                else
                {
                    partStockMasters = await technicianManagementSL.GetTechnicianStockWithModelNumber(CommonAttribute.CustomeProfile.PersonId, SparePartModelNo);
                    if (partStockMasters != null && partStockMasters.Count > 0)
                    {
                        SpareParts = null;
                        SpareParts = new ObservableCollection<PartStockMaster>(partStockMasters);
                        if (FlagSwipeRight == 1)
                        {
                            SpareParts.ForEach(s => s.IsVisibleSwipeRight = false);
                            IsAddPartLabelVisible = false;
                        }
                        else
                        {
                            SpareParts.ForEach(s => s.IsVisibleSwipeRight = true);
                            IsAddPartLabelVisible = true;
                        }
                    }

                }
                if (SpareParts != null && SpareParts.Count > 0)
                    SpareParts.ForEach(x => x.IsReturnPartVisible = true);
                //if (partStockMasters != null && partStockMasters.Count != 0)
                //    IsAddPartLabelVisible = true;
                //else
                //    IsAddPartLabelVisible = false;
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

        public async Task GetServiceCenterStock()
        {
            try
            {
                IsBusy = true;
                if (CommonAttribute.TechEditServiceRequest != null)
                {
                    ServiceRequestDetailsResponse serviceRequestDetailsResponse = CommonAttribute.TechEditServiceRequest;
                    if (serviceRequestDetailsResponse != null)
                        SparePartModelNo = serviceRequestDetailsResponse.ProductModel?.ModelNumber;
                }
                TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
                List<PersonServiceCenterResponse> sc = CommonAttribute.CustomeProfile.PersonServiceCenters.ToList();
                List<PartStockMaster> partStockMasters = new List<PartStockMaster>();
                if (sc != null && sc.Count != 0)
                {
                    //pass model no here
                    if (FlagSwipeRight != 2) //(string.IsNullOrEmpty(SparePartModelNo) && FlagSwipeRight == 1)
                    {
                        SpareParts = null;
                        partStockMasters = await technicianManagementSL.GetServiceCenterStock(sc[0].ServiceCenterId);
                        if (partStockMasters != null && partStockMasters.Count > 0)
                        {
                            SpareParts = new ObservableCollection<PartStockMaster>(partStockMasters);
                            if (FlagSwipeRight == 1)
                            {
                                SpareParts.ForEach(s => s.IsVisibleSwipeRight = false);
                                IsAddPartLabelVisible = false;
                            }
                            else
                            {
                                SpareParts.ForEach(s => s.IsVisibleSwipeRight = true);
                                IsAddPartLabelVisible = true;
                            }
                        }

                    }
                    else
                    {
                        SpareParts = null;
                        partStockMasters = await technicianManagementSL.GetServiceCenterStockWithModelNumber(sc[0].ServiceCenterId, SparePartModelNo);
                        if (partStockMasters != null && partStockMasters.Count > 0)
                        {
                            SpareParts = new ObservableCollection<PartStockMaster>(partStockMasters);
                            if (FlagSwipeRight == 1)
                            {
                                SpareParts.ForEach(s => s.IsVisibleSwipeRight = false);
                                IsAddPartLabelVisible = false;
                            }
                            else
                            {
                                SpareParts.ForEach(s => s.IsVisibleSwipeRight = true);
                                IsAddPartLabelVisible = true;
                            }
                        }

                    }

                    if (SpareParts != null && SpareParts.Count > 0)
                        SpareParts.ForEach(x => x.IsReturnPartVisible = false);
                }
                //if (partStockMasters != null && partStockMasters.Count != 0)
                //    IsAddPartLabelVisible = true;
                //else
                //    IsAddPartLabelVisible = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            finally
            {
                IsBusy = true;
            }
            
        }

        #region properties
        //ObservableCollection
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

        private PartStockMaster _PartStockMaster;
        public PartStockMaster PartsStockMaster
        {
            get { return _PartStockMaster; }
            set
            {
                _PartStockMaster = value;
                OnPropertyChanged("PartsStockMaster");
            }
        }

        private bool _IsAddPartLabelVisible;
        public bool IsAddPartLabelVisible
        {
            get { return _IsAddPartLabelVisible; }
            set
            {
                _IsAddPartLabelVisible = value;
                OnPropertyChanged("IsAddPartLabelVisible");
            }
        }

        private string _PartQty;
        public string PartQty
        {
            get { return _PartQty; }
            set
            {
                _PartQty = value;
                OnPropertyChanged("PartQty");
            }
        }
        #endregion
    }
}
