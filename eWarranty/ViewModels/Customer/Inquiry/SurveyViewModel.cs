using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.Views.Customer.InquiryView;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.Inquiry
{
    public class SurveyViewModel: BaseViewModel
    {
        public SurveyViewModel(INavigation navigation) : base(navigation)
        {
           
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () => {
                await BindingData();
                IsBusy = false;
            });
        }
        private ObservableCollection<CustomerSurveyResponse> _ChatHistory;
        public ObservableCollection<CustomerSurveyResponse> ChatHistory
        {
            get { return _ChatHistory; }
            set
            {
                _ChatHistory = value;
                OnPropertyChanged("ChatHistory");
            }
        }
        private bool _SurverySubmited;
        public bool SurverySubmited
        {
            get { return _SurverySubmited; }
            set
            {
                _SurverySubmited = value;
                OnPropertyChanged("SurverySubmited");
            }
        }
        public async Task BindingData()
        {
            SurverySubmited = false;
            if (ChatHistory != null)
                ChatHistory = new ObservableCollection<CustomerSurveyResponse>();
            FollowUpManagementSL followUpManagementSL = new FollowUpManagementSL();
            List<CustomerSurveyResponse> response = await followUpManagementSL.GetCustomerSurveyByPersonId(CommonAttribute.CustomeProfile.PersonId);
            if (response != null && response.Count > 0)
            {
                SurverySubmited = true;
            }

            if (SurveyModels == null)
                SurveyModels = new ObservableCollection<SurveyModel>();

            //SurveyModels.Add(new SurveyModel() { qId = 1, QName = "What is your name?", ratingnumber = 0 });
            //SurveyModels.Add(new SurveyModel() { qId = 1, QName = "What is your name?", ratingnumber = 0 });
            //SurveyModels.Add(new SurveyModel() { qId = 1, QName = "What is your name?", ratingnumber = 0 });

            FollowUpManagementSL followUpManagement = new FollowUpManagementSL();
            List<SurveyResponse> surveyResponses = await followUpManagement.GetAllActiveSurveys();
            foreach (var item in surveyResponses)
            {
                foreach (var Question in item.SurveyQuestions)
                {
                    SurveyModel surveyModel = new SurveyModel();
                    surveyModel.SurveyId = item.SurveyId;
                    surveyModel.Description = item.Description;
                    surveyModel.SurveyQuestionId = Question.SurveyQuestionId;
                    surveyModel.QuestionText = Question.QuestionText;
                    surveyModel.QuestionTypeId = Question.QuestionTypeId;
                    SurveyModels.Add(surveyModel);
                }
            }

        }
        private ObservableCollection<SurveyModel> _SurveyModels;
        public ObservableCollection<SurveyModel> SurveyModels
        {
            get { return _SurveyModels; }
            set
            {
                _SurveyModels = value;
                OnPropertyChanged("SurveyModels");
            }
        }
        private string _Othermessage;
        public string Othermessage
        {
            get { return _Othermessage; }
            set
            {
                _Othermessage = value;
                OnPropertyChanged("Othermessage");
            }
        }
        //
        public Command SubmitCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (string.IsNullOrEmpty(Othermessage))
                    {
                       await ErrorDisplayAlert(AppResources.lblEnterOtherMessage);
                        return;
                    }
                    var items = SurveyModels;
                    FollowUpManagementSL followUpManagement = new FollowUpManagementSL();
                    List<CustomerSurveyRequest> customerSurveys = new List<CustomerSurveyRequest>();
                    foreach (var item in items)
                    {
                        var existItem = customerSurveys.Where(u => u.SurveyId == item.SurveyId).FirstOrDefault();
                        if(existItem != null)
                        {
                           
                            SurveyQuestionAnswerRequest surveyQuestionAnswer = new SurveyQuestionAnswerRequest();
                            surveyQuestionAnswer.SurveyQuestionId = item.SurveyQuestionId;
                            surveyQuestionAnswer.SurveyRating = item.SurveyRating;
                           
                            existItem.SurveyQuestionAnswers.Add(surveyQuestionAnswer);
                           
                        }
                        else
                        {
                            CustomerSurveyRequest customerSurvey = new CustomerSurveyRequest();
                            customerSurvey.SurveyId = item.SurveyId;
                            customerSurvey.AttendedByPersonId = CommonAttribute.CustomeProfile.PersonId;
                            customerSurvey.AttendedOn = DateTime.Now;
                            customerSurvey.Message = Othermessage;
                            SurveyQuestionAnswerRequest surveyQuestionAnswer = new SurveyQuestionAnswerRequest();
                            surveyQuestionAnswer.SurveyQuestionId = item.SurveyQuestionId;
                            surveyQuestionAnswer.SurveyRating = item.SurveyRating;
                            if (customerSurvey.SurveyQuestionAnswers == null)
                                customerSurvey.SurveyQuestionAnswers = new List<SurveyQuestionAnswerRequest>();
                            customerSurvey.SurveyQuestionAnswers.Add(surveyQuestionAnswer);
                            customerSurveys.Add(customerSurvey);

                        }
                    }
                     var resp = await followUpManagement.PostCustomerSurvey(customerSurveys);
                    if(resp)
                      await Navigation.PushAsync(new FeedBackSuccessPage("survey"));
                });
            }
        }
    }
}
