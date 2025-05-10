using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Views.Customer.Accesssories;
using eWarranty.Views.Customer.CommonPages;
using Xamarin.Forms;
using System.Threading.Tasks;
using eWarranty.Resx;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Dynamic;
using eWarranty.Core.Models;
using eWarranty.Core.Enums;

namespace eWarranty.ViewModels.Customer.Accesssories
{
    public class AccesssoriesDetailsViewModel : BaseViewModel
    {

        public AccesssoriesDetailsViewModel(INavigation navigation, AccessoryResponse model) : base(navigation)
        {
            try
            {
                SelectedItem = model;

                if (model != null)
                {
                    if (model.Description.Length > 50)
                    {
                        MaxLines = 2;
                        Description = model.Description;
                        IsShowmoreVisible = true;
                    }
                    else
                    {
                        Description = model.Description;
                        IsShowmoreVisible = false;
                        MaxLines = 2;
                    }
                }
                DataBinding();
            }
            catch (Exception ex)
            {

            }
            
        }
        public async Task<int> GetCartCount()
        {
            List<ShoppingCartResponse> accessoryResponses = new List<ShoppingCartResponse>();
            try
            {
                AccessoryManagementSL accessoryManagement = new AccessoryManagementSL();
                accessoryResponses = await accessoryManagement.GetShoppingCartItemsByPersonId(CommonAttribute.CustomeProfile.PersonId);                

            }
            catch (Exception ex)
            {

            }
            return accessoryResponses.Count;
        }
        public void DataBinding()
        {

            if (ProductImages == null)
                ProductImages = new List<string>();
            //ProductImages.Add("headphone.jpg");
            //ProductImages.Add("headphone.jpg");
            //ProductImages.Add("headphone.jpg");
            foreach (var item in SelectedItem.AccessoryFiles)
            {
                string filePath = CommonAttribute.ImageBaseUrl + item.Path;
                ProductImages.Add(filePath);
            }

            CheckOutCommand = new Command(async () =>
            {

               await UpdateCart();

                await Navigation.PushAsync(new CheckoutPage("cart"));
            });

            BuynowCommand = new Command(async () =>
            {
                await UpdateCart();
                if (CommonAttribute.SelectedAccesssories?.Count > 0)
                {
                    PickAddressesPage addressesPage = new PickAddressesPage();
                    addressesPage.SelectedAddress += AddressesPage_SelectedAddress; ;
                    await Navigation.PushAsync(addressesPage);
                }
                else
                {
                    await ErrorDisplayAlert(AppResources.lblCartEmpty);
                }
            });

            CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode;

        }
        public async Task UpdateCart()
        {
            AccessoryManagementSL accessoryManagement = new AccessoryManagementSL();
            long ShoppingCartItemId = 0;
            int Quantity = 1;
            List<ShoppingCartResponse> accessoryResponses = await accessoryManagement.GetShoppingCartItemsByPersonId(CommonAttribute.CustomeProfile.PersonId);
            var accessoryResponsesList = accessoryResponses.Where(p=>p.AccessoryMasterId == SelectedItem.AccessoryMasterId).ToList();

            if(accessoryResponsesList.Count() > 0)
            {
                Quantity = accessoryResponsesList[0].Quantity;
                Quantity = Quantity + 1;
            }

            //if (accessoryResponses.Count == 0)
            //{
                ShoppingCartRequest shoppingCartRequest = new ShoppingCartRequest();
                shoppingCartRequest.AccessoryMasterId = SelectedItem.AccessoryMasterId;
                shoppingCartRequest.CustomerPersonId = CommonAttribute.CustomeProfile.PersonId;
                shoppingCartRequest.Quantity = Quantity;
                //APIResponse accessory = await accessoryManagement.AddToShoppingCart(shoppingCartRequest);

                var receiveContext = await accessoryManagement.AddToShoppingCart(shoppingCartRequest);
                if (receiveContext?.status == Convert.ToInt16(APIResponseEnum.Success))
                {
                    ShoppingCartItemId = receiveContext.data;// (int)accessory.Data;
                }

            //}
            //else
            //{
            //    //-----Later we have to change this API should accept list of accessories with qty-- akash
            //    ShoppingCartUpdateRequest shoppingCartUpdate = new ShoppingCartUpdateRequest();
            //    shoppingCartUpdate.ShoppingCartItemId = accessoryResponses[0].ShoppingCartItemId;
            //    shoppingCartUpdate.AccessoryMasterId = accessoryResponses[0].AccessoryMasterId;
            //    shoppingCartUpdate.Quantity = accessoryResponses[0].Quantity + 1; ;
            //    await accessoryManagement.UpdateShoppingCart(shoppingCartUpdate);
            //    ShoppingCartItemId = accessoryResponses[0].ShoppingCartItemId;
            //}

            //CommonAttribute.SelectedAccesssories = null;

            if (CommonAttribute.SelectedAccesssories == null)
                CommonAttribute.SelectedAccesssories = new List<AccessoryResponse>();

            foreach (var item in accessoryResponses)
            {
                // AccessoryResponse accessory= await accessoryManagement.GetAccessoryById(item.AccessoryMasterId);
                AccessoryResponse accessory = new AccessoryResponse();
                accessory.AccessoryMasterId = item.AccessoryMasterId;
                accessory.Name = item.AccessoryName;
                accessory.Price = item.AccessoryPrice;
                accessory.Description = item.AccessoryDescription;
                accessory.ShoppingCartItemId = item.ShoppingCartItemId;
                accessory.AccessoryFiles = item.AccessoryFiles;
                accessory.CartCount = item.Quantity;
                accessory.Quantity = item.Quantity; //added now prj
                accessory.ServiceCenterName = item.ServiceCenterName;
                CommonAttribute.SelectedAccesssories.Add(accessory);
            }

            SelectedItem.CartCount = 1;
            SelectedItem.Quantity = Quantity;
            SelectedItem.ShoppingCartItemId = ShoppingCartItemId;

            AccessoryResponse ExistResponse = CommonAttribute.SelectedAccesssories.Where(u => u.AccessoryMasterId == SelectedItem.AccessoryMasterId).FirstOrDefault();
            if (ExistResponse != null)
            {
                CommonAttribute.SelectedAccesssories.Remove(ExistResponse);
                ExistResponse.CartCount = ExistResponse.CartCount + 1;
                ExistResponse.ShoppingCartItemId = ShoppingCartItemId;
                ExistResponse.Quantity = Quantity;
                CommonAttribute.SelectedAccesssories.Add(ExistResponse);
            }
            else
                CommonAttribute.SelectedAccesssories.Add(SelectedItem);
        }
        private void AddressesPage_SelectedAddress(object sender, EventArgs e)
        {
            AddressResponse address = sender as AddressResponse;
            CommonAttribute.SelectedAccesssories = CommonAttribute.SelectedAccesssories;
            Navigation.PushAsync(new FinalCheckoutPage(address));
        }



        #region 
        public ICommand CheckOutCommand { get; set; }
        public ICommand BuynowCommand { get; set; }
        public Command CartCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Navigation.PushAsync(new CheckoutPage("cart"));

                });
            }
        }
        
        public Command ShowMoreDetailsCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Description= SelectedItem.Description;
                    MaxLines = 100;
                    IsShowmoreVisible = false;
                });
            }
        }
        #endregion
        private AccessoryResponse _SelectedItem;
        public AccessoryResponse SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                
                _SelectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        private List<string> _ProductImages;
        public List<string> ProductImages
        {
            get { return _ProductImages; }
            set
            {
                _ProductImages = value;
                OnPropertyChanged("ProductImages");
            }
        }

        private bool _IsShowmoreVisible;
        public bool IsShowmoreVisible
        {
            get { return _IsShowmoreVisible; }
            set
            {
                _IsShowmoreVisible = value;
                OnPropertyChanged("IsShowmoreVisible");
            }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                OnPropertyChanged("Description");
            }
        }

        private int _MaxLines;
        public int MaxLines
        {
            get { return _MaxLines; }
            set
            {
                _MaxLines = value;
                OnPropertyChanged("MaxLines");
            }
        }
    }
}
