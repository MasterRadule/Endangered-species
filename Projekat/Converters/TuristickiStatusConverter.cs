using Projekat.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Projekat.Converters
{
    class TuristickiStatusConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((TuristickiStatus)value)
            {
                case TuristickiStatus.DelimicnoHabituirana:
                    return "Delimično habituirana";
                case TuristickiStatus.Habituirana:
                    return "Habituirana";
                case TuristickiStatus.Izolovana:
                    return "Izolovana";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
