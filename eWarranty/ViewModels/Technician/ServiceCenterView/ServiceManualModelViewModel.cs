using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eWarranty.Controls;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.Views.Technician.SupportViews;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Technician.ServiceCenterView
{
    public class ServiceManualModelViewModel :  BaseViewModel
    {
        public ServiceManualModelViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () => {
                await BindingData();
                IsBusy = false;
            });
        }
        public async Task BindingData()
        {
            if (modelNumberSearchResponses == null)
                modelNumberSearchResponses = new List<DropDownModel>();

            ServiceCentersManagementSL centersManagementSL = new ServiceCentersManagementSL();
            List<ServiceManualModelResponse> serviceManualModels= await centersManagementSL.GetAllModels();
            if(serviceManualModels != null)
            {
                foreach (var item in serviceManualModels)
                {
                    modelNumberSearchResponses.Add(new DropDownModel() { Id=Convert.ToInt32(item.ModelServiceManualId), Title=item.ModelNumber });
                }
            }
        }
        public Command SearchModelCommand
        {
            get
            {
                return new Command(async () =>
                {
                    //DropDownPopupPage dropDownPopup = new DropDownPopupPage();
                    //dropDownPopup.Title = "Select Model Number";
                    //if (SelectedModelNumber != null)
                    //    dropDownPopup.Title = SelectedModelNumber.Title;


                    ////dropDownPopup.DropDownSelectedItem -= DropDownPopup_DropDownSelectedItem; ;
                    //dropDownPopup.DropDownSelectedItem += DropDownPopup_DropDownSelectedItem; 
                    //await BindingData();
                    //dropDownPopup.PickerItemsSource = modelNumberSearchResponses;
                    //dropDownPopup.MasterData = modelNumberSearchResponses;
                    //await PopupNavigation.PushAsync(dropDownPopup);

                    ////SelectCountry = item;
                    ////  Navigation.PushAsync(new ProductSuccessPage());
                    ///

                    //if (modelNumberSearchResponses == null)
                    //    modelNumberSearchResponses = new List<DropDownModel>();

                    modelNumberSearchResponses = new List<DropDownModel>();
                    ServiceCentersManagementSL centersManagementSL = new ServiceCentersManagementSL();
                    List<ServiceManualModelResponse> serviceManualModels = await centersManagementSL.GetAllModels();
                    if (serviceManualModels != null)
                    {
                        foreach (var item in serviceManualModels)
                        {
                            modelNumberSearchResponses.Add(new DropDownModel() { Id = Convert.ToInt32(item.ModelServiceManualId), Title = item.ModelNumber });
                        }
                    }

                    //if (modelNumberSearchResponses != null && modelNumberSearchResponses.Count != 0)
                    //{
                    //    DropDownPopupPage dropDownPopup = new DropDownPopupPage();
                    //    dropDownPopup.Title = "Select Model Number";
                    //    dropDownPopup.PickerItemsSource = modelNumberSearchResponses;
                    //    dropDownPopup.MasterData = modelNumberSearchResponses.ToList();
                    //    await PopupNavigation.Instance.PushAsync(dropDownPopup);
                    //    dropDownPopup.DropDownSelectedItem += DropDownPopup_DropDownSelectedItem;
                    //}

                    IsBusy = true;
                    if(modelNumberSearchResponses != null && modelNumberSearchResponses.Count != 0)
                    {
                        DropDownPopupPage dropDownPopup = new DropDownPopupPage();
                        dropDownPopup.Title = "Select Service Model Number";
                        dropDownPopup.PickerItemsSource = modelNumberSearchResponses;
                        dropDownPopup.MasterData = modelNumberSearchResponses;
                        if (!string.IsNullOrEmpty(ModelNumber))
                        {
                            dropDownPopup.SetSearchKey(ModelNumber);
                            await dropDownPopup.GetServiceManual(ModelNumber);
                            //modelNumberSearchResponses=new List<DropDownModel>( modelNumberSearchResponses.Where(m => m.Title.ToLower().Contains(ModelNumber.ToLower())).ToList());
                            //dropDownPopup.PickerItemsSource = modelNumberSearchResponses;
                            //dropDownPopup.MasterData = modelNumberSearchResponses;
                        }                       
                        dropDownPopup.DropDownSelectedItem += DropDownPopup_DropDownSelectedItem; ;
                        IsBusy = false;
                        await PopupNavigation.PushAsync(dropDownPopup);
                    }
                   

                });
            }
        }

        private async void DropDownPopup_DropDownSelectedItem(object sender, EventArgs e)
        {
            DropDownPopupPage control = sender as DropDownPopupPage;
            ModelNumber = control.SelectedItem.Title;
            ServiceCentersManagementSL centersManagementSL = new ServiceCentersManagementSL();

            ModelServiceManualResponse = await centersManagementSL.GetServiceManualsByModelNumber(ModelNumber);
            
        }

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

        private List<DropDownModel> _modelNumberSearchResponses;
        public List<DropDownModel> modelNumberSearchResponses
        {
            get { return _modelNumberSearchResponses; }
            set
            {
                _modelNumberSearchResponses = value;
                OnPropertyChanged("modelNumberSearchResponses");
            }
        }
        private List<ModelServiceManualResponse> _ModelServiceManualResponse;
        public List<ModelServiceManualResponse> ModelServiceManualResponse
        {
            get { return _ModelServiceManualResponse; }
            set
            {
                _ModelServiceManualResponse = value;
                OnPropertyChanged("ModelServiceManualResponse");
            }
        }
        private ModelServiceManualResponse _SelectedModelServiceManual;
        public ModelServiceManualResponse SelectedModelServiceManual
        {
            get { return _SelectedModelServiceManual; }
            set
            {

                _SelectedModelServiceManual = value;
                OnPropertyChanged("SelectedModelServiceManual");
            }
        }
        public bool isfileview { get; set; }
        public Command SelectedItemCommand
        {
            get
            {
                return new Command<ModelServiceManualResponse>(async (item) =>
                {
                    if (isfileview)
                    {
                        isfileview = false;
                        IsBusy = true;
                        SelectedModelServiceManual = item;
                        string fileUrl = CommonAttribute.ImageBaseUrl + SelectedModelServiceManual.Path;
                        await Navigation.PushAsync(new PDFViewerPage(fileUrl, SelectedModelServiceManual.ServiceManualNumber, SelectedModelServiceManual.MimeType));
                        IsBusy = false;
                    }
                });
            }
        }
        private DropDownModel _SelectedModelNumber;
        public DropDownModel SelectedModelNumber
        {
            get { return _SelectedModelNumber; }
            set
            {

                _SelectedModelNumber = value;
                OnPropertyChanged("SelectedModelNumber");
            }
        }
    }
}
