using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Views.Customer.InquiryView;
using eWarranty.Views.Customer.Products;
using eWarranty.Views.Customer.SRDetails;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.SRDetails
{
    public class ServicesViewModel : BaseViewModel
    {
        public ServicesViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;
            BindingData();
        }
        #region Method
        public async Task BindingData()
        {
            try
            {
                AddProductCommand = new Command(() =>
                {
                    Navigation.PushAsync(new SelectProductsPage("Product"));
                });
                ProductDetailsCommand = new Command<long>((item) =>
                {
                    Navigation.PushAsync(new SREditDetailsPage(item, 2));
                    MessagingCenter.Send<ServicesViewModel, string>(this, "tab", "Product Deatils");
                });

                ServiceDetailsCommand = new Command<long>((item) =>
                {

                    Navigation.PushAsync(new SREditDetailsPage(item, 1));
                    MessagingCenter.Send<ServicesViewModel, string>(this, "tab", "SR Details");

                });
                followupCommand = new Command<long>((item) =>
                {
                    SREditDetailsPage view = new SREditDetailsPage(item, 2);
                    MessagingCenter.Send<ServicesViewModel, string>(this, "tab", "followup");
                    Navigation.PushAsync(view);


                });

                if (Services == null)
                    Services = new ObservableCollection<ServiceRequestResponce>();

                await GetServiceRequest(1);
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
        }
        public async Task GetServiceRequest(int sid)
        {
            ServiceRequestSL serviceRequestSL = new ServiceRequestSL();
            MasterData = await serviceRequestSL.GetCustomerServiceRequests(CommonAttribute.CustomeProfile.PersonId);
            if (MasterData != null && MasterData.Count > 0)
            {
                FilteData(1);
            }

        }
        public void FilteData(int sid)
        {
            //int enumsid = Convert.ToInt16(ServiceRequestStatusEnum.JobClosed);
            //if(sid == 1)
            //    Services = new ObservableCollection<ServiceRequestResponce>(MasterData.Where(s => s.StatusId != enumsid).OrderByDescending(u => u.CreationDate));
            //else
            //    Services = new ObservableCollection<ServiceRequestResponce>(MasterData.Where(s => s.StatusId == enumsid).OrderByDescending(u => u.CreationDate));

            Services = new ObservableCollection<ServiceRequestResponce>(MasterData.OrderByDescending(u=>u.CreationDate));
        }
        #endregion
        #region events
        public ICommand AddProductCommand { get; set; }
        public ICommand ProductDetailsCommand { get; set; }
        public ICommand ServiceDetailsCommand { get; set; }
        public ICommand followupCommand { get; set; }
        public Command FeedbackCommand
        {
            get
            {
                return new Command<ServiceRequestResponce>(async (item) =>
                {
                    IsBusy = true;
                   await Navigation.PushAsync(new FeedBackPage(item.ServiceRequestId,item.TypeId));
                });
            }
        }
        #endregion
        #region Properties
        public List<ServiceRequestResponce> MasterData { get; set; }
        private ObservableCollection<ServiceRequestResponce> _Services;
        public ObservableCollection<ServiceRequestResponce> Services
        {
            get { return _Services; }
            set
            {
                _Services = value;
                OnPropertyChanged("Services");
            }
        }
        #endregion
    }

}
