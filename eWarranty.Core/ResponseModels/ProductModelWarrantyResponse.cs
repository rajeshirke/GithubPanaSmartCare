using System;
using System.Collections.Generic;
using System.Text;
using eWarranty.Core.Common;
using Xamarin.Forms;

namespace eWarranty.Core.ResponseModels
{
    public class ProductModelWarrantyResponse : SearchCustomerProductModelsResponse
    {
        public WarrantyCustomerProductResponse ActiveWarranty { get; set; }
        public bool IsPendingForProductRequestApproval { get; set; }
        public string ProductModelImageURL { get; set; }
        public string CustomerName { get; set; }
        public string ContactNumber { get; set; }

        #region Kumar Code

        public Uri ModelImageURL {
            get {
                if (string.IsNullOrEmpty(ProductModelImageURL))
                    return new Uri("defaultprod");
                else
                   return new Uri(ProductModelImageURL);
            }

          }
        public string WarrantyTypeName { get {

                string typeName = "-";
                if (IsPendingForProductRequestApproval)
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "بانتظار التأكيد";
                    else
                        return "Awaiting Confirmation";

                }

                if (ActiveWarranty?.WarrantyTypeName?.ToLower() == "amc") //by akash
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "AMC";
                    else
                        return "AMC";
                }
                else if (ActiveWarrantyCustomerProductID == null)
                {
                    if (CommonFunctions.LongCode == "ur")
                        return "الضمان خارج";
                    else
                        return "Out of Warranty";
                }
               
                else if (ActiveWarranty != null)
                {
                    
                        if(ActiveWarranty.WarrantyTypeName?.ToLower() == "domestic")
                        {
                            if (CommonFunctions.LongCode == "ur")
                                return "المحلية";
                            else
                                return "Domestic";
                        }
                        else if (ActiveWarranty.WarrantyTypeName?.ToLower() == "extended")
                        {
                            if (CommonFunctions.LongCode == "ur")
                                return "ممتد، طويل، ممدود";
                            else
                                return "Extended";
                        }
                    else if (ActiveWarranty.WarrantyTypeName?.ToLower() == "out warranty")
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "الضمان خارج";
                        else
                            return "Out of Warranty";
                    }
                    else if (ActiveWarranty.WarrantyTypeName.Contains("Awaiting"))
                        {
                            if (CommonFunctions.LongCode == "ur")
                            return "بانتظار التأكيد";
                           else
                                return "Awaiting Confirmation";
                        }
                    else if (ActiveWarranty.WarrantyTypeName?.ToLower() == "international")
                        {
                            if (CommonFunctions.LongCode == "ur")
                                return "دولي";
                            else
                                return "International";
                        }
                    else if (ActiveWarranty.WarrantyTypeName?.ToLower() == "amc")
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "AMC";
                        else
                            return "AMC";
                    }
                    else
                          typeName = ActiveWarranty.WarrantyTypeName;
                }
                    

                return typeName;
            }
        }
        public string ExpiresDaysTextColor
        {
            get
            {

                int TotalDays = 0;
                if (ActiveWarranty != null)
                {
                    TotalDays = (ActiveWarranty.EndDate - DateTime.Now).Days;

                }
                if (TotalDays <= 30)
                    return "#ff000d";
                else
                    return " #00FFFF";

                return " #00FFFF";
            }
        }
        public string ExpiresDays
        {
            get
            {

                int TotalDays = 0;
                if (ActiveWarranty != null)
                {
                    TotalDays = (ActiveWarranty.EndDate- DateTime.Now).Days;

                }
                if (TotalDays > 0)
                {
                    if (CommonFunctions.LongCode == "ur")
                    {
                        return TotalDays.ToString() + " " + "أيام";
                    }
                    else
                    {
                        return TotalDays.ToString() + " " + "Days";
                    }
                }
                    
                 else
                    return  "-";

                return TotalDays.ToString();
            }
        }
        public bool SelectedItem { get; set; } = false;
        #endregion
    }
}
