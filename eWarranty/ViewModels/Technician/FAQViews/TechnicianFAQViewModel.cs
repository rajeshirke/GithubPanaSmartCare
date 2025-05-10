using System;
using eWarranty.Core.Enums;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using Xamarin.Forms;



namespace eWarranty.ViewModels.Technician.FAQViews
{
    public class TechnicianFAQViewModel : BaseViewModel
    {
        /*public TechnicianFAQViewModel()
        {
            Content = new Label { Text = "Hello ContentView" };
        }*/
        public TechnicianFAQViewModel(INavigation navigation) : base(navigation)
        {
            
        }

        private string _ModelNumber;
        public string ModelNumber

        {
            get { return _ModelNumber; }
            set
            {
                _ModelNumber = value;
                OnPropertyChanged("ModelNumber");
            }
        }

        private string _Query;
        public string Query

        {
            get { return _Query; }
            set
            {
                _Query = value;
                OnPropertyChanged("Query");
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
            get { return _Subject; }
            set
            {
                _Subject = value;
                OnPropertyChanged("Subject");
            }
        }

        
        public Command AddTechnicianQueryCommand
        {
            get
            {
                return new Command(async () =>
                {
                      if (string.IsNullOrEmpty(ModelNumber))
                        {
                            await ErrorDisplayAlert("Please enter Model Number.");
                            return;
                        }
                      if (string.IsNullOrEmpty(Subject))
                        {
                            await ErrorDisplayAlert("Please enter Subject.");
                            return;
                        }
                      if (string.IsNullOrEmpty(Query))
                        {
                            await ErrorDisplayAlert("Please enter Query.");
                            return;
                        }
                        IsBusy = true;
                        TechnicianManagementSL upManagementSL = new TechnicianManagementSL();
                    TechnicianQueryRequest technicianQueryrRequest = new TechnicianQueryRequest();

                    technicianQueryrRequest.TechnicianQueryId = 0;
                    technicianQueryrRequest.ModelNumber = ModelNumber;
                    technicianQueryrRequest.SerialNumber = SerialNumber;
                    technicianQueryrRequest.Subject = Subject;
                    technicianQueryrRequest.QueryContent = Query;
                    technicianQueryrRequest.CreatedByPersonId= CommonAttribute.CustomeProfile.PersonId; 
                    technicianQueryrRequest.ProductClassificationId = null;
                    technicianQueryrRequest.Status = null;

                    var receiveContext = await upManagementSL.PostTechnicianFAQ(technicianQueryrRequest);
                    if (receiveContext?.Status == Convert.ToInt16(APIResponseEnum.Success))
                    {
                        //await BindingData();
                        await DisplayAlert("Success", "Updated.");
                        ModelNumber = SerialNumber = Subject = Query = string.Empty;

                    }
                    else if (receiveContext != null)
                    {
                        await ErrorDisplayAlert(receiveContext.ErrorMessage);
                    }
                    else
                    {
                        await ErrorDisplayAlert(Resx.AppResources.lblErrorTitle);
                    }
                        
                    IsBusy = false;                       
                    

                });
            }
        }
    }
}

