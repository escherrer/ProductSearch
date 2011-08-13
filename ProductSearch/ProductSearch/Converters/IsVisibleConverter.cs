using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ProductSearch.Converters
{
    public class IsVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isInverted = false;
            if (parameter != null)
                bool.TryParse(parameter.ToString(), out isInverted);

            bool isVisible;
            if (value != null && Boolean.TryParse(value.ToString(), out isVisible))
            {
                // Apply inversion
                isVisible = isInverted ? !isVisible : isVisible;

                // Return visibility
                return isVisible ? Visibility.Visible : Visibility.Hidden;
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
