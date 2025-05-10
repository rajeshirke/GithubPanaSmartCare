using System;
using System.Runtime.Remoting.Contexts;
using Android.Content;
using eWarranty.DependencyServices;
using eWarranty.Droid.DependencyServices;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(MediaService))]
namespace eWarranty.Droid.DependencyServices
{
    public class MediaService : IMediaService
    {
        Android.Content.Context CurrentContext => CrossCurrentActivity.Current.Activity;

        public string GetBaseUrl()
        {
            return "";
        }

        public void SaveImageFromByte(byte[] imageByte, string filename)
        {
            try
            {
                Java.IO.File storagePath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures);
                string path = System.IO.Path.Combine(storagePath.ToString(), filename);
                System.IO.File.WriteAllBytes(path, imageByte);
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                mediaScanIntent.SetData(Android.Net.Uri.FromFile(new Java.IO.File(path)));
                CurrentContext.SendBroadcast(mediaScanIntent);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
