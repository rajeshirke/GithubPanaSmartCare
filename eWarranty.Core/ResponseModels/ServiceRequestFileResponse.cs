using System;
using System.Collections.Generic;
using eWarranty.Core.Models;

namespace eWarranty.Core.ResponseModels
{
    public class ServiceRequestFileResponse
    {
        public int ServiceRequestFilesInfoId { get; set; }
        public long ServiceRequestId { get; set; }
        public int FileInfoId { get; set; } 
        public virtual FileInfoResponse FileInfo { get; set; }
    }
}
