using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CslaRepositoryTest.BusinessLayer
{


    /// <summary>
    /// A factory object that can create order business objects.
    /// </summary>
    public interface IOrderFactory
    {

        #region factory methods

        /// <summary>
        /// Fetches a all of the orders in the database.
        /// </summary>
        /// <returns>
        /// A collection of <see cref="IOrderInfo"/> objects.
        /// </returns>
        IList<IOrderInfo> FetchInfoList();

        /// <summary>
        /// Creates a new order object, which, when saved, 
        /// will be inserted into the database.
        /// </summary>
        /// <returns>
        /// The new <see cref="IOrder"/> instance.
        /// </returns>
        IOrder Create();

        /// <summary>
        /// Fetches a single existing order from the database.
        /// </summary>
        /// <param name="id">
        /// The ID of the order to fetch.
        /// </param>
        /// <returns>
        /// An <see cref="IOrder"/> object that represents the existing order.
        /// </returns>
        IOrder Fetch(int id);

        /// <summary>
        /// Deletes an order from the database.
        /// </summary>
        /// <param name="id">
        /// The ID of the order to delete.
        /// </param>
        void Delete(int id);

        #endregion

    }


}
