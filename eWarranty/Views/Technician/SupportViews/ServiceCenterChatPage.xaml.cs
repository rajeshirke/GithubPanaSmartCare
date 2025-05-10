using System;
using System.Collections.Generic;
using System.Linq;
using eWarranty.ViewModels.Technician.SupportViews;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.SupportViews
{
    public partial class ServiceCenterChatPage : ContentPage
    {
        public ServiceCenterChatViewModel viewModel { get; set; }
        public ServiceCenterChatPage()
        {
            InitializeComponent();
            BindingContext = viewModel= new ServiceCenterChatViewModel(Navigation);
            MessagingCenter.Unsubscribe<ServiceCenterChatViewModel,string>(this, "Updatechat");
            MessagingCenter.Subscribe<ServiceCenterChatViewModel,string>(this, "Updatechat",  (sender,arg) =>
            {
               var item= viewModel.Messages.LastOrDefault();
                MessagesListView.ScrollTo(item, ScrollToPosition.MakeVisible, true);

            });
        }
        private void MyListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MessagesListView.SelectedItem = null;
        }

        private void MyListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            MessagesListView.SelectedItem = null;

        }
    }
}
