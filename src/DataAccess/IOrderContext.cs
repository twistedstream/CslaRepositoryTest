using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CslaRepositoryTest.Core;


namespace CslaRepositoryTest.DataAccess
{


    //context for order and line item data access
    public interface IOrderContext
        : IContext
    {

        #region methods

        IEnumerable<IOrderInfoDto> FetchInfoList();

        IOrderDto FetchSingleWithLineItems(int id);

        void InsertOrder(IOrderDto newOrder);

        void UpdateOrder(IOrderDto existingOrder);

        void DeleteOrder(int id);

        void InsertLineItem(ILineItemDto newLineItem);

        void UpdateLineItem(ILineItemDto existingLineItem);

        void DeleteLineItem(int id, int orderId);

        #endregion

    }


}
