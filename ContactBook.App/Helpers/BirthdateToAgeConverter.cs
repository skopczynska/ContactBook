using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace ContactBook.App.Helpers
{
    [ValueConversion(typeof(DateTime), typeof(String))]
    public class BirtdateToAgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime birthDate = (DateTime)value;
           
            return GetAge(birthDate);
        }

        private object GetAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (IsBeforeBirthdate(birthDate))
            {
                age--;
            }
            if (age < 0)
            {
                age++;
            }
            return age;

        }

        private bool IsBeforeBirthdate(DateTime birthDate)
        {
            return (birthDate.Month >= DateTime.Now.Month && birthDate.Day >= DateTime.Now.Day);
        }     
                
        

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
