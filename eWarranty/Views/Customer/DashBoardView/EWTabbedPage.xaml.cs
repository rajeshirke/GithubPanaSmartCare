using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eWarranty.Views.Customer.SRDetails;
using eWarranty.Views.Customer.UserProfile;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace eWarranty.Views.Customer.DashBoardView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EWTabbedPage : Xamarin.Forms.TabbedPage
    {
        public EWTabbedPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            Children.Add(new DashBoardPage());
            Children.Add(new ServicesPage());
            Children.Add(new MyProfilePage());
           // Children.Add(new UserSettingsPage());
        }
    }
}
