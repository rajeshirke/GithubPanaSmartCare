using eWarranty.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{
    public class PersonResponse : Person
    {
        public List<TechnicianProductCategory> TechnicianProductCategories { get; set; }
    }
}
