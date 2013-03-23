using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CslaRepositoryTest.BusinessLayer;
using Rhino.Mocks;
using CslaRepositoryTest.Gui.Presenters;
using CslaRepositoryTest.Gui.Views;


namespace CslaRepositoryTest.Gui.Test
{


    [TestFixture]
    public class OrderListDataBinderTests
    {

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_throws_exception_with_null_orderFactory()
        {
            //arrange
            //act, assert
            var target = new OrderListDataBinder(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BindUI_throws_exception_with_null_view()
        {
            //arrange
            var orderFactory = MockRepository.GenerateStub<IOrderFactory>();
            var target = new OrderListDataBinder(orderFactory);
            //act, assert
            target.BindUI(null);
        }

        [Test]
        public void BindUI_fetches_orders_from_business_layer_and_binds_them_to_view()
        {
            //arrange
            var orders = new IOrderInfo[] { };
            var orderFactory = MockRepository.GenerateMock<IOrderFactory>();
            var view = MockRepository.GenerateMock<IOrderListView>();
            var presenter = MockRepository.GenerateMock<IOrderListPresenter>();
            var target = new OrderListDataBinder(orderFactory);
            orderFactory.Expect(x => x.FetchInfoList())
                .Return(orders);
            presenter.Expect(x => x.View)
                .Return(view);
            view.Expect(x => x.SetOrdersBindingSourceDataSource(orders));
            //act
            target.BindUI(presenter);
            //assert
            orderFactory.VerifyAllExpectations();
            view.VerifyAllExpectations();
        }

    }


}
