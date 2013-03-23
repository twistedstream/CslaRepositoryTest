using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CslaRepositoryTest.Gui.Views;
using CslaRepositoryTest.BusinessLayer;


namespace CslaRepositoryTest.Gui.Presenters
{
    
    public interface IOrderEditDataBinder
    {
        void BindUI(IOrderEditPresenter presenter);
        void RebindUI(IOrderEditPresenter presenter, bool saveObject, bool rebind);
    }

}
