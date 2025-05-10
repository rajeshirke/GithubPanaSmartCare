using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{
    public class PersonServiceCenterResponse
    {
        public int PersonServiceCenterId { get; set; }
        public long PersonId { get; set; }
        public int ServiceCenterId { get; set; }

        public ServiceCenterResponse ServiceCenter { get; set; }
        
    }
}
