using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public class FilesToUploadRequest
    {
        public int FileInfoId { get; set; }
        public string FileName { get; set; }
        public int FileTypeId { get; set; }
        public string MimeType { get; set; }
        public string Path { get; set; }
        public string base64StringImage { get; set; }
    }
}
