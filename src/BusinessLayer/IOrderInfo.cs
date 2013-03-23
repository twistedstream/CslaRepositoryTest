using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CslaRepositoryTest.BusinessLayer
{


    /// <summary>
    /// Represents a read-only order.
    /// </summary>
    public interface IOrderInfo
    {

        #region business members

        /// <summary>
        /// Gets the ID of the order.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets the name of the order customer.
        /// </summary>
        string Customer { get; }

        /// <summary>
        /// Gets the date the order was made.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Date")]
        DateTime Date { get; }

        #endregion

    }


}
