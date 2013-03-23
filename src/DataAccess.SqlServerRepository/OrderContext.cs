using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using CslaRepositoryTest.Core;


namespace CslaRepositoryTest.DataAccess.SqlServerRepository
{


    public sealed class OrderContext
        : IOrderContext
    {

        private OrdersDataContext _db;
        private TransactionScope _ts;

        public OrderContext(bool isTransactional)
        {
            _db = new OrdersDataContext();
            if (isTransactional)
                _ts = new TransactionScope();
        }

        #region IContext members

        void IContext.CompleteTransaction()
        {
            if (_ts != null)
                _ts.Complete();
        }

        #endregion

        #region IOrderContext members

        IEnumerable<IOrderInfoDto> IOrderContext.FetchInfoList()
        {
            var query =
                from o in _db.Orders
                orderby o.Date
                select new OrderInfoData
                {
                    Id = o.Id,
                    Customer = o.Customer,
                    Date = o.Date
                };
            return query.Cast<IOrderInfoDto>();
        }

        private class OrderInfoData
            : IOrderInfoDto
        {
            public int Id { get; set; }
            public string Customer { get; set; }
            public DateTime Date { get; set; }
        }

        IOrderDto IOrderContext.FetchSingleWithLineItems(int id)
        {
            //configure context to automatically load child LineItems table
            var options = new DataLoadOptions();
            options.LoadWith<Order>(o => o.LineItems);
            _db.LoadOptions = options;
            //perform LINQ to SQL query
            var query =
                from o in _db.Orders
                where o.Id == id
                select o;
            return query.Single();
        }

        void IOrderContext.InsertOrder(IOrderDto newOrder)
        {
            //call sproc to insert order
            int? id = null;
            Binary timestamp = null;
            _db.insert_order(
                ref id,
                newOrder.Customer,
                newOrder.Date,
                newOrder.ShippingCost, 
                ref timestamp);
            //populate DTO with ID and timestamp returned from sproc
            newOrder.Id = id.Value;
            newOrder.Timestamp = timestamp.ToArray();
        }

        void IOrderContext.UpdateOrder(IOrderDto existingOrder)
        {
            //call sproc to update order
            Binary newTimestamp = null;
            _db.update_order(
                existingOrder.Id,
                existingOrder.Customer,
                existingOrder.Date,
                existingOrder.ShippingCost,
                existingOrder.Timestamp, 
                ref newTimestamp);
            //populate DTO with new timestamp returned from sproc
            existingOrder.Timestamp = newTimestamp.ToArray();
        }

        void IOrderContext.DeleteOrder(int id)
        {
            //call sproc to delete order
            _db.delete_order(id);
        }

        void IOrderContext.InsertLineItem(ILineItemDto newLineItem)
        {
            //call sproc to insert line item
            int? id = null;
            Binary timestamp = null;
            _db.insert_line_item(
                ref id, 
                newLineItem.OrderId,
                newLineItem.ProductName,
                newLineItem.Price,
                newLineItem.Quantity, 
                ref timestamp);
            //populate DTO with ID and timestamp returned from sproc
            newLineItem.Id = id.Value;
            newLineItem.Timestamp = timestamp.ToArray();
        }

        void IOrderContext.UpdateLineItem(ILineItemDto existingLineItem)
        {
            //call sproc to update line item
            Binary newTimestamp = null;
            _db.update_line_item(
                existingLineItem.Id,
                existingLineItem.OrderId,
                existingLineItem.ProductName,
                existingLineItem.Price,
                existingLineItem.Quantity,
                existingLineItem.Timestamp,
                ref newTimestamp);
            //populate DTO with new timestamp returned from sproc
            existingLineItem.Timestamp = newTimestamp.ToArray();
        }

        void IOrderContext.DeleteLineItem(int id, int orderId)
        {
            //call sproc to delete line item
            _db.delete_line_item(id, orderId);
        }

        #endregion

        #region IDisposable members

        //Dispose
        void IDisposable.Dispose()
        {
            if (_ts != null)
                _ts.Dispose();
            _db.Dispose();
        }

        #endregion

    }


}
