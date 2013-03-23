using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CslaRepositoryTest.BusinessLayer;
using CslaRepositoryTest.Gui.Views;


namespace CslaRepositoryTest.Gui.Presenters
{


    public class OrderEditPresenter 
        : IOrderEditPresenter
    {

        private IOrderEditDataBinder _dataBinder;
        private IViewFactory _viewFactory;

        #region IOrderEditPresenter memebers

        public OrderEditPresenter(IOrderEditDataBinder dataBinder, IViewFactory viewFactory)
        {
            if (dataBinder == null)
                throw new ArgumentNullException("dataBinder");
            if (viewFactory == null)
                throw new ArgumentNullException("viewFactory");
            _dataBinder = dataBinder;
            _viewFactory = viewFactory;
        }

        public IOrderEditView View { get; set; }
        public IOrder Order { get; set; }

        public void OnViewLoad()
        {
            EnsureState();
            _dataBinder.BindUI(this);
        }

        public bool OnViewClosing(bool userClosing)
        {
            EnsureState();
            if (userClosing && Order.IsDirty)
            {
                var messageBoxView = _viewFactory.CreateMessageBoxView();
                return messageBoxView.ShowYesNo("Changes have not been saved.  Are you sure you want to continue?", "Order Not Saved");
            }
            _dataBinder.RebindUI(this, false, false);
            return true;
        }

        public void OnOkButtonClick()
        {
            EnsureState();
            _dataBinder.RebindUI(this, true, false);
            View.Close();
        }

        public void OnCancelButtonClick()
        {
            EnsureState();
            _dataBinder.RebindUI(this, false, true);
        }

        public void OnApplyButtonClick()
        {
            EnsureState();
            _dataBinder.RebindUI(this, true, true);
        }

        public void OnOrderChanged()
        {
            if (Order != null && View != null)
            {
                //set caption
                View.Caption = Order.IsNew ? "New Order" : "Edit Order " + Order.Id.ToString();
                if (Order.IsDirty)
                    View.Caption += " *";
                //enable/disable buttons
                View.OkButtonEnabled = Order.IsSavable;
                View.ApplyButtonEnabled = Order.IsSavable;
                View.CancelButtonEnabled = Order.IsDirty;
            }
        }

        #endregion

        private void EnsureState()
        {
            if (View == null)
                throw new InvalidOperationException("Missing View instance.");
            if (Order == null)
                throw new InvalidOperationException("Missing Order instance.");
        }

    }


}
