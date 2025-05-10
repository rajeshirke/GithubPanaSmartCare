using System;
namespace eWarranty.Core.ResponseModels
{
    public class ProductFileResponse
    {
        public long ProductModelFileInfoId { get; set; }
        public long ProductModelId { get; set; }
        public int FileInfoId { get; set; }
        #region Kumar
        public Uri ImagePath { get; set; }
        public string ImageLabelName { get; set; }
        #endregion
        public virtual FileInfoResponse FileInfo { get; set; }
    }
}
