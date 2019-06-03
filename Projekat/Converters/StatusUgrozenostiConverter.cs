using Projekat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;

namespace Projekat.Converters
{
    class StatusUgrozenostiConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((StatusUgrozenosti)value)
            {
                case StatusUgrozenosti.KriticnoUgrozena:
                    return "Kritično ugrožena";
                case StatusUgrozenosti.BlizuRizika:
                    return "Blizu rizika";
                case StatusUgrozenosti.NajmanjegRizika:
                    return "Najmanjeg rizika";
                case StatusUgrozenosti.Ranjiva:
                    return "Ranjiva";
                case StatusUgrozenosti.Ugrozena:
                    return "Ugrožena";
                case StatusUgrozenosti.ZavisnaOdOcuvanjaStanista:
                    return "Zavisna od očuvanja staništa";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}