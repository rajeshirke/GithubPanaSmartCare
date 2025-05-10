using System;
namespace eWarranty.DependencyServices
{
    public interface IImageResizer
    {
        byte[] ResizeImage(byte[] imageData, double width, double height);
    }
}
