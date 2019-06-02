using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Globalization;

namespace Projekat.Validation
{
    class OznakaTipaValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if ((string)value == ((MainWindow)Application.Current.MainWindow).OtvorenTipOznaka)
                return ValidationResult.ValidResult;
            return ((MainWindow)Application.Current.MainWindow).GlavniKontejner.Tipovi.Where(t => t.Oznaka == (string)value).Count() != 0
                ? new ValidationResult(false, "Tip sa tom oznakom već postoji.")
                : ValidationResult.ValidResult;
        }
    }
}
