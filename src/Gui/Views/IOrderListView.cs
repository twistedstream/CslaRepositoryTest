using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CslaRepositoryTest.Gui.Views
{


    public interface IOrderListView
    {
        object SelectedOrder { get; }
        void SetOrdersBindingSourceDataSource(object source);
    }


}
