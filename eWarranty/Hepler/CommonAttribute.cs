using System;
using System.Collections.Generic;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;
using eWarranty.Models;
using eWarranty.ViewModels.Account;
using Xamarin.Forms;

namespace eWarranty.Hepler
{
    public class CommonAttribute
    {
        public CommonAttribute()
        {
        }
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }
        public static int CartCount { get; set; }

        //uat
        public static string ImageBaseUrl { get; set; } = "http://mcgapp.org:9094/Files/";
        
        //http://devsrv01.panasonic.ae:83/Files/
        public static LanguageModel selectedLang { get; set; }
        public static PersonLoginResponse CustomeProfile { get; set; }
        public static string Custpwd { get; set; }
        public static FlowDirection flowDirection { get; set; }
        public static DateTime PreferData { get; set; }
        public static AccountDetails AccountDetails { get; set; }
        public static TextAlignment TextAlignment { get; set; }
        public static ServiceRequest SRInputModel { get; set; }
        public static UserCurrentLocation UserLocation { get; set; }
        //public static ServiceRequestDetailsResponse EditServiceRequest { get; set; }
        public static ServiceRequestDetailsNewResponse EditServiceRequest { get; set; } //by anu
        public static ServiceRequestDetailsResponse TechEditServiceRequest { get; set; }        
        public static long CustomerSRidSelected { get; set; }
        public static ServiceRequestResponce SelectedServiceRequest { get; set; }
        public static long SelectedProductModelId { get; set; }
        public static ServiceCenter CustomerSelectedServiceCenter { get; set; }
        public static List<AccessoryResponse> SelectedAccesssories { get; set; }
        public static TimeSpan CustTimeSpan { get; set; }
        public static DropDownModel SelectedArea { get; set; }
        //AccesssoriesModel
        //ServiceCenter
        //ProductModel ProductModel

        // ServiceRequest serviceRequest
        //SRInputModel
    }
}
