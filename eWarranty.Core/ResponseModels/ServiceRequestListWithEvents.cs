using eWarranty.Core.ExtraModels;
using eWarranty.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{
    public class ServiceRequestListWithEvents
    {
        public List<ServiceRequest> lstServiceRequest  { get; set; }

        public List<EventViewModel> lstEventViewModel { get; set; }

    }
}
