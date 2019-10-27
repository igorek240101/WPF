using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace AticaRevisorPcManager.View.Converter
{
    class BackUnitsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null) { 
            ComboBoxItem selectedItem = (ComboBoxItem)(value);
           return (string)(selectedItem.Content);}
            return null;
        }
    }
}
