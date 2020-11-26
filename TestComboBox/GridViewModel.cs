using System.Collections.ObjectModel;
using DevExpress.Mvvm;

namespace TestComboBox
{
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
}
