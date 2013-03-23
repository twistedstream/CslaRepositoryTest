using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;


namespace CslaRepositoryTest.BusinessLayer
{

    
    /// <summary>
    /// The default implementation of the <see cref="IOrderFactory"/> interface.
    /// </summary>
    public sealed class OrderFactory
        : IOrderFactory
    {

        #region IOrderFactory Members

        IList<IOrderInfo> IOrderFactory.FetchInfoList()
        {
            return DataPortal.Fetch<OrderInfoCollection>();
        }

        IOrder IOrderFactory.Create()
        {
            return DataPortal.Create<Order>();
        }

        IOrder IOrderFactory.Fetch(int id)
        {
            return DataPortal.Fetch<Order>(new SingleCriteria<Order, int>(id));
        }

        void IOrderFactory.Delete(int id)
        {
            DataPortal.Delete<Order>(new SingleCriteria<Order, int>(id));
        }

        #endregion

    }


}
