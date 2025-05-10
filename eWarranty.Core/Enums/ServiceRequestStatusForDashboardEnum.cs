using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.Enums
{
    public enum ServiceRequestStatusForDashboardEnum
    {
        All =0,
        New = 1, //Unassigned
        InProgress = 2,
        Closed = 3,
        Due = 4
    }
}
