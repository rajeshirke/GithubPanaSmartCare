using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using eWarranty.Core.Models;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Technician.SparePartsView
{
    public class TechnicianSparePartListViewModel : BaseViewModel
    {
        public TechnicianSparePartListViewModel(INavigation navigation ):base(navigation)
        {
            IsBusy = true;
            
            Device.BeginInvokeOnMainThread(async () =>
            {
                await BindingData();               
                IsBusy = false;
            });
        }

        public async Task BindingData()
        {
            try
            {
                TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
                var lstpartRequestViews = await technicianManagementSL.GetPartRequestsByTechnician((int)CommonAttribute.CustomeProfile?.PersonId);
                if (lstpartRequestViews != null && lstpartRequestViews.Count > 0)
                {
                    var TechSparePartLists = lstpartRequestViews.OrderByDescending(s => s.PartRequestId).ToList();
                    obPartRequestView = new ObservableCollection<PartRequestView>((IEnumerable<PartRequestView>)TechSparePartLists);
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            
        }

        private ObservableCollection<PartRequestView> _obPartRequestView;
        public ObservableCollection<PartRequestView> obPartRequestView
        {
            get { return _obPartRequestView; }
            set
            {
                _obPartRequestView = value;
                OnPropertyChanged(nameof(obPartRequestView));
            }
        }
    }
}

