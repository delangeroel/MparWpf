using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MparWpf.Tests.Sorting.Screens.Screen1
{
    public class AmountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CultureInfo nlNLs = new CultureInfo("nl-NL");
            var dec = (decimal)value;
            return dec.ToString("N2", nlNLs);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
             
            return (string)value;
        }
    }
}
