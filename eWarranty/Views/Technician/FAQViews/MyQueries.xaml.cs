using eWarranty.ViewModels.Technician.FAQViews;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.FAQViews
{
    public partial class MyQueries : ContentPage
    {
        public MyQueries()
        {
            InitializeComponent();
            BindingContext = new MyQueriesViewModel(Navigation);
        }
    }
}
