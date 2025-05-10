

using eWarranty.Core.Models;

namespace eWarranty.Core.RequestModels
{
    public class ChatRequest
    {
        public long FromPersonId { get; set; }
        public long? ToPersonId { get; set; }
        public string Message { get; set; }
        public FilesToUpload File { get; set; }

    }
}
