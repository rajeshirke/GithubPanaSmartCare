using eWarranty.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.Common
{
    public class CommonRepo
    {
        public  decimal GetPromocodeDiscountAmount(PromoCode promoCode, Decimal AmountToCheckForDiscount)
        {
            if(promoCode.DiscountAmount !=  null)
            {
                return Convert.ToDecimal( promoCode.DiscountAmount);
            }
            if (promoCode.DiscountPercentage != null)
            { 
                return AmountToCheckForDiscount * Convert.ToDecimal(promoCode.DiscountAmount)/100;
            }
            
            return 0;
        }
    }
}
