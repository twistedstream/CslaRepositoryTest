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
    /// The default implementation of the <see cref="IOrderInfo"/> interface.
    /// </summary>
    [Serializable]
    public sealed class OrderInfo
        : InjectableReadOnlyBase<OrderInfo>, IOrderInfo
    {

        private OrderInfo()
        {
        }

        #region IOrderInfo members

        //Id
        private static PropertyInfo<int> IdProperty = RegisterProperty<int>(new PropertyInfo<int>("Id"));
        int IOrderInfo.Id
        {
            get { return GetProperty<int>(IdProperty); }
        }

        //Customer
        private static PropertyInfo<string> CustomerProperty = RegisterProperty<string>(new PropertyInfo<string>("Customer"));
        string IOrderInfo.Customer
        {
            get { return GetProperty<string>(CustomerProperty); }
        }

        //Date
        private static PropertyInfo<DateTime> DateProperty = RegisterProperty<DateTime>(new PropertyInfo<DateTime>("Date"));
        DateTime IOrderInfo.Date
        {
            get { return GetProperty<DateTime>(DateProperty); }
        }

        #endregion

        #region data access

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
        private void Child_Fetch(IOrderInfoDto dto)
        {
            LoadProperty<int>(IdProperty, dto.Id);
            LoadProperty<string>(CustomerProperty, dto.Customer);
            LoadProperty<DateTime>(DateProperty, dto.Date);
        }

        #endregion

    }


}
