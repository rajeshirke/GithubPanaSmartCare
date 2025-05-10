using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public class PersonUpdateRequest
    {
        public long PersonId { get; set; }
        public int? CountryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? PreferredLanguageId { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string AlternateMobileNumber { get; set; }
        public int? Salutation { get; set; }
        public int? NationalityId { get; set; }
        public int? CityId { get; set; }
        public int? AreaId { get; set; }
        //public int? PersonStatusId { get; set; }
        //public bool? IsEmailValidated { get; set; }
        //public bool? IsMobileValidated { get; set; }
        //public bool? IsPasswordChanged { get; set; }

        ////---------extra
        //public string PersonPassword { get; set; }
    }
}
