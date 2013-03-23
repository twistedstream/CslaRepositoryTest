using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CslaRepositoryTest.BusinessLayer;


namespace CslaRepositoryTest.Gui.Views
{

    public interface IOrderEditView
    {
        void Show();
        void Close();
        void SetOrderBindingSourceDataSource(object source);
        void SetLineItemsBindingSourceDataSource();
        bool RaiseOrderBindSourceChangeEvents { get; set; }
        bool RaiseLineItemsBindingSourceChangeEvents { get; set; }
        void UnbindOrderBindingSource(bool apply);
        void UnbindLineItemsBindingSource(bool apply);
        void ResetOrderBindingSourceBindings();
        void ResetLineItemsBindingSourceBindings();
        string Caption { get; set; }
        bool OkButtonEnabled { get; set; }
        bool ApplyButtonEnabled { get; set; }
        bool CancelButtonEnabled { get; set; }
    }

}
