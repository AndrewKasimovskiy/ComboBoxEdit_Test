using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Markup;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;

namespace TestComboBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class GridViewModel : ViewModelBase
    {
        public ObservableCollection<ItemViewModel> Items
        {
            get { return GetProperty(() => Items); }
            set { SetProperty(() => Items, value); }
        }
        public GridViewModel()
        {
            Items = new ObservableCollection<ItemViewModel>();
            for (int i = 0; i < 50; i++)
            {
                Items.Add(new ItemViewModel() { Number = i, Text = "Text" + i, IsValid = i % 2 == 0 });
            }
        }

    }
    public class ItemViewModel : ViewModelBase
    {
        public string Text
        {
            get { return GetProperty(() => Text); }
            set { SetProperty(() => Text, value); }
        }
        public int Number
        {
            get { return GetProperty(() => Number); }
            set { SetProperty(() => Number, value); }
        }
        public bool IsValid
        {
            get { return GetProperty(() => IsValid); }
            set { SetProperty(() => IsValid, value); }
        }
    }

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

    public static class TextBlockEx
    {
        public static Inline GetFormattedText(DependencyObject obj)
        {
            return (Inline)obj.GetValue(FormattedTextProperty);
        }

        public static void SetFormattedText(DependencyObject obj, Inline value)
        {
            obj.SetValue(FormattedTextProperty, value);
        }

        public static readonly DependencyProperty FormattedTextProperty =
            DependencyProperty.RegisterAttached(
                "FormattedText",
                typeof(Inline),
                typeof(TextBlockEx),
                new PropertyMetadata(null, OnFormattedTextChanged));

        private static void OnFormattedTextChanged(
            DependencyObject o,
            DependencyPropertyChangedEventArgs e)
        {
            var textBlock = o as TextBlock;
            if (textBlock == null) return;

            var inline = (Inline)e.NewValue;
            textBlock.Inlines.Clear();
            textBlock.Inlines.Add(inline);
        }
    }
}
