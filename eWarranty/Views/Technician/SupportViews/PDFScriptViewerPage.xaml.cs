using System;
using System.Collections.Generic;
using eWarranty.DependencyServices;
using Xamarin.Forms;

namespace eWarranty.Views.Technician.SupportViews
{
    public partial class PDFScriptViewerPage : ContentPage
    {
        public PDFScriptViewerPage(string base64Pdf)
        {
            InitializeComponent();
           var baseUrl = DependencyService.Get<IMediaService>().GetBaseUrl();
            html = html.Replace("SUSHIHANGOVER", base64Pdf);
            webView.Source = new HtmlWebViewSource
            {
                BaseUrl = baseUrl,
                Html = html
            };
        }
        string html = @"
<html>
<head> 
<script type=""text/javascript"" src=""pdfview/pdf.js""></script>
 <script type=""text/javascript"">
    window.onload=function(){
var pdfData = atob('SUSHIHANGOVER');
var pdfjsLib = window['pdfjs-dist/build/pdf'];
pdfjsLib.GlobalWorkerOptions.workerSrc = 'pdf.worker.js';
var loadingTask = pdfjsLib.getDocument({data: pdfData});
loadingTask.promise.then(function(pdf) {
  console.log('PDF loaded');
  var pageNumber = 1;
  pdf.getPage(pageNumber).then(function(page) {
    console.log('Page loaded');
    var scale = 1.5;
    var viewport = page.getViewport(scale);
    var canvas = document.getElementById('the-canvas');
    var context = canvas.getContext('2d');
    canvas.height = viewport.height;
    canvas.width = viewport.width;
    var renderContext = {
      canvasContext: context,
      viewport: viewport
    };
    var renderTask = page.render(renderContext);
    renderTask.then(function () {
      console.log('Page rendered');
    });
  });
}, function (reason) {
  console.error(reason);
});
    }
</script>
</head>
<body>

<canvas id=""the-canvas"" style=""border: 1px solid""></canvas>

</body>
</html>
";
    }
}
