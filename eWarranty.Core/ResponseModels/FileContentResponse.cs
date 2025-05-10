using System;
namespace eWarranty.Core.ResponseModels
{
    public class FileContentResponse
    {
        public string fileContents { get; set; }

        public string contentType { get; set; }

        public string fileDownloadName { get; set; }

        public string lastModified { get; set; }
    }
}
