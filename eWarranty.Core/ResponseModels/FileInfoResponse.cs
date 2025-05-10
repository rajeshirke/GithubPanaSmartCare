using System;
using eWarranty.Core.Models;

namespace eWarranty.Core.ResponseModels
{
    public class FileInfoResponse
    {
        public int FileInfoId { get; set; }
        public string FileName { get; set; }
        public int? FileTypeId { get; set; }
        public string MimeType { get; set; }
        public string Path { get; set; }

        public virtual FileType FileType { get; set; }
    }
}
