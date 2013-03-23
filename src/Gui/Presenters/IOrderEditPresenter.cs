using System;
using CslaRepositoryTest.BusinessLayer;
using CslaRepositoryTest.Gui.Views;


namespace CslaRepositoryTest.Gui.Presenters
{


    public interface IOrderEditPresenter
    {
        IOrderEditView View { get; set; }
        IOrder Order { get; set; }
        void OnViewLoad();
        bool OnViewClosing(bool userClosing);
        void OnOkButtonClick();
        void OnCancelButtonClick();
        void OnApplyButtonClick();
        void OnOrderChanged();
    }


}
