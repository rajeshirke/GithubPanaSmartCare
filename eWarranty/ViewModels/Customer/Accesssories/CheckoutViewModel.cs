using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.Views.Customer.Accesssories;
using eWarranty.Views.Customer.CommonPages;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace eWarranty.ViewModels.Customer.Accesssories
{
    public class CheckoutViewModel : BaseViewModel
    {
        public CheckoutViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;
            

            Device.BeginInvokeOnMainThread(async () =>
            {
                SelectedProducts = new ObservableCollection<AccessoryResponse>(CommonAttribute.SelectedAccesssories);
                foreach(var item in SelectedProducts)
                {
                    item.CurrencyCode = CommonAttribute.CustomeProfile?.CountryResponse?.CurrencyCode;
                }
                Title = "Cart";                
                await BindingData();
                IsBusy = false;
                CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode;

            });
        }
        public CheckoutViewModel(INavigation navigation, string cart) : base(navigation)
        {
            IsBusy = true;
            CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode;

            Device.BeginInvokeOnMainThread(async () =>
            {
                await GetShoppingCartItems();
                await BindingData();
                IsBusy = false;
            });
        }
        public async Task GetShoppingCartItems()
        {
            try
            {
                var SelectedProducts1 = SelectedProducts;
                if (SelectedProducts1 == null)
                    SelectedProducts1 = new ObservableCollection<AccessoryResponse>();
                AccessoryManagementSL accessoryManagement = new AccessoryManagementSL();
                List<ShoppingCartResponse> accessoryResponses = await accessoryManagement.GetShoppingCartItemsByPersonId(CommonAttribute.CustomeProfile.PersonId);

                foreach (var item in accessoryResponses)
                {
                    AccessoryResponse accessory = new AccessoryResponse();
                    accessory.AccessoryMasterId = item.AccessoryMasterId;
                    accessory.Name = item.AccessoryName;
                    accessory.Price = item.AccessoryPrice;
                    accessory.Description = item.AccessoryDescription;
                    accessory.ShoppingCartItemId = item.ShoppingCartItemId;
                    accessory.AccessoryFiles = item.AccessoryFiles;
                    accessory.CartCount = item.Quantity;
                    accessory.ServiceCenterName = item.ServiceCenterName;

                    SelectedProducts1.Add(accessory);
                }

                SelectedProducts = SelectedProducts1;
                SelectedProducts.ForEach(c => c.CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode);
            }
            catch (Exception ex)
            {

            }
           
        }
        public async Task GetShoppingCart(AccessoryResponse SelectedItem,int actionId)
        {
            try
            {
                AccessoryManagementSL accessoryManagement = new AccessoryManagementSL();
                List<ShoppingCartResponse> accessoryResponses = await accessoryManagement.GetShoppingCartItemsByPersonId(CommonAttribute.CustomeProfile.PersonId);
                if (accessoryResponses.Count == 0)
                {
                    ShoppingCartRequest shoppingCartRequest = new ShoppingCartRequest();
                    shoppingCartRequest.AccessoryMasterId = SelectedItem.AccessoryMasterId;
                    shoppingCartRequest.CustomerPersonId = CommonAttribute.CustomeProfile.PersonId;
                    shoppingCartRequest.Quantity = 1;
                    await accessoryManagement.AddToShoppingCart(shoppingCartRequest);
                }
                else
                {

                    ShoppingCartUpdateRequest shoppingCartUpdate = new ShoppingCartUpdateRequest();
                    shoppingCartUpdate.ShoppingCartItemId = accessoryResponses[0].ShoppingCartItemId;
                    shoppingCartUpdate.AccessoryMasterId = accessoryResponses[0].AccessoryMasterId;
                    if (actionId == 1)
                        shoppingCartUpdate.Quantity = SelectedItem.CartCount;
                    else
                        shoppingCartUpdate.Quantity = SelectedItem.CartCount - 1;

                    shoppingCartUpdate.IsDeleted = false;
                    await accessoryManagement.UpdateShoppingCart(shoppingCartUpdate);
                }
            }
            catch (Exception ex)
            {

            }
            
        }
        public async Task DeleteShoppingCart(AccessoryResponse SelectedItem)
        {
            try
            {
                AccessoryManagementSL accessoryManagement = new AccessoryManagementSL();
                ShoppingCartUpdateRequest shoppingCartUpdate = new ShoppingCartUpdateRequest();
                shoppingCartUpdate.ShoppingCartItemId = SelectedItem.ShoppingCartItemId;
                shoppingCartUpdate.IsDeleted = true;
                await accessoryManagement.UpdateShoppingCart(shoppingCartUpdate);

            }
            catch (Exception ex)
            {

            }
            
        }

        public async Task BindingData()
        {
            AddresSelectCommand = new Command<int>((itemid) =>
            {
                Navigation.PushAsync(new AddressesPage());
            });            
        }

        private void AddressesPage_SelectedAddress(object sender, EventArgs e)
        {
            try
            {
                AddressResponse address = sender as AddressResponse;
                CommonAttribute.SelectedAccesssories = SelectedProducts.ToList();
                Navigation.PushAsync(new FinalCheckoutPage(address));
            }
            catch (Exception ex)
            {

            }
            
        }

        public void UpdateTitlewithAmount()
        {
            try
            {
                decimal amount = 0;
                foreach (var item in SelectedProducts)
                {
                    amount = Convert.ToDecimal((amount + (item.Price * item.Quantity)));
                }
            }
            catch (Exception ex)
            {

            }
                     
        }
        #region
       
        public ICommand AddresSelectCommand { get; set; }
      
        public Command plusCommand
        {
            get
            {
                return new Command<long>(async (itemid) =>
                {
                    try
                    {
                        var SelectedProducts1 = SelectedProducts;
                        AccessoryResponse accesssoriesModel = SelectedProducts1.Where(u => u.AccessoryMasterId == itemid).FirstOrDefault();
                        SelectedProducts1.Remove(accesssoriesModel);
                        accesssoriesModel.CartCount = accesssoriesModel.CartCount + 1;
                        SelectedProducts1.Add(accesssoriesModel);

                        SelectedProducts = SelectedProducts1;
                        SelectedProducts.ForEach(c => c.CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode);
                        await GetShoppingCart(accesssoriesModel, 1);
                        UpdateTitlewithAmount();
                    }
                    catch (Exception ex)
                    {

                    }
                   
                });
            }
        }
        public Command minusCommand
        {
            get
            {
                return new Command<long>(async (itemid) =>
                {
                    var SelectedProducts1 = SelectedProducts;
                    AccessoryResponse accesssoriesModel = SelectedProducts1.Where(u => u.AccessoryMasterId == itemid).FirstOrDefault();
                    if (accesssoriesModel.CartCount <= 1)
                        return;

                    await GetShoppingCart(accesssoriesModel, 0);
                    accesssoriesModel.CartCount = accesssoriesModel.CartCount - 1;
                    if (accesssoriesModel.CartCount == 0)
                        SelectedProducts1.Remove(accesssoriesModel);
                    else
                    {
                        SelectedProducts1.Remove(accesssoriesModel);                        
                        SelectedProducts1.Add(accesssoriesModel);
                    }
                    if (SelectedProducts1.Count == 0)
                       await Navigation.PopAsync();
                    UpdateTitlewithAmount();
                    
                    SelectedProducts = SelectedProducts1;
                    SelectedProducts.ForEach(c => c.CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode);
                });
            }
        }
        public Command DeleteItemCommand
        {
            get
            {
                return new Command<long>(async (itemid) =>
                {
                    var SelectedProducts1 = SelectedProducts;
                    AccessoryResponse accesssoriesModel = SelectedProducts1.Where(u => u.AccessoryMasterId == itemid).FirstOrDefault();
                    SelectedProducts1.Remove(accesssoriesModel);
                    if (SelectedProducts1.Count == 0)
                      await  Navigation.PopAsync();
                    await DeleteShoppingCart(accesssoriesModel);
                    SelectedProducts = SelectedProducts1;
                    SelectedProducts.ForEach(c => c.CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode);
                });
            }
        }
        public Command NextCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (SelectedProducts.Count > 0)
                        {
                            PickAddressesPage addressesPage = new PickAddressesPage();
                            addressesPage.SelectedAddress += AddressesPage_SelectedAddress;
                            await Navigation.PushAsync(addressesPage);
                        }
                        else
                        {
                            await ErrorDisplayAlert(AppResources.lblCartEmpty);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    
                    
                });
            }
        }
        #endregion

        #region properties
       
        private ObservableCollection<AccessoryResponse> _SelectedProducts;
        public ObservableCollection<AccessoryResponse> SelectedProducts
        {
            get { return _SelectedProducts; }
            set
            {
                _SelectedProducts = value;
                if (value != null)
                {
                    CommonAttribute.SelectedAccesssories = SelectedProducts.ToList();
                }
                OnPropertyChanged(nameof(SelectedProducts));
                OnPropertyChanged(nameof(TotalAmount));
            }
        }

        private double _TotalAmount;
        public double TotalAmount
        {
            get {
                if (SelectedProducts != null
                    && SelectedProducts.Count > 0)
                {
                    _TotalAmount = 0;
                    foreach (var item in SelectedProducts)
                    {
                        _TotalAmount += Convert.ToDouble((item.CartCount) * (item.ProdcuPrice));
                    }
                }
                return _TotalAmount;
            }
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                OnPropertyChanged("Title");
            }
        }
        #endregion
    }
}
