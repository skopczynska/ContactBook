using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ContactBook.App.ValidationRules
{
    public class ContactRequiredPropertyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                new ValidationResult(false, "Cannot be empty.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
