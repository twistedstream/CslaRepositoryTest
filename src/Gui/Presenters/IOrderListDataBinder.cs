using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CslaRepositoryTest.Gui.Views;


namespace CslaRepositoryTest.Gui.Presenters
{


    public interface IOrderListDataBinder
    {
        void BindUI(IOrderListPresenter presenter);
    }


}
