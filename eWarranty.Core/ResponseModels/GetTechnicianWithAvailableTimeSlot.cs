using System;
namespace eWarranty.Core.ResponseModels
{
    public class GetTechnicianWithAvailableTimeSlot
    {
        public long PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? AvailableTime { get; set; }
    }
}
