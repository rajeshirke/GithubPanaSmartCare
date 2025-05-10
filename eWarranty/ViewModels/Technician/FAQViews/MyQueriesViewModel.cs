using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Views.Technician.FAQViews;

using Xamarin.Forms;

namespace eWarranty.ViewModels.Technician.FAQViews
{
    public class MyQueriesViewModel : BaseViewModel
    {
        public MyQueriesViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;
            DataBinding();
            
        }
        public async Task DataBinding()
        {
            
            await TechnicianQueriesWithSolutions();
           
            IsBusy = false;
        }
        public async Task TechnicianQueriesWithSolutions()
        {
            TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
            
            List<TechnicianQueryResponse> technicianQueries = await technicianManagementSL.GetTechnicianQueriesWithSolutions(CommonAttribute.CustomeProfile.PersonId);

            TechnicianQueriesWithSolution = new ObservableCollection<TechnicianQueryResponse>(technicianQueries);

            
            if (TechnicianQueriesWithSolution.Count == 0)
            {
                await ErrorDisplayAlert("No data found.");
                IsBusy = false;
                return;
            }

            IsBusy = false;
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

        public Command AddNewQuery
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new FAQ());
                });
            }
        }

        private string _QuerySolutionContent= "Waiting for the solution";
        public string QuerySolutionContent
        {
            get {
                //if (!string.IsNullOrEmpty(_QuerySolutionContent))
                //    return _QuerySolutionContent = "Waiting for the soution";
                //else
                return string.IsNullOrEmpty(_QuerySolutionContent) ? "Waiting for the solution" : _QuerySolutionContent;

                //return _QuerySolutionContent;
            }
            set
            {
                
                    _QuerySolutionContent = value;
                OnPropertyChanged("QuerySolutionContent");
            }
        }


        private ObservableCollection<TechnicianQueryResponse> _TechnicianQueriesWithSolution;
        public ObservableCollection<TechnicianQueryResponse> TechnicianQueriesWithSolution
        {
            get { return _TechnicianQueriesWithSolution; }
            set
            {
                _TechnicianQueriesWithSolution = value;
                OnPropertyChanged("TechnicianQueriesWithSolution");
            }
        }

    }
}

