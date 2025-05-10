using System;
using Xamarin.Forms.Maps;

namespace eWarranty.Models
{
    public class AddressesModel
    {
        public int Id { get; set; }
        public string Location { get; set; }

        public string City { get; set; }
        public string SubArea { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        public string FlatNo { get; set; }
        public string ContactNo { get; set; }
        public Position Position { get; set; }
        //  public bool Selected { get; set; } = false;

        private bool _Selected;
        public bool Selected
        {
            get { return _Selected; }
            set
            {
                if (value)
                    ImageSource = "OvalSelected";
                else
                    ImageSource = "Oval";
                _Selected = value;
            }
        }

        public string ImageSource { get; set; }
    }

}
