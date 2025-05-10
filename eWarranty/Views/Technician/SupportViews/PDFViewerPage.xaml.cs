using System;
using System.Collections.Generic;
using eWarranty.DependencyServices;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.SupportViews
{
    public partial class PDFViewerPage : ContentPage
    {
        public string PageUrl { get; set; }
        public string FileType { get; set; }
        public PDFViewerPage(string url)
        {
            //url = "http://media.wuerth.com/stmedia/shop/catalogpages/LANG_it/1637048.pdf";
            InitializeComponent();
            DependencyService.Get<IClearCookies>().Clear();
            // WebViewSource webViewSource = new WebViewSource()
            //  wbPDF.Source = url;
            if (Device.RuntimePlatform == Device.Android)
            {
                wbPDF.Source = url;
               // pdfView.On<Android>().EnableZoomControls(true);
               // pdfView.On<Android>().DisplayZoomControls(false);
            }
            else
                wbPDF.Source = "https://drive.google.com/viewerng/viewer?embedded=true&url="+ url;

            PageUrl = url;
        }
        public PDFViewerPage(string url,string title,string filrtype="pdf")
        {
            //url = "http://media.wuerth.com/stmedia/shop/catalogpages/LANG_it/1637048.pdf";
            InitializeComponent();
            DependencyService.Get<IClearCookies>().Clear();
            // WebViewSource webViewSource = new WebViewSource()
            //  wbPDF.Source = url;
            Title = title;
            FileType = filrtype;
            if (FileType.Contains("image"))
            {
                wbPDF.Source = url;
            }
            else
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    wbPDF.Source = url;
                    // pdfView.On<Android>().EnableZoomControls(true);
                    // pdfView.On<Android>().DisplayZoomControls(false);
                }
                else
                    wbPDF.Source = "https://drive.google.com/viewerng/viewer?embedded=true&url=" + url;
            }
            PageUrl = url;
        }

        void wbPDF_Navigated(System.Object sender, Xamarin.Forms.WebNavigatedEventArgs e)
        {
            IsBusy = false;
            lblstatus.IsVisible = false;
            DependencyService.Get<IClearCookies>().Clear();
        }

        void wbPDF_PropertyChanging(System.Object sender, Xamarin.Forms.PropertyChangingEventArgs e)
        {
        }

        void MenuItem1_Clicked(System.Object sender, System.EventArgs e)
        {
            lblstatus.IsVisible = true;
            DependencyService.Get<IClearCookies>().Clear();
            if (FileType.Contains("image"))
            {
                wbPDF.Source = PageUrl;
            }
            else
            {
                wbPDF.Source = "https://drive.google.com/viewerng/viewer?embedded=true&url=" + PageUrl;
            }
        }
    }
}
