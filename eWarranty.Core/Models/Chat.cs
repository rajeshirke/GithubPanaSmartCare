using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class Chat
    {
        public long ChatId { get; set; }
        public long FromPersonId { get; set; }
        public DateTime ChatDate { get; set; }
        public long? ToPersonId { get; set; }
        public string Message { get; set; }
        public int? FileInfoId { get; set; }

        public virtual FileInfo FileInfo { get; set; }
        public virtual Person FromPerson { get; set; }
        public virtual Person ToPerson { get; set; }
    }
}
