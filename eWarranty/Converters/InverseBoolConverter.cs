using System;
using System.Globalization;
using Xamarin.Forms;

namespace eWarranty.Converters
{
    public class InverseBoolConverter : IValueConverter
    {
        public static InverseBoolConverter Create
        {
            get
            {
                return new InverseBoolConverter();
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !((bool)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
            //throw new NotImplementedException();
        }
    }
}
