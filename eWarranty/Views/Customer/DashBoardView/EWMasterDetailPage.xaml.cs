using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eWarranty.Views.Customer.DashBoardView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EWMasterDetailPage : MasterDetailPage
    {
        public EWMasterDetailPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as EWMasterDetailPageMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
            NavigationPage.SetHasNavigationBar(page, false);
            NavigationPage.SetHasBackButton(page, false);
            Detail = page;
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}
