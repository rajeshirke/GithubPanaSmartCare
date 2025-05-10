using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using eWarranty.Controls;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.Views.Customer.InquiryView;
using eWarranty.Views.Technician.SparePartsViews;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Technician.SparePartsView
{
    public class AddSparePartViewModel : BaseViewModel
    {
        

        public AddSparePartViewModel(INavigation navigation) : base(navigation)
        {
            try
            {
                if (SpareParts == null)
                    SpareParts = new PartRequest();
                if (CommonAttribute.TechEditServiceRequest != null)
                {
                    ServiceRequestDetailsResponse serviceRequestDetailsResponse = CommonAttribute.TechEditServiceRequest;
                    if (serviceRequestDetailsResponse != null)
                    {
                        SparePartModelNo = serviceRequestDetailsResponse.ProductModel?.ModelNumber;
                        if (SparePartModelNo != null && SparePartModelNo != string.Empty && SparePartModelNo != "")
                            ModelNumber = SparePartModelNo;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            
            
        }
        //PartRequest
        
        private PartRequest _SpareParts;
        public PartRequest SpareParts
        {
            get { return _SpareParts; }
            set
            {
                _SpareParts = value;
                OnPropertyChanged("SpareParts");
            }
        }

        public Command PartRequestSaveCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        IsBusy = true;

                        if (await Validation())
                        {
                            TechnicianManagementSL managementSL = new TechnicianManagementSL();
                            if (CommonAttribute.SelectedServiceRequest != null)
                            {
                                SpareParts.ServiceRequestId = CommonAttribute.SelectedServiceRequest.ServiceRequestId;
                                SpareParts.PartRequestTypeId = Convert.ToInt16(PartRequestTypeEnum.PartUsageForService);

                            }
                            else
                            {
                                //SpareParts.ServiceRequestId = (int)PartRequestTypeEnum.TechnicianStockRequest;
                                SpareParts.PartRequestTypeId = Convert.ToInt16(PartRequestTypeEnum.StockRequest);

                            }

                            SpareParts.ServiceCenterId = CommonAttribute.CustomeProfile.PersonServiceCenters.FirstOrDefault().ServiceCenterId;

                            SpareParts.RequestDate = DateTime.Now;
                            SpareParts.RequestedByTechnicianId = CommonAttribute.CustomeProfile.PersonId;
                            SpareParts.PartRequestStatusId = Convert.ToInt16(PartRequestStatusEnum.Open);
                            SpareParts.PartNumber = SelectedPartNumber;
                            SpareParts.UpdatedByPersonId = CommonAttribute.CustomeProfile?.PersonId;
                            //SpareParts.UpdatedDate = DateTime.Now;
                            //SpareParts.UpdatedByPersonId = CommonAttribute.CustomeProfile.PersonId;
                            //SpareParts.PartNumber=

                            //RequestDate

                            //RequestedPartQuantity
                            // PartRequestTypeId
                            //PartRequestStatusId
                            //  TechnicianRemark
                            //UpdatedByPersonId
                            //ServiceCostEstimationId

                            var receiveContext = await managementSL.AddPartRequests(SpareParts);
                            if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
                            {
                                //await DisplayAlert(AppResources.lblSuccess, receiveContext.message);
                                await Navigation.PushAsync(new FeedBackSuccessPage("SparePart"));
                            }
                            else if (receiveContext != null)
                            {
                                await ErrorDisplayAlert(receiveContext.errorMessage);
                            }
                            else
                            {
                                await ErrorDisplayAlert(Resx.AppResources.lblErrorTitle);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                    finally
                    {
                        IsBusy = false;
                    }
                    

                });
            }
        }

        public async Task<bool> Validation()
        {
            if (string.IsNullOrEmpty(SelectedPartNumber))
            {
                await ErrorDisplayAlert("Please enter part number.");
                return false;
            }
            if (SpareParts.RequestedPartQuantity == 0)
            {
                await ErrorDisplayAlert("Please enter quantity.");
                return false;
            }
            if (string.IsNullOrEmpty(SpareParts.TechnicianRemark))
            {
                await ErrorDisplayAlert("Please enter remark.");
                return false;
            }
            return true;
        }

        public async Task ValidatePartNumber()
        {
            try
            {
                SearchPartNumbers = new ObservableCollection<DropDownModel>();

                if (ModelNumber != null && ModelNumber != string.Empty)
                {
                    TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
                    List<string> PartNumbers = await technicianManagementSL.GetPrismPartsByModelNumber(ModelNumber);

                    if (PartNumbers != null && PartNumbers.Count != 0)
                    {
                        foreach (var item in PartNumbers)
                        {
                            SearchPartNumbers.Add(new DropDownModel { Title = item.ToString() });
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            

        }

        public Command PartNoPopupCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        SearchPartNumbers = new ObservableCollection<DropDownModel>();
                        if (SearchPartNumbers == null)
                            SearchPartNumbers = new ObservableCollection<DropDownModel>();

                        IsBusy = true;
                        if (ModelNumber != null && ModelNumber != string.Empty && ModelNumber.Length > 3)
                        {
                            TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
                            List<string> PartNumbers = await technicianManagementSL.GetPrismPartsByModelNumber(ModelNumber);

                            if (PartNumbers.Count != 0 && PartNumbers != null)
                            {
                                foreach (var item in PartNumbers)
                                {
                                    if (SearchPartNumbers.Any(p => p.Title.ToLower().ToString() == item.ToLower().ToString()))
                                    {
                                        SearchPartNumbers.Remove(new DropDownModel { Title = item.ToString() });
                                    }
                                    else
                                    {
                                        SearchPartNumbers.Add(new DropDownModel { Title = item.ToString() });
                                    }
                                    
                                }
                            }

                            SearchPartNumbers.OrderBy(p => p.Id).Distinct().GroupBy(p => p.Id);
                            if (PartNumbers.Count != 0 && PartNumbers != null)
                            {
                                DropDownPopupPage dropDownPopup = new DropDownPopupPage();
                                dropDownPopup.Title = "Part Number";
                                dropDownPopup.PickerItemsSource = SearchPartNumbers;
                                dropDownPopup.MasterData = SearchPartNumbers.ToList();
                                await PopupNavigation.Instance.PushAsync(dropDownPopup);
                                dropDownPopup.DropDownSelectedItem += DropDownPopup_DropDownSelectedItem;
                            }
                            else
                            {
                                await ErrorDisplayAlert("No parts available for this model number.");
                            }
                            IsBusy = false;
                        }
                        else
                        {
                            await DisplayAlert("Alert!", "Please enter atleast 4 characters to search.");
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                    }
                    finally
                    {
                        IsBusy = false;
                    }
                   
                });
            }
        }

        private void DropDownPopup_DropDownSelectedItem(object sender, EventArgs e)
        {
            try
            {
                DropDownPopupPage control = sender as DropDownPopupPage;
                SelectedPartNumber = control.SelectedItem.Title.ToUpper();

                modelNumberSearchResponse = new ModelNumberSearchResponse()
                {
                    ProductClassificationId = control.SelectedItem.Id,
                    ModelName = control.SelectedItem.Title,
                    ModelDescreption = control.SelectedItem.Desc
                };
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }

        }

        public ModelNumberSearchResponse modelNumberSearchResponse { get; set; }

        private ObservableCollection<DropDownModel> _SearchPartNumbers;
        public ObservableCollection<DropDownModel> SearchPartNumbers
        {
            get { return _SearchPartNumbers; }
            set
            {
                _SearchPartNumbers = value;
                OnPropertyChanged(nameof(SearchPartNumbers));
            }
        }

        private string _PartNumber;
        public string PartNumber
        {
            get { return _PartNumber; }
            set
            {
                _PartNumber = value;
                OnPropertyChanged(nameof(PartNumber));
            }
        }

        private string _SelectedPartNumber;
        public string SelectedPartNumber
        {
            get { return _SelectedPartNumber; }
            set
            {
                _SelectedPartNumber = value;
                OnPropertyChanged(nameof(SelectedPartNumber));
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

        

        private string _SparePartModelNo;
        public string SparePartModelNo
        {
            get { return _SparePartModelNo; }
            set
            {
                _SparePartModelNo = value;
                OnPropertyChanged(nameof(SparePartModelNo));
            }
        }
    }
}
