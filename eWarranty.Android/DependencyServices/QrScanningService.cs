﻿using System;
using System.Threading.Tasks;
using eWarranty.DependencyServices;
using eWarranty.Droid.DependencyServices;
using Xamarin.Forms;
using ZXing.Mobile;

[assembly: Dependency(typeof(QrScanningService))]
namespace eWarranty.Droid.DependencyServices
{
    public class QrScanningService : IQrScanningService
    {
        public async Task<string> ScanAsync()
        {
            var optionsDefault = new MobileBarcodeScanningOptions();
            var optionsCustom = new MobileBarcodeScanningOptions();

            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Scan the QR Code",
                BottomText = "Please Wait",
            };

            var scanResult = await scanner.Scan(optionsCustom);
            return scanResult.Text;
        }
    }
}
