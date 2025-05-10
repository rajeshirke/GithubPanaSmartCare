using System;
namespace eWarranty.Models
{
    public class SparePartModel
    {
        public string Name { get; set; }
        public string spDate { get; set; }
        public string Desc { get; set; }
        public bool Selected { get; set; } = false;
        public int Avalible { get; set; }
    }
}
