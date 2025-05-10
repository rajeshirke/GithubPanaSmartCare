using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Resx;
using eWarranty.Views.Customer.InquiryView;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.Inquiry
{
    public class FeedBackViewModel : BaseViewModel
    {
        public FeedBackViewModel(INavigation navigation, long sid, long ServiceRequestTypeId) : base(navigation)
        {
            if (StarRatings == null)
                StarRatings = new ObservableCollection<int>();

            StarRatings.Add(1);
            StarRatings.Add(2);
            StarRatings.Add(3);
            StarRatings.Add(4);
            StarRatings.Add(5);
            StarRatings.Add(6);
            StarRatings.Add(7);
            StarRatings.Add(8);
            StarRatings.Add(9);
            StarRatings.Add(10);

            SelectedColor = (Color)Application.Current.Resources["BlueColor"];
            UnSelectedColor = Color.White;
            textColor1 = Color.Red;
            textColor2 = Color.Red;
            textColor3 = Color.Red;
            textColor4 = Color.Red;

            textColor5 = (Color)Application.Current.Resources["BlueColor"];
            textColor6 = (Color)Application.Current.Resources["BlueColor"];
            textColor7 = (Color)Application.Current.Resources["BlueColor"];

            textColor8 = Color.Green;
            textColor9 = Color.Green;
            textColor10 = Color.Green;
            sId = sid;
            SRTypeId = ServiceRequestTypeId;
            Device.BeginInvokeOnMainThread(async () => {
                await BindingData();
                IsBusy = false;
            });

        }
        public async Task BindingData()
        {
            FollowUpManagementSL followUpManagement = new FollowUpManagementSL();
            List<FeedbackQuestion>  customerFeedbacks = await followUpManagement.GetQuestionsAnswersByRequestTypeId(SRTypeId);
            if(customerFeedbacks != null && customerFeedbacks.Count != 0)
            {
                QuestionName = customerFeedbacks[0].QuestionText;
                SelectedfeedbackQuestion = customerFeedbacks[0];
            }
        }
        public void SetupColorCode(int selectedItem)
        {
            Ratingnumber = selectedItem;
            Color1 = UnSelectedColor;
            Color2 = UnSelectedColor;
            Color3 = UnSelectedColor;
            Color4 = UnSelectedColor;
            Color5 = UnSelectedColor;
            Color6 = UnSelectedColor;
            Color7 = UnSelectedColor;
            Color8 = UnSelectedColor;
            Color9 = UnSelectedColor;
            Color10 = UnSelectedColor;
            textColor1 = Color.Red;
            textColor2 = Color.Red;
            textColor3 = Color.Red;
            textColor4 = Color.Red;

            textColor5 = (Color)Application.Current.Resources["BlueColor"];
            textColor6 = (Color)Application.Current.Resources["BlueColor"];
            textColor7 = (Color)Application.Current.Resources["BlueColor"];

            textColor8 = Color.Green;
            textColor9 = Color.Green;
            textColor10 = Color.Green;


            if (selectedItem == 1)
            {
                Color1 = SelectedColor;
                textColor1 = Color.White;
            }
            else if (selectedItem == 2)
            {
                Color2 = SelectedColor;
                textColor2 = Color.White;
            }
            else if (selectedItem == 3)
            {
                Color3 = SelectedColor;
                textColor3 = Color.White;
            }
            else if (selectedItem == 4)
            {
                Color4 = SelectedColor;
                textColor4 = Color.White;
            }
            else if (selectedItem == 5)
            {
                Color5 = SelectedColor;
                textColor5 = Color.White;
            }
            else if (selectedItem == 6)
            {
                Color6 = SelectedColor;
                textColor6 = Color.White;
            }
            else if (selectedItem == 7)
            {
                Color7 = SelectedColor;
                textColor7 = Color.White;
            }
            else if (selectedItem == 8)
            {
                Color8 = SelectedColor;
                textColor8 = Color.White;
            }
            else if (selectedItem == 9)
            {
                Color9 = SelectedColor;
                textColor9 = Color.White;
            }
            else if (selectedItem == 10)
            {
                Color10 = SelectedColor;
                textColor10 = Color.White;
            }
        }
        public Command SelectRatingCommand
        {
            get
            {
                return new Command<int>( (item) =>
                {
                    if (item == 1)
                        Color1 = SelectedColor;
                    else if (item == 1)
                        Color2 = SelectedColor;
                });
            }
        }
        public Command SubmitCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (string.IsNullOrEmpty(OtherMessage))
                    {
                       await ErrorDisplayAlert(AppResources.lblEnterComments);
                       return;
                    }
                    IsBusy = true;
                    try
                    {
                        CustomerFeedbackRequest customerFeedback = new CustomerFeedbackRequest();
                        customerFeedback.ServiceRequestId = sId;
                        customerFeedback.CustomerPersonId = CommonAttribute.CustomeProfile.PersonId;
                        customerFeedback.CreatedOn = DateTime.Now;
                        customerFeedback.FeedbackQuestionAnswers = new List<FeedbackQuestionAnswerRequest>();
                        FeedbackQuestionAnswerRequest feedbackQuestion = new FeedbackQuestionAnswerRequest();

                        feedbackQuestion.FeedbackQuestionId = SelectedfeedbackQuestion.FeedbackQuestionId;
                      //  feedbackQuestion.FeedbackAnswerId = Selected;
                        feedbackQuestion.FeedbackRating = Ratingnumber;
                        feedbackQuestion.OpenMessage = OtherMessage;
                        customerFeedback.FeedbackQuestionAnswers.Add(feedbackQuestion);

                        FollowUpManagementSL followUpManagement = new FollowUpManagementSL();
                        bool resp = await followUpManagement.PostCustomerFeedback(customerFeedback);
                        if (resp)
                            await Navigation.PushAsync(new FeedBackSuccessPage("feedback"));

                        IsBusy = false;
                    }
                    catch (Exception ex)
                    {
                        IsBusy = false;
                        await  ErrorDisplayAlert(ex.Message);
                    }
                });
            }
        }
        public FeedbackQuestion SelectedfeedbackQuestion { get; set; }
        public long sId { get; set; }
        public long SRTypeId { get; set; }
        private string _OtherMessage;
        public string OtherMessage
        {
            get { return _OtherMessage; }
            set
            {
                _OtherMessage = value;
                OnPropertyChanged("OtherMessage");
            }
        }
        private string _QuestionName;
        public string QuestionName
        {
            get { return _QuestionName; }
            set
            {
                _QuestionName = value;
                OnPropertyChanged("QuestionName");
            }
        }
        private ObservableCollection<int> _StarRatings;
        public ObservableCollection<int> StarRatings
        {
            get { return _StarRatings; }
            set
            {
                _StarRatings = value;
                OnPropertyChanged("StarRatings");
            }
        }
        private ObservableCollection<int> _SelectedStarRatings;
        public ObservableCollection<int> SelectedStarRatings
        {
            get { return _StarRatings; }
            set
            {
                _StarRatings = value;
                OnPropertyChanged("StarRatings");
            }
        }
        public int Ratingnumber { get; set; }
        private Color _SelectedColor;
        public Color SelectedColor
        {
            get { return _SelectedColor; }
            set
            {
                _SelectedColor = value;
                OnPropertyChanged("SelectedColor");
            }
        }
        private Color _UnSelectedColor;
        public Color UnSelectedColor
        {
            get { return _UnSelectedColor; }
            set
            {
                _UnSelectedColor = value;
                OnPropertyChanged("UnSelectedColor");
            }
        }
        private Color _Color1;
        public Color Color1
        {
            get { return _Color1; }
            set
            {
                _Color1 = value;
                OnPropertyChanged("Color1");
            }
        }
        private Color _Color2;
        public Color Color2
        {
            get { return _Color2; }
            set
            {
                _Color2 = value;
                OnPropertyChanged("Color2");
            }
        }
        private Color _Color3;
        public Color Color3
        {
            get { return _Color3; }
            set
            {
                _Color3 = value;
                OnPropertyChanged("Color3");
            }
        }
        private Color _Color4;
        public Color Color4
        {
            get { return _Color4; }
            set
            {
                _Color4 = value;
                OnPropertyChanged("Color4");
            }
        }
        private Color _Color5;
        public Color Color5
        {
            get { return _Color5; }
            set
            {
                _Color5 = value;
                OnPropertyChanged("Color5");
            }
        }
        private Color _Color6;
        public Color Color6
        {
            get { return _Color6; }
            set
            {
                _Color6 = value;
                OnPropertyChanged("Color6");
            }
        }
        private Color _Color7;
        public Color Color7
        {
            get { return _Color7; }
            set
            {
                _Color7 = value;
                OnPropertyChanged("Color7");
            }
        }
        private Color _Color8;
        public Color Color8
        {
            get { return _Color8; }
            set
            {
                _Color8 = value;
                OnPropertyChanged("Color8");
            }
        }
        private Color _Color9;
        public Color Color9
        {
            get { return _Color9; }
            set
            {
                _Color9 = value;
                OnPropertyChanged("Color9");
            }
        }
        private Color _Color10;
        public Color Color10
        {
            get { return _Color10; }
            set
            {
                _Color10 = value;
                OnPropertyChanged("Color10");
            }
        }
        private Color _textColor1;
        public Color textColor1
        {
            get { return _textColor1; }
            set
            {
                _textColor1 = value;
                OnPropertyChanged("textColor1");
            }
        }
        private Color _textColor2;
        public Color textColor2
        {
            get { return _textColor2; }
            set
            {
                _textColor2 = value;
                OnPropertyChanged("textColor2");
            }
        }
        private Color _textColor3;
        public Color textColor3
        {
            get { return _textColor3; }
            set
            {
                _textColor3 = value;
                OnPropertyChanged("textColor3");
            }
        }
        private Color _textColor4;
        public Color textColor4
        {
            get { return _textColor4; }
            set
            {
                _textColor4 = value;
                OnPropertyChanged("textColor4");
            }
        }
        private Color _textColor5;
        public Color textColor5
        {
            get { return _textColor5; }
            set
            {
                _textColor5 = value;
                OnPropertyChanged("textColor5");
            }
        }
        private Color _textColor6;
        public Color textColor6
        {
            get { return _textColor6; }
            set
            {
                _textColor6 = value;
                OnPropertyChanged("textColor6");
            }
        }
        private Color _textColor7;
        public Color textColor7
        {
            get { return _textColor7; }
            set
            {
                _textColor7 = value;
                OnPropertyChanged("textColor7");
            }
        }
        private Color _textColor8;
        public Color textColor8
        {
            get { return _textColor8; }
            set
            {
                _textColor8 = value;
                OnPropertyChanged("textColor8");
            }
        }
        private Color _textColor9;
        public Color textColor9
        {
            get { return _textColor9; }
            set
            {
                _textColor9 = value;
                OnPropertyChanged("textColor9");
            }
        }
        private Color _textColor10;
        public Color textColor10
        {
            get { return _textColor10; }
            set
            {
                _textColor10 = value;
                OnPropertyChanged("textColor10");
            }
        }
        //
    }
}
