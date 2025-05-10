using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.Enums
{
    public enum PartRequestTypeEnum
    {
        PartUsageForService = 1,//---Technician has used the part for his job
        StockRequest, //--- when the stock is empty technician can make this request
        TechnicianStockRequest,//--part request by technician for bufferstock
        ReturnRequest, //--- return the part when there is no need

        //PartRequestForServiceRequest,//--part request by technician for service request 

    }
}
