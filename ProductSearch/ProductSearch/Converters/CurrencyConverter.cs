using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Data;

namespace ProductSearch.Converters
{
    [ValueConversion(typeof(double), typeof(string))] 
    public class CurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DependencyProperty.UnsetValue;

            return ((decimal)value).ToString("C2", Thread.CurrentThread.CurrentUICulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal result;
            var isConvertible = decimal.TryParse(value.ToString(), NumberStyles.Currency, Thread.CurrentThread.CurrentUICulture, out result);

            return isConvertible ? result : DependencyProperty.UnsetValue;
        }
    }
}
