using System;
using System.Collections.Generic;
using eWarranty.Resx;
using eWarranty.Views.Customer.Accesssories;
using eWarranty.Views.Technician;
using eWarranty.Views.Technician.SparePartsViews;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.InquiryView
{
    public partial class FeedBackSuccessPage : ContentPage
    {
        string Page = "";
        string survey = AppResources.msgparticipatinginsurvey;
        string Inquiry = AppResources.msgInquiry;
        string chatbot = AppResources.msgNotedQuery;
        string feedback = AppResources.msgThankyouforyourfeedback;
        string amcrequest = AppResources.msgAMCrequestsentsuccessfully;
        string orderconfirmed = AppResources.lblOrderSuccessMsg;
        string ReturnOrder = AppResources.msgOrderreturnedsuccessfully;
        string SparePartSuccessMsg = AppResources.SparePartSuccessMsg;
        public string Desc { get; set; }

        public FeedBackSuccessPage(string pageName)
        {
            InitializeComponent();
            Page = pageName;
            if (pageName == "feedback")
                lblMsg.Text = feedback;
            else if (pageName == "survey")
                lblMsg.Text = survey;
            else if (pageName == "inquiry")
                lblMsg.Text = Inquiry;
            else if (pageName == "amcrequest")
                lblMsg.Text = amcrequest;
            else if (pageName == "chatbot")
                lblMsg.Text = chatbot;
            else if (pageName == "accesssories")
                lblMsg.Text = orderconfirmed;
            else if (pageName == "ReturnOrder")
                lblMsg.Text = ReturnOrder;
            else if (pageName == "SparePart")
                lblMsg.Text = SparePartSuccessMsg;
            

            if (Page == "accesssories")
                Button1.Text = AppResources.btnGotoorder;
            //else if (Page == "SparePart")
            //    Button1.Text = "Go to list";
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Navigation.RemovePage(this);
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if (Page == "accesssories")
            {
                await Navigation.PushAsync(new MyOrderHistoryPage());
            }
            else if(Page== "SparePart")
            {
               Application.Current.MainPage = new TechMasterPage();
            }
            else
            {
                Application.Current.MainPage = new DashBoadMasterPage();
            }
        }
    }
}
