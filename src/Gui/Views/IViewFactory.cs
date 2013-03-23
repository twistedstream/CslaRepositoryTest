using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CslaRepositoryTest.BusinessLayer;


namespace CslaRepositoryTest.Gui.Views
{


    public interface IViewFactory
    {
        IStartupView CreateStartupView();
        IOrderEditView CreateOrderEditView(IOrder order);
        IMessageBoxView CreateMessageBoxView();
    }


}
