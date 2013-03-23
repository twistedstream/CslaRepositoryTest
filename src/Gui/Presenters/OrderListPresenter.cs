using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CslaRepositoryTest.BusinessLayer;
using CslaRepositoryTest.Core;
using CslaRepositoryTest.Gui.Views;


namespace CslaRepositoryTest.Gui.Presenters
{


    public class OrderListPresenter 
        : IOrderListPresenter
    {

        private IOrderFactory _orderFactory;
        private IOrderListDataBinder _dataBinder;
        private IViewFactory _viewFactory;

        public OrderListPresenter(IOrderFactory orderFactory, IOrderListDataBinder dataBinder, IViewFactory viewFactory)
        {
            if (orderFactory == null)
                throw new ArgumentNullException("orderFactory");
            if (dataBinder == null)
                throw new ArgumentNullException("dataBinder");
            if (viewFactory == null)
                throw new ArgumentNullException("viewFactory");
            _orderFactory = orderFactory;
            _dataBinder = dataBinder;
            _viewFactory = viewFactory;
        }

        #region IOrderListPresenter members

        public IOrderListView View { get; set; }

        public void OnViewLoad()
        {
            EnsureState();
            _dataBinder.BindUI(this);
        }

        public void OnOrdersGridCellMouseDoubleClick()
        {
            EnsureState();
            var selectedOrder = (IOrderInfo)View.SelectedOrder;
            var order = _orderFactory.Fetch(selectedOrder.Id);
            var editView = _viewFactory.CreateOrderEditView(order);
            editView.Show();
            _dataBinder.BindUI(this);
        }

        public void OnDeleteButtonClick()
        {
            EnsureState();
            var confirmView = _viewFactory.CreateMessageBoxView();
            if (confirmView.ShowYesNo("Are you sure you want to delete this order?", "Orders"))
            {
                var selectedOrder = (IOrderInfo)View.SelectedOrder;
                _orderFactory.Delete(selectedOrder.Id);
                _dataBinder.BindUI(this);
            }
        }

        public void OnNewButtonClick()
        {
            EnsureState();
            var order = _orderFactory.Create();
            var editView = _viewFactory.CreateOrderEditView(order);
            editView.Show();
            _dataBinder.BindUI(this);
        }

        #endregion

        private void EnsureState()
        {
            if (View == null)
                throw new InvalidOperationException("Missing View instance.");
        }

    }


}
