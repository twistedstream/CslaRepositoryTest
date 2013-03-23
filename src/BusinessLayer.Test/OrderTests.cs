using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using CslaRepositoryTest.DataAccess;
using NUnit.Framework.SyntaxHelpers;
using CslaRepositoryTest.Core;
using System.Linq.Expressions;


namespace CslaRepositoryTest.BusinessLayer.Test
{


    [TestFixture]
    public class OrderTests
        : TestBase
    {

        #region tests

        [Test]
        public void Order_Create_returns_new_Order()
        {
            var mocks = new MockRepository();
            using (mocks.Record())
            {
                base.MockRepository<IOrderContext>(mocks);
            }
            using (mocks.Playback())
            {
                //create new order
                IOrderFactory factory = new OrderFactory();
                var entity = factory.Create();
                Assert.That(entity.IsNew, Is.True);
            }
        }

        [Test]
        public void Order_Fetch_returns_old_Order_with_expected_data()
        {
            var mocks = new MockRepository();
            using (mocks.Record())
            {
                //mock DTO's
                var lineItemDto1 = mocks.StrictMock<ILineItemDto>();
                Expect.Call(lineItemDto1.Id).Return(200).Repeat.Any();
                Expect.Call(lineItemDto1.ProductName).Return("Widget A").Repeat.Any();
                Expect.Call(lineItemDto1.Price).Return(10M).Repeat.Any();
                Expect.Call(lineItemDto1.Quantity).Return(2).Repeat.Any();
                Expect.Call(lineItemDto1.Timestamp).Return(new byte[8]).Repeat.Any();
                var lineItemDto2 = mocks.StrictMock<ILineItemDto>();
                Expect.Call(lineItemDto2.Id).Return(201).Repeat.Any();
                Expect.Call(lineItemDto2.ProductName).Return("Widget B").Repeat.Any();
                Expect.Call(lineItemDto2.Price).Return(20.5M).Repeat.Any();
                Expect.Call(lineItemDto2.Quantity).Return(3).Repeat.Any();
                Expect.Call(lineItemDto2.Timestamp).Return(new byte[8]).Repeat.Any();
                var orderDto1 = mocks.StrictMock<IOrderDto>();
                Expect.Call(orderDto1.Id).Return(100).Repeat.Any();
                Expect.Call(orderDto1.Customer).Return("Bob").Repeat.Any();
                Expect.Call(orderDto1.Date).Return(DateTime.Parse("1/1/2008")).Repeat.Any();
                Expect.Call(orderDto1.ShippingCost).Return(5.5M).Repeat.Any();
                Expect.Call(orderDto1.Timestamp).Return(new byte[8]).Repeat.Any();
                Expect.Call(orderDto1.LineItems).Return(new[] { lineItemDto1, lineItemDto2 }).Repeat.Any();
                //mock read context
                IOrderContext readContext = mocks.StrictMock<IOrderContext>();
                Expect.Call(readContext.FetchSingleWithLineItems(100)).Return(orderDto1);
                readContext.Dispose();
                //mock repository
                var repository = base.MockRepository<IOrderContext>(mocks);
                Expect.Call(repository.CreateContext(false)).Return(readContext);
            }
            using (mocks.Playback())
            {
                //fetch existing order
                IOrderFactory factory = new OrderFactory();
                var entity = factory.Fetch(100);
                //test state of entity
                Assert.That(entity.IsNew, Is.False);
                Assert.That(entity.Id, Is.EqualTo(100));
                Assert.That(entity.Customer, Is.EqualTo("Bob"));
                Assert.That(entity.Date, Is.EqualTo(DateTime.Parse("1/1/2008")));
                Assert.That(entity.ShippingCost, Is.EqualTo(5.5M));
                //test state of items in child collection 
                var collection = entity.LineItems;
                Assert.That(collection, Is.Not.Null);
                Assert.That(collection.Count, Is.EqualTo(2));
                ILineItem item;
                item = collection[0];
                Assert.That(item.ProductName, Is.EqualTo("Widget A"));
                Assert.That(item.Price, Is.EqualTo(10M));
                Assert.That(item.Quantity, Is.EqualTo(2));
                item = collection[1];
                Assert.That(item.ProductName, Is.EqualTo("Widget B"));
                Assert.That(item.Price, Is.EqualTo(20.5M));
                Assert.That(item.Quantity, Is.EqualTo(3));
            }
        }

        [Test]
        public void Order_Save_Insert_calls_expected_repository_methods()
        {
            var mocks = new MockRepository();
            using (mocks.Record())
            {
                //mock DTO's
                var insertedOrderDto1 = mocks.StrictMock<IOrderDto>();
                insertedOrderDto1.Customer = "Bob";
                insertedOrderDto1.Date = DateTime.Parse("1/1/2008");
                insertedOrderDto1.ShippingCost = 5.5M;
                Expect.Call(insertedOrderDto1.Id).Return(100);
                Expect.Call(insertedOrderDto1.Timestamp).Return(new byte[8]);
                var insertedLineItemDto1 = mocks.StrictMock<ILineItemDto>();
                insertedLineItemDto1.OrderId = 100;
                insertedLineItemDto1.ProductName = "Widget A";
                insertedLineItemDto1.Price = 10M;
                insertedLineItemDto1.Quantity = 2;
                Expect.Call(insertedLineItemDto1.Id).Return(200);
                Expect.Call(insertedLineItemDto1.Timestamp).Return(new byte[8]);
                var insertedLineItemDto2 = mocks.StrictMock<ILineItemDto>();
                insertedLineItemDto2.OrderId = 100;
                insertedLineItemDto2.ProductName = "Widget B";
                insertedLineItemDto2.Price = 20.5M;
                insertedLineItemDto2.Quantity = 3;
                Expect.Call(insertedLineItemDto2.Id).Return(201);
                Expect.Call(insertedLineItemDto2.Timestamp).Return(new byte[8]);
                //mock transactional context
                IOrderContext trxContext = mocks.StrictMock<IOrderContext>();
                trxContext.InsertOrder(insertedOrderDto1);
                trxContext.InsertLineItem(insertedLineItemDto1);
                trxContext.InsertLineItem(insertedLineItemDto2);
                trxContext.CompleteTransaction();
                trxContext.Dispose();
                //mock repository
                var repository = base.MockRepository<IOrderContext>(mocks);
                Expect.Call(repository.CreateContext(true)).Return(trxContext);
                Expect.Call(repository.CreateOrderDto()).Return(insertedOrderDto1);
                Expect.Call(repository.CreateLineItemDto()).Return(insertedLineItemDto1);
                Expect.Call(repository.CreateLineItemDto()).Return(insertedLineItemDto2);
            }
            using (mocks.Playback())
            {
                //create new order
                IOrderFactory factory = new OrderFactory();
                var entity = factory.Create();
                //populate order
                entity.Customer = "Bob";
                entity.Date = DateTime.Parse("1/1/2008");
                entity.ShippingCost = 5.5M;
                //add line items
                ILineItem child;
                child = entity.LineItems.AddNew();
                child.ProductName = "Widget A";
                child.Price = 10M;
                child.Quantity = 2;
                child = entity.LineItems.AddNew();
                child.ProductName = "Widget B";
                child.Price = 20.5M;
                child.Quantity = 3;
                //test that entity is new and dirty
                Assert.That(entity.IsNew, Is.True);
                Assert.That(entity.IsDirty, Is.True);
                //perform inserts
                entity = entity.Save();
                //test that entity is old and clean
                Assert.That(entity.IsNew, Is.False);
                Assert.That(entity.IsDirty, Is.False);
            }
        }

        [Test]
        public void Order_Save_Update_with_changed_order_and_no_line_items_calls_expected_repository_methods()
        {
            var mocks = new MockRepository();
            using (mocks.Record())
            {
                var oldTimestamp = new byte[8];
                var newTimestamp = new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 };
                //mock DTO's
                var orderDto1 = mocks.StrictMock<IOrderDto>();
                Expect.Call(orderDto1.Id).Return(100).Repeat.Any();
                Expect.Call(orderDto1.Customer).Return("Bob").Repeat.Any();
                Expect.Call(orderDto1.Date).Return(DateTime.Parse("1/1/2008")).Repeat.Any();
                Expect.Call(orderDto1.ShippingCost).Return(5.5M).Repeat.Any();
                Expect.Call(orderDto1.Timestamp).Return(oldTimestamp).Repeat.Any();
                Expect.Call(orderDto1.LineItems).Return(new ILineItemDto[] { }).Repeat.Any();
                var updatedOrderDto1 = mocks.StrictMock<IOrderDto>();
                updatedOrderDto1.Id = 100;
                updatedOrderDto1.Customer = "Jim";
                updatedOrderDto1.Date = DateTime.Parse("1/1/2008");
                updatedOrderDto1.ShippingCost = 5.5M;
                updatedOrderDto1.Timestamp = oldTimestamp;
                Expect.Call(updatedOrderDto1.Timestamp).Return(newTimestamp);
                //mock read context
                IOrderContext readContext = mocks.StrictMock<IOrderContext>();
                Expect.Call(readContext.FetchSingleWithLineItems(100)).Return(orderDto1);
                readContext.Dispose();
                //mock transactional context
                IOrderContext trxContext = mocks.StrictMock<IOrderContext>();
                trxContext.UpdateOrder(updatedOrderDto1);
                trxContext.CompleteTransaction();
                trxContext.Dispose();
                //mock repository
                var repository = base.MockRepository<IOrderContext>(mocks);
                Expect.Call(repository.CreateContext(false)).Return(readContext);
                Expect.Call(repository.CreateContext(true)).Return(trxContext);
                Expect.Call(repository.CreateOrderDto()).Return(updatedOrderDto1);
            }
            using (mocks.Playback())
            {
                //fetch existing order
                IOrderFactory factory = new OrderFactory();
                var entity = factory.Fetch(100);
                //change order
                entity.Customer = "Jim";
                //test that entity is old and dirty
                Assert.That(entity.IsNew, Is.False);
                Assert.That(entity.IsDirty, Is.True);
                //perform update
                entity = entity.Save();
                //test that entity is old and clean
                Assert.That(entity.IsNew, Is.False);
                Assert.That(entity.IsDirty, Is.False);
            }
        }

