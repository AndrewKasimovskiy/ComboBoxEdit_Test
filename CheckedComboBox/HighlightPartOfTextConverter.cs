using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Markup;

namespace CheckedComboBox
{
    public class HighlightPartOfTextConverter : MarkupExtension, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string searchThis = values[1] as string;
            string str = values[0] as string;
            Span span = new Span();
            if (!string.IsNullOrEmpty(str) && str.Contains(searchThis))
            {
                int index = str.IndexOf(searchThis);
                if (index >= 0)
                {
                    string before = str.Substring(0, index);
                    string after = str.Substring(index + searchThis.Length);
                    span.Inlines.Add(new Run() { Text = before });
                    span.Inlines.Add(new Run() { Text = searchThis, FontWeight = FontWeights.Bold });
                    span.Inlines.Add(new Run() { Text = after });
                }
            }
            else
            {
                span.Inlines.Add(new Run() { Text = str });
            }
            return span;
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
