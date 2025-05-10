using System;
using Newtonsoft.Json;

namespace eWarranty.Core.ResponseModels
{
    public class OrderListResponse
    {
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNo { get; set; }

        [JsonIgnore]
        public int Rotation { get; set; }
    }
}
