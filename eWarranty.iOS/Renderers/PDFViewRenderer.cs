using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using eWarranty.Controls;
using eWarranty.iOS.Renderers;
using Foundation;

using UIKit;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PDFView), typeof(PDFViewRenderer))]
namespace eWarranty.iOS.Renderers
{
    public class PDFViewRenderer : ViewRenderer<PDFView, WKWebView>, IWKScriptMessageHandler
    {
        public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
        {
           // throw new NotImplementedException();
            
          //  Element.InvokeCallback(message?.Body?.ToString());
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == PDFView.UriProperty.PropertyName)
            {
                var customWebView = Element as PDFView;
                string fileName = Path.Combine(NSBundle.MainBundle.BundlePath, string.Format("Content/{0}", WebUtility.UrlEncode(customWebView.Uri)));
                Control.LoadRequest(new NSUrlRequest(new NSUrl(fileName, false)));
                Control.Reload();
            }
        }
        //protected override void OnElementChanged(VisualElementChangedEventArgs e)
        //{
        //    base.OnElementChanged(e);

        //    if (NativeView != null && e.NewElement != null)
        //    {
        //        var pdfControl = NativeView as UIWebView;

        //        if (pdfControl == null)
        //            return;

        //        pdfControl.ScalesPageToFit = true;
        //    }
        //}


    }
}