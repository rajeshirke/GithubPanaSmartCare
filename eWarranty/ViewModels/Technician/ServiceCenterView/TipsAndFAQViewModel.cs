using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eWarranty.Controls;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Views.Technician.SupportViews;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Technician.ServiceCenterView
{
    public class TipsAndFAQViewModel : BaseViewModel
    {
        public TipsAndFAQViewModel(INavigation navigation) : base(navigation)
        {
            isfileview = true;
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
            List<string> serviceManualModels = await centersManagementSL.GetModelNumbersForRepairTips();
            if (serviceManualModels != null)
            {
                int cnt = 0;
                foreach (var item in serviceManualModels)
                {
                    cnt++;
                    modelNumberSearchResponses.Add(new DropDownModel() { Id = cnt, Title = item });
                }
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
        public Command SearchModelCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (modelNumberSearchResponses == null)
                        modelNumberSearchResponses = new List<DropDownModel>();

                    modelNumberSearchResponses = new List<DropDownModel>();
                    ServiceCentersManagementSL centersManagementSL = new ServiceCentersManagementSL();
                    List<string> serviceManualModels = await centersManagementSL.GetModelNumbersForRepairTips();
                    if (serviceManualModels != null && serviceManualModels.Count != 0)
                    {
                        int cnt = 0;
                        foreach (var item in serviceManualModels)
                        {
                            cnt++;
                            modelNumberSearchResponses.Add(new DropDownModel() { Id = cnt, Title = item });
                        }
                    }

                    if (modelNumberSearchResponses != null && modelNumberSearchResponses.Count != 0)
                    {
                        DropDownPopupPage dropDownPopup = new DropDownPopupPage();
                        dropDownPopup.Title = "Select Model Number";
                        dropDownPopup.PickerItemsSource = modelNumberSearchResponses;
                        dropDownPopup.MasterData = modelNumberSearchResponses.ToList();
                        await PopupNavigation.Instance.PushAsync(dropDownPopup);
                        dropDownPopup.DropDownSelectedItem += DropDownPopup_DropDownSelectedItem;
                    }

                });
            }
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

        public Command SearchTipsCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if(ModelNumber != string.Empty)
                    {
                        ServiceCentersManagementSL centersManagementSL = new ServiceCentersManagementSL();
                        ModelServiceManualResponse = await centersManagementSL.GetTechPortalRepairTipsByModelNumber(ModelNumber, Symptom);
                    }                    
                });
            }
        }
        private async void DropDownPopup_DropDownSelectedItem(object sender, EventArgs e)
        {
            DropDownPopupPage control = sender as DropDownPopupPage;
            ModelNumber = control.SelectedItem.Title;
            //ServiceCentersManagementSL centersManagementSL = new ServiceCentersManagementSL();
            //ModelServiceManualResponse = await centersManagementSL.GetTechPortalRepairTipsByModelNumber(ModelNumber, Symptom);
        }

        private List<TechPortalDbrepairTipsView> _ModelServiceManualResponse;
        public List<TechPortalDbrepairTipsView> ModelServiceManualResponse
        {
            get { return _ModelServiceManualResponse; }
            set
            {
                _ModelServiceManualResponse = value;
                OnPropertyChanged("ModelServiceManualResponse");
            }
        }
        private TechPortalDbrepairTipsView _SelectedModelServiceManual;
        public TechPortalDbrepairTipsView SelectedModelServiceManual
        {
            get { return _SelectedModelServiceManual; }
            set
            {

                _SelectedModelServiceManual = value;
                OnPropertyChanged("SelectedModelServiceManual");
            }
        }

        private string _Symptom;
        public string Symptom
        {
            get { return _Symptom; }
            set
            {
                _Symptom = value;
                OnPropertyChanged("Symptom");
            }
        }

        public bool isfileview { get; set; }
        public Command SelectedItemCommand
        {
            get
            {
                return new Command<TechPortalDbrepairTipsView>(async (item) =>
                {
                   
                        isfileview = false;
                        IsBusy = true;
                        SelectedModelServiceManual = item;
                    //string file64bitstring= Convert.ToBase64String(SelectedModelServiceManual.Document);
                    //await Navigation.PushAsync(new PDFScriptViewerPage(file64bitstring));
                    TechnicianManagementSL technicianManagement = new TechnicianManagementSL();

                    List<string> result = await technicianManagement.GenerateModelRepairTipsDocumentLinksByRepairTipsId(SelectedModelServiceManual.Id);
                    if (result != null && result.Count > 0)
                    {
                        string fileUrl = CommonAttribute.ImageBaseUrl + result.FirstOrDefault();
                        await Navigation.PushAsync(new PDFViewerPage(fileUrl, SelectedModelServiceManual.Category, "pdf"));

                    }
                    IsBusy = false;
                    
                });
            }
        }
    }
}
