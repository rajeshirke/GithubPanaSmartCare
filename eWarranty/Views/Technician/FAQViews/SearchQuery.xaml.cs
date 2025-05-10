using eWarranty.ViewModels.Technician.FAQViews;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.FAQViews
{
    public partial class SearchQuery : ContentPage
    {
        public SearchQuery()
        {
            InitializeComponent();
            BindingContext = new TechnicianQueryResponseViewModel(Navigation);

        }

    }
}
