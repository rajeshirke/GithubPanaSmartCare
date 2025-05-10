using System;
using System.Collections.Generic;
using System.Text;
using eWarranty.Core.Models;

namespace eWarranty.Core.ResponseModels
{
    public class APIResponse
    {
        public Object Data { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string ArMessage { get; set; }
        public string ArErrorMessage { get; set; }

        public APIResponse(Object data , int status, string message, string errorMessage="")
        {
            this.Data = data;
            this.Status = status;
            this.Message= message;
            this.ErrorMessage = errorMessage;

        }

        public APIResponse()
        {

        }

        public static implicit operator APIResponse(ReceiveContext<string> v)
        {
            throw new NotImplementedException();
        }
    }
}
