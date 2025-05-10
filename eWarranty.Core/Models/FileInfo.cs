using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class FileInfo
    {
        public FileInfo()
        {
            MessageTemplateFileInfoes = new HashSet<MessageTemplateFileInfo>();
            ProductFiles = new HashSet<ProductFile>();
        }

        public int FileInfoId { get; set; }
        public string FileName { get; set; }
        public int? FileTypeId { get; set; }
        public string MimeType { get; set; }
        public string Path { get; set; }

        public virtual FileType FileType { get; set; }
        public virtual ICollection<MessageTemplateFileInfo> MessageTemplateFileInfoes { get; set; }
        public virtual ICollection<ProductFile> ProductFiles { get; set; }
    }
}
