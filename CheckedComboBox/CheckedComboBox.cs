using System;
using System.Windows;
using DevExpress.Xpf.Editors;

namespace CheckedComboBox
{
    public class CheckedComboBox : ComboBoxEdit
    {
        public CheckedComboBox()
        {
            Resources = new ResourceDictionary() 
            { Source = new Uri("/CheckedComboBox;component/CheckedComboBox.xaml",
                                UriKind.RelativeOrAbsolute) };

            StyleSettings = new CheckedTokenComboBoxStyleSettings();
            StyleSettings.Style = Resources["StyleToken"] as Style;

            Style = Resources["HighLightComboBoxItem"] as Style;

            AutoComplete = true;
            FocusPopupOnOpen = false;
            IncrementalSearch = true;
            IncrementalFiltering = true;
            ImmediatePopup = true;
            ValidateOnTextInput = false;
            ValidateOnEnterKeyPressed = false;
        }
    }
}
