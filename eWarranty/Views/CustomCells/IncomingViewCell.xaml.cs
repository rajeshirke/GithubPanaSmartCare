using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageCircle.Forms.Plugin.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eWarranty.Views.CustomCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncomingViewCell : ViewCell
    {
        public IncomingViewCell()
        {
            InitializeComponent();
            //CircleImage circleImage = new CircleImage();
            //circleImage.HeightRequest = 35;
            //circleImage.WidthRequest = 35;
            //circleImage.BorderColor = Color.FromHex("03A9F4");
            //circleImage.Aspect = Aspect.AspectFill;
            //circleImage.HorizontalOptions = LayoutOptions.Center;
            //circleImage.VerticalOptions = LayoutOptions.Center;
            //circleImage.Source = "Default";
            //slImage.Children.Add(circleImage);
        }
    }
}
