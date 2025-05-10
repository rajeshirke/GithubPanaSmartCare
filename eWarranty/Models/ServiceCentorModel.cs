using System;
namespace eWarranty.Models
{
    public class ServiceCentorModel
    {
        public int SCid { get; set; }
        public string Name { get; set; }
        public double Distance { get; set; }
        public string LocationName { get; set; }

        public bool SelectedItem { get; set; }
    }
}
