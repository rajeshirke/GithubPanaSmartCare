using System;
using System.Collections.Generic;

namespace eWarranty.Core.ResponseModels
{
    public class PersonDetailsResponse
    {
        public long PersonId { get; set; }
        public Guid UserId { get; set; }
        public long? ParentPersonId { get; set; }
        public int CountryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public int PreferredLanguageId { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneCode { get; set; }
        public string AlternateMobileNumber { get; set; }
        public int? Salutation { get; set; }
        //public string CreatedByUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? PersonRoleId { get; set; }
        public int? PersonStatusId { get; set; }
        public int? ProfilePictureFileInfoId { get; set; }
        public virtual FileInfoResponse ProfilePictureFileInfo { get; set; }

        public virtual List<MobileAppModuleResponse> MobileAppModules { get; set; }
    }
}
