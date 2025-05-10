using System;
using Xamarin.Forms;

namespace eWarranty.Models
{
    public class ServiceRequestModel
    {
        public int Sid { get; set; }
        public string Category { get; set; }
        public string ProductName { get; set; }
        public string SRNumber { get; set; }
        public string ModelNumber { get; set; }
        public string SerialNumber { get; set; }
        public DateTime POD { get; set; }
        public int CategoryId { get; set; }
        public DateTime warrantyDate { get; set; }
        public Color ProductStatusColor { get; set; }
    }
}
