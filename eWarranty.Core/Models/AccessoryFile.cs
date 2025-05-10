using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class AccessoryFile
    {
        public long AccessoryFileInfoId { get; set; }
        public long AccessoryMasterId { get; set; }
        public int FileInfoId { get; set; }

        public virtual AccessoryMaster AccessoryMaster { get; set; }
        public virtual FileInfo FileInfo { get; set; }
    }
}
