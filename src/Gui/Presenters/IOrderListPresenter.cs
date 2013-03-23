using System;
using CslaRepositoryTest.Gui.Views;


namespace CslaRepositoryTest.Gui.Presenters
{


    public interface IOrderListPresenter
    {
        IOrderListView View { get; set; }
        void OnViewLoad();
        void OnOrdersGridCellMouseDoubleClick();
        void OnDeleteButtonClick();
        void OnNewButtonClick();
    }


}
