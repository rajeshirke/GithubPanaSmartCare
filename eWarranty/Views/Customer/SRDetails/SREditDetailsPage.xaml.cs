using System;
using System.Collections.Generic;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.ViewModels.Customer.SRDetails;
using eWarranty.Views.Customer.Products;
using eWarranty.Views.Customer.SRDetails.SubViews;
using Xamarin.Forms;

namespace eWarranty.Views.Customer.SRDetails
{
    public partial class SREditDetailsPage : ContentPage
    {
        public SREditDetailsViewModel viewModel { get; set; }
        public int TabId { get; set; }
        public long rsid { get; set; }
        public SREditDetailsPage(long sid, int tabid)
        {
            rsid = sid;
            CommonAttribute.CustomerSRidSelected = sid;
            InitializeComponent();
            BindingContext = viewModel= new SREditDetailsViewModel(Navigation,sid, tabid);
            TabId = tabid;
            


        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
           // slSubContent.Children.Clear();
            //if (TabId == 2)
            //{
            //    FollowupView followupView = null;
            //    if (followupView == null)
            //        followupView = new FollowupView();
            //    // viewModel.UpdateSelectedItem("Follow-Up");
            //    slSubContent.Children.Add(followupView);
            //}
            //else
            //{
            //    ProductDetailsSubView productDetailsPage = null;
            //    if (productDetailsPage == null)
            //        productDetailsPage = new ProductDetailsSubView();
            //    //  viewModel.UpdateSelectedItem("Follow-Up");
            //    slSubContent.Children.Add(productDetailsPage);
            //}
            
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
                await viewModel.Getdata(CommonAttribute.CustomerSRidSelected);
                IsBusy = false;
            });
            //MessagingCenter.Unsubscribe<SREditDetailsViewModel, string>(this, "uitab");
            //MessagingCenter.Subscribe<SREditDetailsViewModel, string>(this, "uitab", (sender, arg) =>
            //{


            //    slSubContent.Children.Clear();
            //    if (arg == "followupView")
            //    {
            //        FollowupView followupView = null;
            //        if (followupView == null)
            //            followupView = new FollowupView();
            //        slSubContent.Children.Add(followupView);
            //    }
            //    else
            //    {
            //        ProductDetailsSubView productDetailsPage = null;
            //        if (productDetailsPage == null)
            //            productDetailsPage = new ProductDetailsSubView();
            //        slSubContent.Children.Add(productDetailsPage);
            //    }
            //    MessagingCenter.Unsubscribe<SREditDetailsViewModel, string>(this, "uitab");
            //});
        }

        void segment_SelectedItemChanged(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            TabOption tab = e.SelectedItem as TabOption;
            SRDetailsView sRDetailsView = null;
            FollowupView followupView = null;
            ProductDetailsSubView productDetailsPage = null;
            CostEstimationView requestView = null;
            InvoiceDetailsView invoiceDetailsView = null;
            viewModel.UpdateSelectedItem(tab.Name);
            if (tab.id == 1 && tab.IsSelected)
            {
                slSubContent.Children.Clear();
                if (sRDetailsView == null)
                    sRDetailsView = new SRDetailsView();
                slSubContent.Children.Add(sRDetailsView);

            }
            else if (tab.id == 2 && tab.IsSelected)
            {
                slSubContent.Children.Clear();
                if (followupView == null)
                    followupView = new FollowupView(rsid);
                slSubContent.Children.Add(followupView);
                //ProductDetailsPage    
            }
            else if (tab.id == 3 && tab.IsSelected)
            {
                slSubContent.Children.Clear();
                if (productDetailsPage == null)
                {
                    if (viewModel.serviceRequestNew?.ProductModelId != null)
                        productDetailsPage = new ProductDetailsSubView((long)(viewModel.serviceRequestNew?.ProductModelId));
                }
                if (productDetailsPage != null)
                    slSubContent.Children.Add(productDetailsPage);
                //ProductDetailsPage    
            }
            else if (tab.id == 4 && tab.IsSelected)
            {
                slSubContent.Children.Clear();
                if (requestView == null)
                    requestView = new CostEstimationView();
                slSubContent.Children.Add(requestView);
                //ProductDetailsPage    
            }
            else if (tab.id == 5 && tab.IsSelected)
            {
                slSubContent.Children.Clear();
                if (invoiceDetailsView == null)
                    invoiceDetailsView = new InvoiceDetailsView();
                slSubContent.Children.Add(invoiceDetailsView);
                //ProductDetailsPage    
            }
            //InvoiceDetailsView
        }
    }
}
