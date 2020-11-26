using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Editors;
using System.Collections.Generic;

namespace TestComboBox
{
    public class NotifyWrongValueBehavior : Behavior<ComboBoxEdit>
    {

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Validate += AssociatedObject_Validate;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.Validate -= AssociatedObject_Validate;
        }

        void AssociatedObject_Validate(object sender, ValidationEventArgs e)
        {
            if (e.Value == null || string.IsNullOrEmpty(e.Value.ToString()))
            {
                return;
            }


            var txt = e.Value as List<object>;
            var collection = (e.Source as ComboBoxEdit).Items;

            foreach (ComboBoxEditItem item in collection)
            {
                if (item.Content.ToString().Contains(txt[txt.Count - 1].ToString()))
                {
                    e.IsValid = true;
                    e.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.None;
                    e.ErrorContent = null;
                    return;
                }
            }

            e.IsValid = false;
            e.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            e.ErrorContent = "No one item matches the typed text";
        }
    }
}
