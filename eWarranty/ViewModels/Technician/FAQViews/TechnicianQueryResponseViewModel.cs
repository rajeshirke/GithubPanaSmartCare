using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using eWarranty.Controls;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Technician.FAQViews
{
    public class TechnicianQueryResponseViewModel : BaseViewModel
    {
        public TechnicianQueryResponseViewModel(INavigation navigation) : base(navigation)
        {
            //IsBusy = true;
            //GetTechnicianQueries();
            
        }
        
        public Command TechnicianQueryResponseCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await GetTechnicianQueries();
                    
                });
            }
        }

        public async Task GetTechnicianQueries()
        {
            if (string.IsNullOrEmpty(ModelNumber))
            {
                await ErrorDisplayAlert("Please enter Model Number.");
                IsBusy = false;
                return;
            }
            
            TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
            List<TechnicianQueryResponse> technicianQueries = await technicianManagementSL.GetTechnicianQueries(ModelNumber, SearchText);

            TechnicianQueryResponse = new ObservableCollection<TechnicianQueryResponse>(technicianQueries);

            if (TechnicianQueryResponse.Count == 0)
            {
                await ErrorDisplayAlert("No data found.");
                IsBusy = false;
                return;
            }

            IsBusy = false;
        }

        public Command ModelsPopupCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    DropDownPopupPage dropDownPopup = new DropDownPopupPage();
                    dropDownPopup.Title = "Model Number";

                    if (!string.IsNullOrEmpty(ModelNumber))
                    {
                        dropDownPopup.SetSearchKey(ModelNumber);
                        await dropDownPopup.GetModelNumber(ModelNumber);
                    }
                    //else
                    //    await dropDownPopup.GetModelNumber("a");
                    dropDownPopup.DropDownSelectedItem += DropDownPopup_DropDownSelectedItem; ; ;
                    IsBusy = false;
                    await PopupNavigation.Instance.PushAsync(dropDownPopup);

                });
            }
        }
       
        private void DropDownPopup_DropDownSelectedItem(object sender, System.EventArgs e)
        {
            DropDownPopupPage control = sender as DropDownPopupPage;
            ModelNumber = control.SelectedItem.Title.ToUpper();
            //  ModelNumberValide=true
            ModelNumberValide = true;
            modelNumberSearchResponse = new Core.ResponseModels.ModelNumberSearchResponse() { ProductClassificationId = control.SelectedItem.Id, ModelName = control.SelectedItem.Title, ModelDescreption = control.SelectedItem.Desc };

        }

        public ModelNumberSearchResponse modelNumberSearchResponse { get; set; }
        // public bool ModelNumberValide { get; set; }
        //List<ModelNumberSearchResponse> responses
        private List<ModelNumberSearchResponse> _modelNumberSearchResponses;
        public List<ModelNumberSearchResponse> modelNumberSearchResponses
        {
            get { return _modelNumberSearchResponses; }
            set
            {
                _modelNumberSearchResponses = value;
                OnPropertyChanged("modelNumberSearchResponses");
            }
        }
        private bool _ModelNumberValide;
        public bool ModelNumberValide
        {
            get { return _ModelNumberValide; }
            set
            {

                _ModelNumberValide = value;
                OnPropertyChanged("ModelNumberValide");
            }
        }

        private string _ModelNumber;
        public string ModelNumber

        {
            get { return _ModelNumber; }
            set
            {
                ModelNumberValide = true;
                _ModelNumber = value;
                OnPropertyChanged("ModelNumber");
            }
        }

        private string _SearchText;
        public string SearchText

        {
            get { return _SearchText; }
            set
            {
                _SearchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        private string _SerialNumber;
        public string SerialNumber

        {
            get { return _SerialNumber; }
            set
            {
                _SerialNumber = value;
                OnPropertyChanged("SerialNumber");
            }
        }

        private string _Subject;
        public string Subject

        {
            get { return _Subject.Trim(); }
            set
            {
                _Subject = value;
                OnPropertyChanged("Subject");
            }
        }

        private string _QueryContent;
        public string QueryContent

        {
            get { return _QueryContent; }
            set
            {
                _QueryContent = value;
                OnPropertyChanged("QueryContent");
            }
        }

        private string _QuerySolutionContent;
        public string QuerySolutionContent

        {
            get { return _QuerySolutionContent; }
            set
            {
                _QuerySolutionContent = value;
                OnPropertyChanged("QuerySolutionContent");
            }
        }

        #region
        private ObservableCollection<TechnicianQueryResponse> _TechnicianQueryResponse;
        public ObservableCollection<TechnicianQueryResponse> TechnicianQueryResponse
        {
            get { return _TechnicianQueryResponse; }
            set
            {
                _TechnicianQueryResponse = value;
                OnPropertyChanged("TechnicianQueryResponse");
            }
        }
        #endregion
    }
}

