using System;
using System.Collections.ObjectModel;
using eWarranty.Core.ResponseModels;

namespace eWarranty.Models
{
    public class AccesssoriesListModel
    {
        public AccessoryResponse RigthItem { get; set; }
        public AccessoryResponse LeftItem { get; set; }
        
    }
}
