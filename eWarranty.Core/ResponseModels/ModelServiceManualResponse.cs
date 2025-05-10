using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{

    public class ServiceManualModelResponse
    {
        public long ModelServiceManualId { get; set; }
        public string ModelNumber { get; set; }
    }
    public class ModelServiceManualResponse
    {
        public long ModelServiceManualId { get; set; }
        public string ModelNumber { get; set; }
        public string ServiceManualNumber { get; set; }
        public string FileName { get; set; }
        public string FileTypeName { get; set; }
        public string MimeType { get; set; }
        public string Path { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int ProductClassificationId { get; set; }
        
        //public string ProductClassificationName { get; set; }
    }
}
