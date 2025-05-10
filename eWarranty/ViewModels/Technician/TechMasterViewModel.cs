using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Views.Technician.FAQViews;
using eWarranty.Views.Technician.ProfileViews;
using eWarranty.Views.Technician.ServiceCenterView;
using eWarranty.Views.Technician.SparePartsViews;
using eWarranty.Views.Technician.SupportViews;
using eWarranty.Views.Technician.TaskViews;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Technician
{
    public class TechMasterViewModel : BaseViewModel
    {
        public TechMasterViewModel(INavigation navigation) : base(navigation)
        {
            //if (CommonAttribute.CustomeProfile.MobileAppModules != null)
            //{
            //    List<MobileAppModuleResponse> DBMobileAppModules = CommonAttribute.CustomeProfile.MobileAppModules;
            //    foreach (var MobileAppModule in DBMobileAppModules)
            //    {

            //        switch (MobileAppModule.Name)
            //        {
            //            case "Register Product":
            //                IsRegisterProduct = true;
            //                break;

            //            case "Services":
            //                IsServices = true;
            //                break;

            //            case "Chat":
            //                IsChat = true;
            //                break;

            //            case "Survey":
            //                IsSurvey = true;
            //                break;

            //            case "Terms & Condition":
            //                IsTermsandCondition = true;
            //                break;

            //            case "Service Center":
            //                IsServiceCenter = true;
            //                break;

            //            case "Profile":
            //                IsProfile = true;
            //                break;

            //            case "Orders":
            //                IsOrders = true;
            //                break;

            //            case "Track Service":
            //                IsTrackService = true;
            //                break;
            //            case "Smart Assistant":
            //                IsSmartAssistant = true;
            //                break;
            //            case "Promotion":
            //                IsPromotion = true;
            //                break;
            //            case "Accessories":
            //                IsAccessories = true;
            //                break;
            //        }

            //    }
            //}
            
            
        }
        public async Task BindingData()
        {


          
        }
        public Command ServiceCenterChatCommand
        {
            get
            {
                return new Command(() =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    Navigation.PushAsync(new ServiceCenterChatPage());
                });
            }
        }
        public Command ServiceManualCommand
        {
            get
            {
                return new Command(async () =>
                {
                     Shell.Current.FlyoutIsPresented = false;
                  await  Navigation.PushAsync(new ServiceManualModelPage());
                });
            }
        }
        public Command TipsAndFAQPCommand
        {
            get
            {
                return new Command(async () =>
                {
                     Shell.Current.FlyoutIsPresented = false;
                  await  Navigation.PushAsync(new TipsAndFAQPage());
                });
            }
        }
        public Command MyjobsCommand
        {
            get
            {
                return new Command(async () =>
                {
                     Shell.Current.FlyoutIsPresented = false;
                     await  Navigation.PushAsync(new TasksSchedulePage((int)MobileDashboardSRStatusEnum.TodaysJobs));
                    //await Navigation.PushAsync(new PaymentSuccessfulPage());
                });
            }
        }
        public Command PartRequestCommand
        {
            get
            {
                return new Command(async () =>
                {
                     Shell.Current.FlyoutIsPresented = false;
                  await  Navigation.PushAsync(new AddSparePartPage());
                });
            }
        }
        public Command PartStockCommand
        {
            get
            {
                return new Command(async () =>
                {
                     Shell.Current.FlyoutIsPresented = false;
                  await  Navigation.PushAsync(new SparePartsPage(1));
                });
            }
        }
        public Command FAQCommand
        {
            get
            {
                return new Command(async () =>
                {
                     Shell.Current.FlyoutIsPresented = false;
                  await  Navigation.PushAsync(new SearchQuery());
                });
            }
        }
        public Command SettingsCommand
        {
            get
            {
                return new Command(async () =>
                {
                     Shell.Current.FlyoutIsPresented = false;
                  await  Navigation.PushAsync(new MyProfilePage());
                });
            }
        }

        public Command MyQueriesCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    await Navigation.PushAsync(new MyQueries());
                });
            }
        }

        public Command MyOrdersCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    await Navigation.PushAsync(new OrderRequestsPage());
                });
            }
        }

        public Command SparePartRequestsCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Shell.Current.FlyoutIsPresented = false;
                    await Navigation.PushAsync(new TechnicianSparePartListPage());
                });
            }
        }

    }
}
