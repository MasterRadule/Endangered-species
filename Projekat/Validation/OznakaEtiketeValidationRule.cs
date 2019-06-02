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
    class OznakaEtiketeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if ((string)value == ((MainWindow)Application.Current.MainWindow).OtvorenaEtiketaOznaka)
                return ValidationResult.ValidResult;
            return ((MainWindow)Application.Current.MainWindow).GlavniKontejner.Etikete.Where(e => e.Oznaka == (string)value).Count() != 0
                ? new ValidationResult(false, "Etiketa sa tom oznakom već postoji.")
                : ValidationResult.ValidResult;
        }
    }
}
