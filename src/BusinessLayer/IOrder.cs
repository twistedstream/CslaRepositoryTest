using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Core;
using CslaRepositoryTest.Core;
using System.ComponentModel;


namespace CslaRepositoryTest.BusinessLayer
{


    /// <summary>
    /// Represents an editbale order.
    /// </summary>
    public interface IOrder
        : IEditableBusinessObject, INotifyPropertyChanged
    {

        #region business members

        /// <summary>
        /// Gets the ID of the order.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets or sets the name of the order customer.
        /// </summary>
        string Customer { get; set; }

        /// <summary>
        /// Gets or sets the date the order was made.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Date")]
        DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the shipping cost associated with the order.
        /// </summary>
        Decimal ShippingCost { get; set; }

        /// <summary>
        /// Gets the collection of <see cref="ILineItem"/> objects in the order.
        /// </summary>
        InjectableBusinessListBase<LineItemCollection, ILineItem> LineItems { get; }

        /// <summary>
        /// Saves changes to the object to the database.
        /// </summary>
        /// <returns>
        /// A new instance containing the saved values.
        /// </returns>
        IOrder Save();

        #endregion

    }


}
