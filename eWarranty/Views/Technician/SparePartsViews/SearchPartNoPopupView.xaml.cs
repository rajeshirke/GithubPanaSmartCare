using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.SparePartsViews
{
    public partial class SearchPartNoPopupView : PopupPage
    {
        public SearchPartNoPopupView()
        {
            InitializeComponent();
            cvList.BindingContext = this;
            this.BindingContext = this;
        }

        public static BindableProperty TitleProperty =
          BindableProperty.Create(nameof(Title), typeof(string), typeof(SearchPartNoPopupView), null, BindingMode.TwoWay);

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, FirstCharToUpper(value));
        }
        public void SetSearchKey(string key)
        {
            sbKey.Text = key;
        }
        public string SearchKey { get; set; }
        public static readonly BindableProperty PickerItemsSourceProperty = BindableProperty.Create("PickerItemsSource", typeof(IList), typeof(SearchPartNoPopupView), null, BindingMode.TwoWay, propertyChanged: ItemsSourceChanged);

        private static void ItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (SearchPartNoPopupView)bindable;
            
        }

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        public List<DropDownModel> MasterData { get; set; }
        public IList PickerItemsSource
        {
            get { return (IList)GetValue(PickerItemsSourceProperty); }
            set
            {
                SetValue(PickerItemsSourceProperty, value);
            }
        }
        public static readonly BindableProperty SelectedItemProperty =
          BindableProperty.Create(nameof(SelectedItem),
              typeof(DropDownModel),
              typeof(SearchPartNoPopupView),
              null,
              BindingMode.TwoWay, propertyChanged: OnSelectedItemPropertyChanged);

        private static void OnSelectedItemPropertyChanged(BindableObject bindable, object value, object newValue)
        {
            var control = (SearchPartNoPopupView)bindable;
            control.SelectedItem = newValue as DropDownModel;

        }

        public DropDownModel SelectedItem
        {
            get
            {
                return this.GetValue(SelectedItemProperty) as DropDownModel;
            }
            set
            {
                this.SetValue(SelectedItemProperty, value);
            }
        }

        async void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            string model = "";
            if (CommonAttribute.selectedLang.lid == 1)
            {
                model = "Part";
                if (Title.Contains(model))
                {
                    string sKey = "";
                    if (!string.IsNullOrEmpty(e.NewTextValue))
                        sKey = e.NewTextValue.Trim();
                    
                    if (sKey.Count() >= 2)
                        await GetPartNumber(e.NewTextValue);
                }
                else
                {

                    PickerItemsSource = MasterData.Where(u => u.Title.ToLower().Contains(e.NewTextValue.ToLower())).ToList();
                }
            }
            else
            {
                string sKey = "";
                if (!string.IsNullOrEmpty(e.NewTextValue))
                    sKey = e.NewTextValue.Trim();
                
                if (sKey.Count() >= 2)
                    await GetPartNumber(e.NewTextValue);
            }

        }

        public async Task GetPartNumber(string skey)
        {
            MasterDataManagementSL dataManagementSL = new MasterDataManagementSL();

            List<ModelNumberSearchResponse> modelNumberSearchResponses = await dataManagementSL.SearchModelNumberByInitials(skey, 0);
            List<DropDownModel> dropDownModels = new List<DropDownModel>();
            if (modelNumberSearchResponses != null)
            {
                foreach (var item in modelNumberSearchResponses)
                {
                    dropDownModels.Add(new DropDownModel() { Title = item.ModelName, Id = item.ProductClassificationId, Desc = item.ModelDescreption });
                }
            }
            PickerItemsSource = dropDownModels;
        }
        public event EventHandler DropDownSelectedItem;

        async void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            EventHandler handler = DropDownSelectedItem;
            if (handler != null)
            {
                SelectedItem = e.CurrentSelection[0] as DropDownModel;
                handler(this, e);
                handler.Invoke(this, e);
                await PopupNavigation.Instance.PopAsync();
            }
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}
