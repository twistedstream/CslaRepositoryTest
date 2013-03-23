using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;
using CslaRepositoryTest.DataAccess;
using Microsoft.Practices.Unity;
using CslaRepositoryTest.Core;


namespace CslaRepositoryTest.BusinessLayer
{


    /// <summary>
    /// A read-only collection of <see cref="IOrderInfo"/> objects.
    /// </summary>
    [Serializable]
    public class OrderInfoCollection
        : InjectableReadOnlyListBase<OrderInfoCollection, IOrderInfo>
    {

        private OrderInfoCollection()
        {
        }

        #region Data Access

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "Method called dynamically by CSLA.NET.")]
        private void DataPortal_Fetch()
        {
            RaiseListChangedEvents = false;
            using (var context = EnsureDependency(_repository).CreateContext(false))
            {
                IsReadOnly = false;
                foreach (var dto in context.FetchInfoList())
                {
                    var child = DataPortal.FetchChild<OrderInfo>(dto);
                    this.Add(child);
                }
                IsReadOnly = true;
            }
            RaiseListChangedEvents = true;
        }

        #endregion

        #region Dependencies

        [NonSerialized]
        [NotUndoable]
        private IOrderRepository _repository;

        /// <summary>
        /// Injects the dependencies for this instance.
        /// </summary>
        /// <param name="repository">
        /// The <see cref="IOrderRepository"/> dependency.
        /// </param>
        [InjectionMethod]
        public void Inject(IOrderRepository repository)
        {
            //validate params
            if (repository == null)
                throw new ArgumentNullException("repository");
            _repository = repository;
        }

        #endregion

    }


}