        [Test]
        public void Order_Save_Update_with_unchanged_order_and_no_line_items_calls_expected_repository_methods()
        {
            var mocks = new MockRepository();
            using (mocks.Record())
            {
                //mock DTO's
                var orderDto1 = mocks.StrictMock<IOrderDto>();
                Expect.Call(orderDto1.Id).Return(100).Repeat.Any();
                Expect.Call(orderDto1.Customer).Return("Bob").Repeat.Any();
                Expect.Call(orderDto1.Date).Return(DateTime.Parse("1/1/2008")).Repeat.Any();
                Expect.Call(orderDto1.ShippingCost).Return(5.5M).Repeat.Any();
                Expect.Call(orderDto1.Timestamp).Return(new byte[8]).Repeat.Any();
                Expect.Call(orderDto1.LineItems).Return(new ILineItemDto[] { }).Repeat.Any();
                //mock read context
                IOrderContext readContext = mocks.StrictMock<IOrderContext>();
                Expect.Call(readContext.FetchSingleWithLineItems(100)).Return(orderDto1);
                readContext.Dispose();
                //mock repository
                var repository = base.MockRepository<IOrderContext>(mocks);
                Expect.Call(repository.CreateContext(false)).Return(readContext);
            }
            using (mocks.Playback())
            {
                //fetch existing order
                IOrderFactory factory = new OrderFactory();
                var entity = factory.Fetch(100);
                //change order, but to same value
                entity.Customer = "Bob";
                //test that entity is old and clean (since there were no changes)
                Assert.That(entity.IsNew, Is.False);
                Assert.That(entity.IsDirty, Is.False);
                //perform update
                entity = entity.Save();
                //test that entity is old and clean
                Assert.That(entity.IsNew, Is.False);
                Assert.That(entity.IsDirty, Is.False);
            }
        }

