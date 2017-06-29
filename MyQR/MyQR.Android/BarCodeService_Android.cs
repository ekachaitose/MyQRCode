using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyQR.Droid;
using Android.Media;

using Android.Graphics;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(BarCodeService_Android))]
namespace MyQR.Droid
{
   public class BarCodeService_Android :  IBarCodeService
    {
        public BarCodeService_Android()
        {

        }

        public System.IO.Stream GenerateBarCode(string text, int width = 500, int height = 500)
        {
            var barcodeWriter = new ZXing.Mobile.BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = width,
                    Height = height,
                    Margin = 10
                }
            };

            barcodeWriter.Renderer = new ZXing.Mobile.BitmapRenderer();
            var bitmap = barcodeWriter.Write(text);
            var stream = new MemoryStream();
            bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);  // this is the diff between iOS and Android
            stream.Position = 0;
            return stream;
        }
    }
}