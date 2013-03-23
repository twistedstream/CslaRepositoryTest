using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CslaRepositoryTest.BusinessLayer;
using CslaRepositoryTest.Gui.Views;


namespace CslaRepositoryTest.Gui.Presenters
{


    public class OrderEditDataBinder
        : IOrderEditDataBinder
    {

        #region IOrderEditDataBinder members

        public void BindUI(IOrderEditPresenter presenter)
        {
            if (presenter == null)
                throw new ArgumentNullException("presenter");
            presenter.Order.BeginEdit();
            presenter.View.SetOrderBindingSourceDataSource(presenter.Order);
        }

        public void RebindUI(IOrderEditPresenter presenter, bool saveObject, bool rebind)
        {
            if (presenter == null)
                throw new ArgumentNullException("presenter");
            //disable events
            presenter.View.RaiseOrderBindSourceChangeEvents= false;
            presenter.View.RaiseLineItemsBindingSourceChangeEvents = false;
            try
            {
                //unbind the UI
                presenter.View.UnbindLineItemsBindingSource(saveObject);
                presenter.View.UnbindOrderBindingSource(saveObject);
                presenter.View.SetLineItemsBindingSourceDataSource();
                //save or cancel changes
                if (saveObject)
                {
                    presenter.Order.ApplyEdit();
                    presenter.Order = presenter.Order.Save();
                }
                else
                    presenter.Order.CancelEdit();
            }
            finally
            {
                //rebind UI if required
                if (rebind)
                    this.BindUI(presenter);
                //restore events
                presenter.View.RaiseOrderBindSourceChangeEvents = true;
                presenter.View.RaiseLineItemsBindingSourceChangeEvents = true;
                //refresh the UI if rebinding
                if (rebind)
                {
                    presenter.View.ResetOrderBindingSourceBindings();
                    presenter.View.ResetLineItemsBindingSourceBindings();
                }
            }
        }

        #endregion

    }


}
