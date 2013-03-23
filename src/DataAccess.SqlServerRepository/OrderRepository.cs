using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CslaRepositoryTest.Core;


namespace CslaRepositoryTest.DataAccess.SqlServerRepository
{


    public sealed class OrderRepository
        : IOrderRepository
    {

        #region IRepository<IOrderDto> implementation

        IOrderContext IRepository<IOrderContext>.CreateContext(bool isTransactional)
        {
            return new OrderContext(isTransactional);
        }

        #endregion

        #region IOrderRepository implementation

        IOrderDto IOrderRepository.CreateOrderDto()
        {
            return new Order();
        }

        ILineItemDto IOrderRepository.CreateLineItemDto()
        {
            return new LineItem();
        }

        #endregion

    }


}
