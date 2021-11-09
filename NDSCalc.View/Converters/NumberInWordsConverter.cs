using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace NDSCalc.View.Converters
{
    [ValueConversion(typeof(decimal), typeof(string))]
    public class NumberInWordsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is decimal amount))
            {
                if (!decimal.TryParse(string.Format(culture, "{0}", value), NumberStyles.Any, culture, out amount))
                {
                    return DependencyProperty.UnsetValue;
                }
            }

            return AmountInWords.CurrencyToTxt(amount, true);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static NumberInWordsConverter Instance { get; } = new NumberInWordsConverter();
    }

    [MarkupExtensionReturnType(typeof(NumberInWordsConverter))]
    public class NumberInWordsConverterExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
            => NumberInWordsConverter.Instance;
    }

}
