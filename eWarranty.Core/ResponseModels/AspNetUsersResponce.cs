using eWarranty.Core.Models;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eWarranty.Core.ResponseModels
{
    public class AspNetUsersResponce : AspNetUser
    {
        public string Message { get; set; }
    }
}
