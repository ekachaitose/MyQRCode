using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyQR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyQRPage : ContentPage
    {
        public MyQRPage()
        {
            InitializeComponent();
        }

       async private void Scan_Clicked(object sender, EventArgs e)
        {
            // Initialize the scanner first so it can track the current context
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();
            if (result != null)
            {
                await DisplayAlert("Result", result.Text, "Close");
            }

        }
        private void Write_Clicked(object sender, EventArgs e)
        {
            Stream stream = DependencyService.Get<IBarCodeService>().GenerateBarCode("www.codemobiles.com");
            barcodeImage.Source = ImageSource.FromStream(() => { return stream; });
        }
    }
}