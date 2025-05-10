using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ModelServiceManual
    {
        public long ModelServiceManualId { get; set; }
        public string ModelNumber { get; set; }
        public string ServiceManualNumber { get; set; }
        public int FileInfoId { get; set; }
        public int? ProductClassificationId { get; set; }

        public virtual FileInfo FileInfo { get; set; }
    }
}
