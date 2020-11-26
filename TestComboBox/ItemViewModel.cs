using DevExpress.Mvvm;

namespace TestComboBox
{
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
}
