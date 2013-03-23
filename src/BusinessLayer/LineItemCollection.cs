using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CslaRepositoryTest.Core;
using CslaRepositoryTest.DataAccess;
using Csla;
using System.ComponentModel;


namespace CslaRepositoryTest.BusinessLayer
{


    /// <summary>
    /// A read-write collection of <see cref="ILineItem"/> objects.
    /// </summary>
    [Serializable]
    public class LineItemCollection
        : InjectableBusinessListBase<LineItemCollection, ILineItem>
    {

        #region data access

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", 
            Justification="Method called dynamically by CSLA.NET.")]
        private void Child_Fetch(IOrderDto data)
        {
            RaiseListChangedEvents = false;
            foreach (var dto in data.LineItems)
            {
                var child = DataPortal.FetchChild<LineItem>(dto);
                Add(child);
            }
            RaiseListChangedEvents = true;
        }

        /// <summary>
        /// Overrides the <see cref="BindingList{T}"/> class's 
        /// <see cref="BindingList{T}.OnAddingNew"/> method 
        /// in order to create an instance of the correct concrete child object 
        /// since the base class can't create an instance of the interface 
        /// <see cref="ILineItem"/>.
        /// </summary>
        protected override void OnAddingNew(AddingNewEventArgs e)
        {
            e.NewObject = DataPortal.CreateChild<LineItem>();
        }

        #endregion

    }


}
