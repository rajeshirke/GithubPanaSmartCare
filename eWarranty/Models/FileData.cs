using System;
using System.IO;

namespace eWarranty.Models
{
    public class FileData
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string string64baseData { get; set; }
        public Stream imgStream { get; set; }
    }
}
