using System;
namespace eWarranty.DependencyServices
{
    public interface IMediaService
    {
        void SaveImageFromByte(byte[] imageByte, string filename);

        string GetBaseUrl();
    }
}
