using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CslaRepositoryTest.BusinessLayer;
using CslaRepositoryTest.Gui.Views;


namespace CslaRepositoryTest.Gui.Presenters
{


    public class OrderListDataBinder
        : IOrderListDataBinder
    {

        private IOrderFactory _orderFactory;

        public OrderListDataBinder(IOrderFactory orderFactory)
        {
            if (orderFactory == null)
                throw new ArgumentNullException("orderFactory");
            _orderFactory = orderFactory;
        }

        #region IOrderListDataBinder members

        public void BindUI(IOrderListPresenter presenter)
        {
            if (presenter == null)
                throw new ArgumentNullException("presenter");
            var orders = _orderFactory.FetchInfoList();
            presenter.View.SetOrdersBindingSourceDataSource(orders);
        }

        #endregion

    }


}
