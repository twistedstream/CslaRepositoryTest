using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Core;
using System.ComponentModel;


namespace CslaRepositoryTest.BusinessLayer
{


    /// <summary>
    /// Represents an editable product line item in an order.
    /// </summary>
    public interface ILineItem
        : IEditableBusinessObject, INotifyPropertyChanged
    {

        #region business members

        /// <summary>
        /// Gets or sets the name of the product in the line item.
        /// </summary>
        string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the individual purchase price of the product in the line item.
        /// </summary>
        decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity of products being purchased in the line item.
        /// </summary>
        int Quantity { get; set; }

        #endregion

    }


}
