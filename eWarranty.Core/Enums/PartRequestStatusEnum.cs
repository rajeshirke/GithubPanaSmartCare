using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.Enums
{
    public enum PartRequestStatusEnum
    {
        Open =1,//PendingForParts = 1,
        InProgress ,

       
        Closed ,//PartsAllocatedClosed

        UnderEstimation, //----added for cost estimation
        Cancelled //----if cost estimation is getting cancelled 
    }

    public enum PartRequestStatusEnumSup
    {
        Open = 1,//PendingForParts = 1,
        InProgress,
        Issue,//PartsAllocatedClosed //Closed
        UnderEstimation, //----added for cost estimation
        Cancel,//----if cost estimation is getting cancelled
        Accept //--- this is not in Database- just UI purpose only used - for return part request
    }
}
