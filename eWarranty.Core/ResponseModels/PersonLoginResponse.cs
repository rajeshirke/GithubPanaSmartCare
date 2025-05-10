using eWarranty.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{
    public class PersonLoginResponse : PersonDetailsResponse
    {
        public CountryResponse CountryResponse { get; set; }
    
        public virtual ICollection<PersonServiceCenterResponse> PersonServiceCenters { get; set; }
    }
}
