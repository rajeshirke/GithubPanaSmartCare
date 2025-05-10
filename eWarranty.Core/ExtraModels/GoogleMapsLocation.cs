using eWarranty.Core.Models;

namespace eWarranty.Core.ExtraModels
{
    public class GoogleMapsLocation : Address
    {
        //public GeoCoordinate geoCoordinateAddress { get; set; }

        public dynamic ExtraDetails { get; set; }
    }

    public class GoogleMapsLocationServiceCenter : ServiceCenter
    {
        public dynamic ExtraDetails { get; set; }
    }

    //public class TechnicianMapDetails
    //{

    //}


}
