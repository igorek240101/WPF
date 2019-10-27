using AticaRevisorPcManager.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AticaRevisorPcManager.View.Converter
{
    class ElementInstrumentToUploadPropertyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
             if(value is ElementInstrumentToUpload)
            {
                if(System.Convert.ToInt32(parameter)==1)
                {
                    var item = value as ElementInstrumentToUpload;
                    if (item.InstrumnetHeader == null) return item.Nomenclature.Name;
                    else return item.InstrumnetHeader.Nomenclature.Name;
                }

                if (System.Convert.ToInt32(parameter) == 2)
                {
                    var item = value as ElementInstrumentToUpload;
                    if (item.InstrumnetHeader == null)
                    {
                     if(item.XKey==null)
                            return "Не задано";
                        else
                        {
                            return item.XKey;
                        }
                    }
                    else return item.InstrumnetHeader.XKey;
                }

            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
