using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Projekat.Validation
{
    class OznakaVrsteValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Console.WriteLine(value);
            Console.WriteLine(((MainWindow)Application.Current.MainWindow).OtvorenaVrstaOznaka);
            if ((string)value == ((MainWindow)Application.Current.MainWindow).OtvorenaVrstaOznaka)
                return ValidationResult.ValidResult;
            return ((MainWindow)Application.Current.MainWindow).GlavniKontejner.Vrste.Where(v => v.Oznaka == (string) value).Count() != 0
                ? new ValidationResult(false, "Vrsta sa tom oznakom već postoji.")
                : ValidationResult.ValidResult;
        }
    }
}
