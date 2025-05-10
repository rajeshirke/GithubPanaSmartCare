using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using eWarranty.Core.ResponseModels;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.Views.Customer.Accesssories;
using eWarranty.Views.Customer.AMCRequest;
using eWarranty.Views.Customer.InquiryView;
using eWarranty.Views.Customer.Products;
using eWarranty.Views.Customer.SRDetails;
using eWarranty.Views.Customer.UserProfile;
using eWarranty.Views.ServiceCentorView;
using Xamarin.Forms;
using System.Linq;
using eWarranty.Views.Account;
using eWarranty.Views.Customer.CommonPages;
using eWarranty.Views.Customer;

namespace eWarranty.ViewModels.Customer
{
    public class eWMasterDetailViewModel : BaseViewModel
    {
        public eWMasterDetailViewModel(INavigation navigation) : base(navigation)
        {
            try
            {
                if (CommonAttribute.CustomeProfile.MobileAppModules != null)
                {
                    List<MobileAppModuleResponse> DBMobileAppModules = CommonAttribute.CustomeProfile.MobileAppModules;
                    foreach (var MobileAppModule in DBMobileAppModules)
                    {

                        switch (MobileAppModule.Name)
                        {
                            case "Register Product":
                                IsRegisterProduct = true;
                                break;

                            case "Services":
                                IsServices = true;
                                break;

                            case "Chat":
                                IsChat = true;
                                break;

                            case "Survey":
                                IsSurvey = true;
                                break;

                            case "Terms & Condition":
                                IsTermsandCondition = true;
                                break;

                            case "Service Center":
                                IsServiceCenter = true;
                                break;

                            case "Profile":
                                IsProfile = true;
                                break;

                            case "Orders":
                                IsOrders = true;
                                break;

                            case "Track Service":
                                IsTrackService = true;
                                break;
                            case "Smart Assistant":
                                IsSmartAssistant = true;
                                break;
                            case "Promotion":
                                IsPromotion = true;
                                break;
                            case "Accessories":
                                IsAccessories = true;
                                break;
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
            
            
            // IsBusy = false;
            //AmcListCommand
        }

        
        //AccountCommand
        public Command OrdersCommand
        {
            get
            {
                return new Command(() =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    Navigation.PushAsync(new MyOrderHistoryPage());
                });
            }
        }
        public Command ProductsCommand
        {
            get
            {
                return new Command(() =>
               {
                   Shell.Current.FlyoutIsPresented = false;
                   Navigation.PushAsync(new ProductsPage());
               });
            }
        }
        public Command ChatHistoryCommand
        {
            get
            {
                return new Command(() =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    Navigation.PushAsync(new ChatBotHistoryPage());
                });
            }
        }
        //ChatHistoryCommand
        public Command AmcListCommand
        {
            get
            {
                return new Command(() =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    Navigation.PushAsync(new AMCRequestListPage());
                });
            }
        }
        public Command ServicesCommand
        {
            get
            {
                return new Command(() =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    Navigation.PushAsync(new ServicesPage());
                });
            }
        }
        public Command ServiceCentorsCommand
        {
            get
            {
                return new Command(() =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    Navigation.PushAsync(new ServiceCentorsPage());
                });
            }
        }
        public Command SurveyPageCommand
        {
            get
            {
                return new Command(() =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    Navigation.PushAsync(new SurveyPage());
                });
            }
        }
        public Command InquiryCommand
        {
            get
            {
                return new Command(() =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    Navigation.PushAsync(new ChatBotViewPage());
                });
            }
        }
        public Command AccountCommand
        {
            get
            {
                return new Command(() =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    Navigation.PushAsync(new MyProfileNew());
                });
            }
        }
        //AccountCommand


        
    }


}
