
using eWarranty.ViewModels.Customer.ProfileView;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eWarranty.Views.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewFieldPopup : PopupPage
    {
        public MyProfileViewModel viewModel { get; set; }

        public AddNewFieldPopup()
        {
            InitializeComponent();
            BindingContext = viewModel = new MyProfileViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var navigation = Application.Current.MainPage.Navigation;
            var totalPages = navigation.NavigationStack.Count;
            //var previousPage = navigation.NavigationStack[totalPages - 1];
            Navigation.RemovePage(this);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Navigation.RemovePage(this);
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAllAsync();
        }

        async void AddNewSaveButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await viewModel.AddNewFieldMethod();
        }
    }

   
}
