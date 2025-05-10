using System;
namespace eWarranty.Core.RequestModels
{
    public class LoginRequest
    {
        public string email { get; set; }
        public string mobileNumber { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int? versionNumber { get; set; }
    }
}
