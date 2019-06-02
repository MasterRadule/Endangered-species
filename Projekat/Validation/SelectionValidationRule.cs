﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Projekat.Validation
{
    class SelectionValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return value == null
                ? new ValidationResult(false, "Ništa nije odabrano.")
                : ValidationResult.ValidResult;
        }
    }
}
