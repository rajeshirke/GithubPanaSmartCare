using System;
namespace eWarranty.Core.ResponseModels
{
    public class MobileAMCResponseModel
    {
        public int AmcRequestId { get; set; }
        public int AmcrequestMasterId { get; set; }
        public int ProductModelId { get; set; }
        public int RequestId { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public object ApprovedByPersonId { get; set; }
        public object ApprovalDate { get; set; }
        public int AmcRequestStatusId { get; set; }
        public string AmcRequestStatusName { get; set; }
        public string AmcTypeName { get; set; }
        public object PromoCodeId { get; set; }
        public int CustomerId { get; set; }
        public string ProductClassificationName { get; set; }
        public string ProductModelNumber { get; set; }
        public object PromoCodeNumber { get; set; }
        public string AmcRequestNumber { get; set; }
        public MobileAmcrequestMaster AmcrequestMaster { get; set; }

    }
    public class MobileAmcrequestMaster
    {
        public int amcRequestMasterId { get; set; }
        public int serviceCenterId { get; set; }
        public int amcTypeId { get; set; }
        public string description { get; set; }
        public int periodInMonths { get; set; }
        public double rate { get; set; }
        public int currencyId { get; set; }
        public int countryId { get; set; }
        public object amcExpiryNotificationDays { get; set; }
        public object createdDate { get; set; }
        public object createdByPersonId { get; set; }
        public string amcTypeName { get; set; }
        public object currencyName { get; set; }
        public object countryName { get; set; }
    }
}
