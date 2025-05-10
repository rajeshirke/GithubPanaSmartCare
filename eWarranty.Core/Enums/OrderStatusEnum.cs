using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.Enums
{
    public enum OrderStatusEnum
    {
        New = 1,
        Processing,
        Shipped,
        Delivered,
        Cancelled,
        Returned,
        ReturnRequested,
    }
}
