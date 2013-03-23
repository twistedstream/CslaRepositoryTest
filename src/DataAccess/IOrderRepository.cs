using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CslaRepositoryTest.Core;


namespace CslaRepositoryTest.DataAccess
{


    //repository that handles the persistence of order entities and their children
    public interface IOrderRepository
        : IRepository<IOrderContext>
    {

        #region methods

        //creates an empty order DTO that can be used for order inserts or updates
        IOrderDto CreateOrderDto();

        //creates an empty line item DTO that can be used for order inserts or updates
        ILineItemDto CreateLineItemDto();

        #endregion

    }


}
