using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Mocks;
using CslaRepositoryTest.BusinessLayer;
using NUnit.Framework;
using CslaRepositoryTest.Core;
using CslaRepositoryTest.Gui.Presenters;
using CslaRepositoryTest.Gui.Views;


namespace CslaRepositoryTest.Gui.Test
{


    [TestFixture]
    public class OrderListPresenterTests
        : TestBase
    {

        #region tests

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_throws_exception_with_null_orderFactory()
        {
            //arrange
            var dataBinder = MockRepository.GenerateStub<IOrderListDataBinder>();
            var viewFactory = MockRepository.GenerateStub<IViewFactory>();
            //act, assert
            var target = new OrderListPresenter(null, dataBinder, viewFactory);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_throws_exception_with_null_dataBinder()
        {
            //arrange
            var orderFactory = MockRepository.GenerateStub<IOrderFactory>();
            var viewFactory = MockRepository.GenerateStub<IViewFactory>();
            //act, assert
            var target = new OrderListPresenter(orderFactory, null, viewFactory);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_throws_exception_with_null_viewFactory()
        {
            //arrange
            var orderFactory = MockRepository.GenerateStub<IOrderFactory>();
            var dataBinder = MockRepository.GenerateStub<IOrderListDataBinder>();
            //act, assert
            var target = new OrderListPresenter(orderFactory, dataBinder, null);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void OnViewLoad_throws_exception_with_null_View()
        {
            //arrange
            var orderFactory = MockRepository.GenerateStub<IOrderFactory>();
            var dataBinder = MockRepository.GenerateStub<IOrderListDataBinder>();
            var viewFactory = MockRepository.GenerateStub<IViewFactory>();
            var target = new OrderListPresenter(orderFactory, dataBinder, viewFactory);
            //act, assert
            target.OnViewLoad();
        }

        [Test]
        public void OnViewLoad_binds_UI()
        {
            //arrange
            var view = MockRepository.GenerateStub<IOrderListView>();
            var orderFactory = MockRepository.GenerateStub<IOrderFactory>();
            var dataBinder = MockRepository.GenerateMock<IOrderListDataBinder>();
            var viewFactory = MockRepository.GenerateStub<IViewFactory>();
            var target = new OrderListPresenter(orderFactory, dataBinder, viewFactory);
            target.View = view;
            dataBinder.Expect(x => x.BindUI(target));
            //act
            target.OnViewLoad();
            //assert
            dataBinder.VerifyAllExpectations();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void OnOrdersGridCellMouseDoubleClick_throws_exception_with_null_View()
        {
            //arrange
            var orderFactory = MockRepository.GenerateStub<IOrderFactory>();
            var dataBinder = MockRepository.GenerateStub<IOrderListDataBinder>();
            var viewFactory = MockRepository.GenerateStub<IViewFactory>();
            var target = new OrderListPresenter(orderFactory, dataBinder, viewFactory);
            //act, assert
            target.OnOrdersGridCellMouseDoubleClick();
        }

        [Test]
        public void OnOrdersGridCellMouseDoubleClick_fetches_selected_order_from_business_layer_and_opens_order_edit_view_and_binds_UI()
        {
            //arrange
            var orderFactory = MockRepository.GenerateMock<IOrderFactory>();
            var dataBinder = MockRepository.GenerateMock<IOrderListDataBinder>();
            var viewFactory = MockRepository.GenerateMock<IViewFactory>();
            var view = MockRepository.GenerateMock<IOrderListView>();
            var selectedOrder = MockRepository.GenerateStub<IOrderInfo>();
            var order = MockRepository.GenerateStub<IOrder>();
            var editView = MockRepository.GenerateMock<IOrderEditView>();
            var target = new OrderListPresenter(orderFactory, dataBinder, viewFactory);
            target.View = view;
            view.Expect(x => x.SelectedOrder)
                .Return(selectedOrder);
            selectedOrder.Stub(x => x.Id)
                .Return(1);
            orderFactory.Expect(x => x.Fetch(1))
                .Return(order);
            viewFactory.Expect(x => x.CreateOrderEditView(order))
                .Return(editView);
            editView.Expect(x => x.Show());
            dataBinder.Expect(x => x.BindUI(target));
            //act
            target.OnOrdersGridCellMouseDoubleClick();
            //assert
            view.VerifyAllExpectations();
            orderFactory.VerifyAllExpectations();
            editView.VerifyAllExpectations();
            dataBinder.VerifyAllExpectations();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void OnDeleteButtonClick_throws_exception_with_null_View()
        {
            //arrange
            var orderFactory = MockRepository.GenerateStub<IOrderFactory>();
            var dataBinder = MockRepository.GenerateStub<IOrderListDataBinder>();
            var viewFactory = MockRepository.GenerateStub<IViewFactory>();
            var target = new OrderListPresenter(orderFactory, dataBinder, viewFactory);
            //act, assert
            target.OnDeleteButtonClick();
        }

        [Test]
        public void OnDeleteButtonClick_when_user_answers_yes_to_prompt_deletes_selected_order_from_business_layer_and_binds_UI()
        {
            //arrange
            var orderFactory = MockRepository.GenerateMock<IOrderFactory>();
            var dataBinder = MockRepository.GenerateMock<IOrderListDataBinder>();
            var viewFactory = MockRepository.GenerateStub<IViewFactory>();
            var confirmView = MockRepository.GenerateMock<IMessageBoxView>();
            var view = MockRepository.GenerateMock<IOrderListView>();
            var selectedOrder = MockRepository.GenerateStub<IOrderInfo>();
            var target = new OrderListPresenter(orderFactory, dataBinder, viewFactory);
            target.View = view;
            viewFactory.Expect(x => x.CreateMessageBoxView())
                .Return(confirmView);
            confirmView.Expect(x => x.ShowYesNo(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(true);
            view.Expect(x => x.SelectedOrder)
                .Return(selectedOrder);
            selectedOrder.Stub(x => x.Id)
                .Return(1);
            orderFactory.Expect(x => x.Delete(1));
            dataBinder.Expect(x => x.BindUI(target));
            //act
            target.OnDeleteButtonClick();
            //assert
            viewFactory.VerifyAllExpectations();
            confirmView.VerifyAllExpectations();
            view.VerifyAllExpectations();
            orderFactory.VerifyAllExpectations();
            dataBinder.VerifyAllExpectations();
        }

        [Test]
        public void OnDeleteButtonClick_when_user_answers_no_to_prompt_nothing_else_happens()
        {
            //arrange
            var orderFactory = MockRepository.GenerateMock<IOrderFactory>();
            var dataBinder = MockRepository.GenerateMock<IOrderListDataBinder>();
            var viewFactory = MockRepository.GenerateStub<IViewFactory>();
            var confirmView = MockRepository.GenerateMock<IMessageBoxView>();
            var view = MockRepository.GenerateMock<IOrderListView>();
            var target = new OrderListPresenter(orderFactory, dataBinder, viewFactory);
            target.View = view;
            viewFactory.Expect(x => x.CreateMessageBoxView())
                .Return(confirmView);
            confirmView.Expect(x => x.ShowYesNo(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(false);
            //act
            target.OnDeleteButtonClick();
            //assert
            viewFactory.VerifyAllExpectations();
            confirmView.VerifyAllExpectations();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void OnNewButtonClick_throws_exception_with_null_View()
        {
            //arrange
            var orderFactory = MockRepository.GenerateStub<IOrderFactory>();
            var dataBinder = MockRepository.GenerateStub<IOrderListDataBinder>();
            var viewFactory = MockRepository.GenerateStub<IViewFactory>();
            var target = new OrderListPresenter(orderFactory, dataBinder, viewFactory);
            //act, assert
            target.OnNewButtonClick();
        }

        [Test]
        public void OnNewButtonClick_creates_new_order_from_business_layer_and_opens_order_edit_view_and_binds_UI()
        {
            //arrange
            var orderFactory = MockRepository.GenerateMock<IOrderFactory>();
            var dataBinder = MockRepository.GenerateMock<IOrderListDataBinder>();
            var viewFactory = MockRepository.GenerateMock<IViewFactory>();
            var view = MockRepository.GenerateStub<IOrderListView>();
            var order = MockRepository.GenerateStub<IOrder>();
            var editView = MockRepository.GenerateMock<IOrderEditView>();
            var target = new OrderListPresenter(orderFactory, dataBinder, viewFactory);
            target.View = view;
            orderFactory.Expect(x => x.Create())
                .Return(order);
            viewFactory.Expect(x => x.CreateOrderEditView(order))
                .Return(editView);
            editView.Expect(x => x.Show());
            dataBinder.Expect(x => x.BindUI(target));
            //act
            target.OnNewButtonClick();
            //assert
            orderFactory.VerifyAllExpectations();
            viewFactory.VerifyAllExpectations();
            editView.VerifyAllExpectations();
            dataBinder.VerifyAllExpectations();
        }

        #endregion

    }


}