        [Test]
        public void Order_Save_Update_with_changed_line_items_calls_expected_repository_methods()
        {
            var mocks = new MockRepository();
            using (mocks.Record())
            {
                var oldTimestamp = new byte[8];
                var newTimestamp = new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 };
                //mock DTO's
                var lineItemDto1 = mocks.StrictMock<ILineItemDto>();
                Expect.Call(lineItemDto1.Id).Return(200).Repeat.Any();
                Expect.Call(lineItemDto1.ProductName).Return("Widget A").Repeat.Any();
                Expect.Call(lineItemDto1.Price).Return(10M).Repeat.Any();
                Expect.Call(lineItemDto1.Quantity).Return(2).Repeat.Any();
                Expect.Call(lineItemDto1.Timestamp).Return(oldTimestamp).Repeat.Any();
                var lineItemDto2 = mocks.StrictMock<ILineItemDto>();
                Expect.Call(lineItemDto2.Id).Return(201).Repeat.Any();
                Expect.Call(lineItemDto2.ProductName).Return("Widget B").Repeat.Any();
                Expect.Call(lineItemDto2.Price).Return(20.5M).Repeat.Any();
                Expect.Call(lineItemDto2.Quantity).Return(3).Repeat.Any();
                Expect.Call(lineItemDto2.Timestamp).Return(oldTimestamp).Repeat.Any();
                var orderDto1 = mocks.StrictMock<IOrderDto>();
                Expect.Call(orderDto1.Id).Return(100).Repeat.Any();
                Expect.Call(orderDto1.Customer).Return("Bob").Repeat.Any();
                Expect.Call(orderDto1.Date).Return(DateTime.Parse("1/1/2008")).Repeat.Any();
                Expect.Call(orderDto1.ShippingCost).Return(5.5M).Repeat.Any();
                Expect.Call(orderDto1.Timestamp).Return(oldTimestamp).Repeat.Any();
                Expect.Call(orderDto1.LineItems).Return(new[] { lineItemDto1, lineItemDto2 }).Repeat.Any();
                var updatedLineItemDto2 = mocks.StrictMock<ILineItemDto>();
                updatedLineItemDto2.Id = 200;
                updatedLineItemDto2.OrderId = 100;
                updatedLineItemDto2.ProductName = "Widget A+";
                updatedLineItemDto2.Price = 10M;
                updatedLineItemDto2.Quantity = 2;
                updatedLineItemDto2.Timestamp = oldTimestamp;
                Expect.Call(updatedLineItemDto2.Timestamp).Return(newTimestamp);
                var instertedLineItemDto3 = mocks.StrictMock<ILineItemDto>();
                instertedLineItemDto3.OrderId = 100;
                instertedLineItemDto3.ProductName = "Widget C";
                instertedLineItemDto3.Price = 15.1M;
                instertedLineItemDto3.Quantity = 4;
                Expect.Call(instertedLineItemDto3.Id).Return(202);
                Expect.Call(instertedLineItemDto3.Timestamp).Return(newTimestamp);
                //mock read context
                IOrderContext readContext = mocks.StrictMock<IOrderContext>();
                Expect.Call(readContext.FetchSingleWithLineItems(100)).Return(orderDto1);
                readContext.Dispose();
                //mock transactional context
                IOrderContext trxContext = mocks.StrictMock<IOrderContext>();
                trxContext.UpdateLineItem(updatedLineItemDto2);
                trxContext.DeleteLineItem(201, 100);
                trxContext.InsertLineItem(instertedLineItemDto3);
                trxContext.CompleteTransaction();
                trxContext.Dispose();
                //mock repository
                var repository = base.MockRepository<IOrderContext>(mocks);
                Expect.Call(repository.CreateContext(false)).Return(readContext);
                Expect.Call(repository.CreateContext(true)).Return(trxContext);
                Expect.Call(repository.CreateLineItemDto()).Return(updatedLineItemDto2);
                Expect.Call(repository.CreateLineItemDto()).Return(instertedLineItemDto3);
            }
            using (mocks.Playback())
            {
                //fetch existing order
                IOrderFactory factory = new OrderFactory();
                var entity = factory.Fetch(100);
                ILineItem child;
                //change line item 1
                child = entity.LineItems[0];
                child.ProductName = "Widget A+";
                //delete line item 2
                entity.LineItems.RemoveAt(1);
                //add new line item 3
                child = entity.LineItems.AddNew();
                child.ProductName = "Widget C";
                child.Price = 15.1M;
                child.Quantity = 4;
                //test that entity is old and dirty
                Assert.That(entity.IsNew, Is.False);
                Assert.That(entity.IsDirty, Is.True);
                //perform update
                entity = entity.Save();
                //test that entity is old and clean
                Assert.That(entity.IsNew, Is.False);
                Assert.That(entity.IsDirty, Is.False);
            }
        }

        [Test]
        public void Order_Save_Delete_calls_expected_repository_methods()
        {
            var mocks = new MockRepository();
            using (mocks.Record())
            {
                //mock DTO's
                var orderDto1 = mocks.StrictMock<IOrderDto>();
                Expect.Call(orderDto1.Id).Return(100).Repeat.Any();
                Expect.Call(orderDto1.Customer).Return("Bob").Repeat.Any();
                Expect.Call(orderDto1.Date).Return(DateTime.Parse("1/1/2008")).Repeat.Any();
                Expect.Call(orderDto1.ShippingCost).Return(5.5M).Repeat.Any();
                Expect.Call(orderDto1.Timestamp).Return(new byte[8]).Repeat.Any();
                Expect.Call(orderDto1.LineItems).Return(new ILineItemDto[] { }).Repeat.Any();
                //mock read context
                IOrderContext readContext = mocks.StrictMock<IOrderContext>();
                Expect.Call(readContext.FetchSingleWithLineItems(100)).Return(orderDto1);
                readContext.Dispose();
                //mock transactional context
                IOrderContext trxContext = mocks.StrictMock<IOrderContext>();
                trxContext.DeleteOrder(100);
                trxContext.CompleteTransaction();
                trxContext.Dispose();
                //mock repository
                var repository = base.MockRepository<IOrderContext>(mocks);
                Expect.Call(repository.CreateContext(false)).Return(readContext);
                Expect.Call(repository.CreateContext(true)).Return(trxContext);
            }
            using (mocks.Playback())
            {
                //fetch existing order
                IOrderFactory factory = new OrderFactory();
                var entity = factory.Fetch(100);
                //test entity is old
                Assert.That(entity.IsNew, Is.False);
                //test the delete
                entity.Delete();
                entity = entity.Save();
                Assert.That(entity.IsNew, Is.True);
            }
        }

        [Test]
        public void Order_Delete_calls_expected_repository_methods()
        {
            var mocks = new MockRepository();
            using (mocks.Record())
            {
                //mock transactional context
                IOrderContext trxContext = mocks.StrictMock<IOrderContext>();
                trxContext.DeleteOrder(100);
                trxContext.CompleteTransaction();
                trxContext.Dispose();
                //mock repository
                var repository = base.MockRepository<IOrderContext>(mocks);
                Expect.Call(repository.CreateContext(true)).Return(trxContext);
            }
            using (mocks.Playback())
            {
                //delete order
                IOrderFactory factory = new OrderFactory();
                factory.Delete(100);
            }
        }

        #endregion

    }


}
