using System;
using eWarranty.Core.Common;
using eWarranty.Core.Enums;
using eWarranty.Core.ResponseModels;
using eWarranty.Hepler;
using eWarranty.Resx;
using Xamarin.Forms;
using Extensions = eWarranty.Hepler.Extensions;

namespace eWarranty.ViewModels.Customer.AMCRequest
{
    public class AMCSelectedItemPopupViewModel : BaseViewModel
    {
        public string AmcTypeName { get; set; }
        public DateTime RequestedDate { get; set; }
        public string ProductModelNumber { get; set; }
        public decimal Rate { get; set; }
        public int PeriodInMonths { get; set; }
        public string AmcRequestStatusName { get; set; }
        public string PromoCodeNumber { get; set; }
        public string AmcRequestNumber { get; set; }
        public string CurrencyCode { get; set; }
        public string ProductClassificationName { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }

        public AMCSelectedItemPopupViewModel(INavigation navigation, AmcRequestCustomerLimitedResponse amcRequest) : base(navigation)
        {
            try
            {
                if (amcRequest != null)
                {
                    AmcTypeName = amcRequest.AmcTypeName;
                    RequestedDate = amcRequest.RequestedDate;
                    ProductModelNumber = amcRequest.ProductModelNumber;
                    Rate = amcRequest.AmcrequestMaster.Rate;
                    PeriodInMonths = amcRequest.AmcrequestMaster.PeriodInMonths;
                    //AmcRequestStatusName = amcRequest.AmcRequestStatusName;                
                    AmcRequestNumber = amcRequest.AmcRequestNumber;
                    ProductClassificationName = amcRequest.ProductClassificationName;
                    CurrencyCode = CommonAttribute.CustomeProfile?.CountryResponse?.CurrencyCode;
                    if (amcRequest.PromoCodeNumber != null)
                        PromoCodeNumber = amcRequest.PromoCodeNumber;
                    else
                        PromoCodeNumber = "-";
                    Name = amcRequest.ServiceCenter?.Name;

                    if (amcRequest.ServiceCenter?.ContactNumber1 != null && amcRequest.ServiceCenter?.ContactNumber1 != string.Empty && amcRequest.ServiceCenter?.ContactNumber1 != "")
                        ContactNumber = amcRequest.ServiceCenter?.ContactNumber1;
                    else if (amcRequest.ServiceCenter?.ContactNumber2 != null && amcRequest.ServiceCenter?.ContactNumber2 != string.Empty && amcRequest.ServiceCenter?.ContactNumber2 != "")
                        ContactNumber = amcRequest.ServiceCenter?.ContactNumber2;


                    if (amcRequest.AmcRequestStatusId != 0)
                    {
                        if (amcRequest.AmcRequestStatusId == (int)AmcRequestStatusEnum.New)
                        {
                            if (CommonFunctions.LongCode == "ur")
                                AmcRequestStatusName = "الجديد";
                            else
                                AmcRequestStatusName = "New";
                        }
                        else if (amcRequest.AmcRequestStatusId == (int)AmcRequestStatusEnum.Approved)
                        {
                            if (CommonFunctions.LongCode == "ur")
                                AmcRequestStatusName = "وافق";
                            else
                                AmcRequestStatusName = "Approved";
                        }
                    }
                    else
                    {
                        AmcRequestStatusName = "-";
                    }
                }
            }
            catch (Exception ex)
            {

            }
            
            
        }


        public Command CallServiceCentorCommand
        {
            get
            {
                return new Command(async() =>
                {
                    try
                    {
                        if (ContactNumber != null)
                        {
                            Extensions.PlacePhoneCall(ContactNumber);
                        }
                        else
                        {
                            await ErrorDisplayAlert(AppResources.ErrorMsgMobilenumberisnotavailable);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    
                });
            }
        }



    }
}

