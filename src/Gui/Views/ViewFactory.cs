using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CslaRepositoryTest.BusinessLayer;
using CslaRepositoryTest.Gui.Presenters;


namespace CslaRepositoryTest.Gui.Views
{


    public sealed class ViewFactory
        : IViewFactory
    {

        private IOrderFactory _orderFactory;
        private IOrderListDataBinder _orderListDataBinder;
        private IOrderEditDataBinder _orderEditDataBinder;

        public ViewFactory(IOrderFactory orderFactory, IOrderListDataBinder orderListDataBinder, IOrderEditDataBinder orderEditDataBinder)
        {
            if (orderFactory == null)
                throw new ArgumentNullException("orderFactory");
            if (orderListDataBinder == null)
                throw new ArgumentNullException("orderListDataBinder");
            if (orderEditDataBinder == null)
                throw new ArgumentNullException("orderEditDataBinder");
            _orderFactory = orderFactory;
            _orderListDataBinder = orderListDataBinder;
            _orderEditDataBinder = orderEditDataBinder;
        }

        #region IViewFactory members

        public IStartupView CreateStartupView()
        {
            var presenter = new OrderListPresenter(_orderFactory, _orderListDataBinder, this);
            var view = new OrderListForm(presenter);
            presenter.View = view;
            return view;
        }

        public IOrderEditView CreateOrderEditView(IOrder order)
        {
            var presenter = new OrderEditPresenter(_orderEditDataBinder, this);
            var view = new OrderEditForm(presenter);
            presenter.Order = order;
            presenter.View = view;
            return view;
        }

        public IMessageBoxView CreateMessageBoxView()
        {
            var view = new MessageBoxView();
            return view;
        }

        #endregion
    }


}
