using System;
using eWarranty.DependencyServices;
using eWarranty.iOS.DependencyServices;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(MediaService))]
namespace eWarranty.iOS.DependencyServices
{
    public class MediaService : IMediaService
    {
        public void SaveImageFromByte(byte[] imageByte, string fileName)
        {
            var imageData = new UIImage(NSData.FromArray(imageByte));
            imageData.SaveToPhotosAlbum((image, error) =>
            {
                //you can retrieve the saved UI Image as well if needed using  
                //var i = image as UIImage;  
                if (error != null)
                {
                    Console.WriteLine(error.ToString());
                }
            });
        }
        public string GetBaseUrl()
        {
           // return "";
             return NSBundle.MainBundle.BundlePath;
        }
    }
}
