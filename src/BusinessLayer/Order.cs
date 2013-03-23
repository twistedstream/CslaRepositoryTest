using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;
using Csla.Core;
using Csla.Validation;
using CslaRepositoryTest.DataAccess;
using Microsoft.Practices.Unity;
using CslaRepositoryTest.Core;
using System.ComponentModel;


namespace CslaRepositoryTest.BusinessLayer
{


    /// <summary>
    /// The default implementation of the <see cref="IOrder"/> interface.
    /// </summary>
    [Serializable]
    public sealed class Order
        : InjectableBusinessBase<Order>, IOrder
    {

        private Order()
        {
        }

        #region IOrder members

        //Id
        private static PropertyInfo<int> IdProperty = RegisterProperty<int>(new PropertyInfo<int>("Id", "ID"));
        /// <summary>
        /// Implements the <see cref="IOrder"/> interface's <see cref="IOrder.Id"/> property.
        /// </summary>
        public int Id
        {
            get { return GetProperty<int>(IdProperty); }
        }

        //Customer
        private static PropertyInfo<string> CustomerProperty = RegisterProperty<string>(new PropertyInfo<string>("Customer"));
        /// <summary>
        /// Implements the <see cref="IOrder"/> interface's <see cref="IOrder.Customer"/> property.
        /// </summary>
        public string Customer
        {
            get { return GetProperty<string>(CustomerProperty); }
            set { SetProperty<string>(CustomerProperty, value); }
        }

        //Date
        private static PropertyInfo<DateTime> DateProperty = RegisterProperty<DateTime>(new PropertyInfo<DateTime>("Date"));
        /// <summary>
        /// Implements the <see cref="IOrder"/> interface's <see cref="IOrder.Date"/> property.
        /// </summary>
        public DateTime Date
        {
            get { return GetProperty<DateTime>(DateProperty); }
            set { SetProperty<DateTime>(DateProperty, value); }
        }

        //ShippingCost
        private static PropertyInfo<Decimal> ShippingCostProperty = RegisterProperty<Decimal>(new PropertyInfo<Decimal>("ShippingCost", "Shipping Cost"));
        /// <summary>
        /// Implements the <see cref="IOrder"/> interface's <see cref="IOrder.ShippingCost"/> property.
        /// </summary>
        public Decimal ShippingCost
        {
            get { return GetProperty<Decimal>(ShippingCostProperty); }
            set { SetProperty<Decimal>(ShippingCostProperty, value); }
        }

        //LineItems
        private static PropertyInfo<LineItemCollection> LineItemsProperty = RegisterProperty(new PropertyInfo<LineItemCollection>("LineItems", "Line Items"));
        /// <summary>
        /// Implements the <see cref="IOrder"/> interface's <see cref="IOrder.LineItems"/> property.
        /// </summary>
        public InjectableBusinessListBase<LineItemCollection, ILineItem> LineItems
        {
            get
            {
                if (!(FieldManager.FieldExists(LineItemsProperty)))
                {
                    LoadProperty<LineItemCollection>(LineItemsProperty, DataPortal.CreateChild<LineItemCollection>());
                }
                return GetProperty<LineItemCollection>(LineItemsProperty);
            }
        }

        //Save
        IOrder IOrder.Save()
        {
            return this.Save();
        }

        #endregion

        #region validation rules

        /// <summary>
        /// Overrides the <see cref="BusinessBase"/> class's 
        /// <see cref="BusinessBase.AddBusinessRules"/> method in order to 
        /// add the necessary business rules for the <see cref="Order"/> class.
        /// </summary>
        protected override void AddBusinessRules()
        {
            //Customer
            ValidationRules.AddRule(CommonRules.StringRequired, new RuleArgs(CustomerProperty));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(CustomerProperty, 50));
            //ShippingCost
            ValidationRules.AddRule(CommonRules.MinValue<decimal>, new CommonRules.MinValueRuleArgs<decimal>(ShippingCostProperty, 0));
        }

        #endregion

        #region Data Access

        byte[] _timestamp = new byte[8];

        /// <summary>
        /// Overrides the <see cref="BusinessBase"/> class's 
        /// <see cref="BusinessBase.DataPortal_Create"/> method in order to 
        /// populate a new order object.
        /// </summary>
        [RunLocal()]
        protected override void DataPortal_Create()
        {
            LoadProperty<DateTime>(DateProperty, DateTime.Today);
            ValidationRules.CheckRules();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
        private void DataPortal_Fetch(SingleCriteria<Order, int> criteria)
        {
            using (var context = EnsureDependency(_repository).CreateContext(false))
            {
                var dto = context.FetchSingleWithLineItems(criteria.Value);
                //populate
                LoadProperty<int>(IdProperty, dto.Id);
                LoadProperty<string>(CustomerProperty, dto.Customer);
                LoadProperty<DateTime>(DateProperty, dto.Date);
                LoadProperty<decimal>(ShippingCostProperty, dto.ShippingCost);
                _timestamp = dto.Timestamp;
                //populate child data
                LoadProperty<LineItemCollection>(LineItemsProperty, DataPortal.FetchChild<LineItemCollection>(dto));
            }
        }

        /// <summary>
        /// Overrides the <see cref="BusinessBase"/> class's 
        /// <see cref="BusinessBase.DataPortal_Insert"/> method in order to 
        /// perform the data access necessary to insert an order into the database.
        /// </summary>
        protected override void DataPortal_Insert()
        {
            using (var context = EnsureDependency(_repository).CreateContext(true))
            {
                //create DTO
                var dto = EnsureDependency(_repository).CreateOrderDto();
                dto.Customer = ReadProperty<string>(CustomerProperty);
                dto.Date = ReadProperty<DateTime>(DateProperty);
                dto.ShippingCost = ReadProperty<decimal>(ShippingCostProperty);
                //insert order data
                context.InsertOrder(dto);
                LoadProperty<int>(IdProperty, dto.Id);
                _timestamp = dto.Timestamp;
                //update child data
                DataPortal.UpdateChild(ReadProperty<LineItemCollection>(LineItemsProperty), this, context);
                //commit transaction
                context.CompleteTransaction();
            }            
        }

        /// <summary>
        /// Overrides the <see cref="BusinessBase"/> class's 
        /// <see cref="BusinessBase.DataPortal_Update"/> method in order to 
        /// perform the data access necessary to update an existing order in the database.
        /// </summary>
        protected override void DataPortal_Update()
        {
            using (var context = EnsureDependency(_repository).CreateContext(true))
            {
                if (IsSelfDirty)
                {
                    //create DTO
                    var dto = EnsureDependency(_repository).CreateOrderDto();
                    dto.Id = ReadProperty<int>(IdProperty);
                    dto.Customer = ReadProperty<string>(CustomerProperty);
                    dto.Date = ReadProperty<DateTime>(DateProperty);
                    dto.ShippingCost = ReadProperty<decimal>(ShippingCostProperty);
                    dto.Timestamp = _timestamp;
                    //update order data
                    context.UpdateOrder(dto);
                    _timestamp = dto.Timestamp;
                }
                //update child data
                DataPortal.UpdateChild(ReadProperty<LineItemCollection>(LineItemsProperty), this, context);
                //commit transaction
                context.CompleteTransaction();
            }
        }

        /// <summary>
        /// Overrides the <see cref="BusinessBase"/> class's 
        /// <see cref="BusinessBase.DataPortal_DeleteSelf"/> method in order to 
        /// perform the data access necessary to delete an existing order in the database.
        /// </summary>
        protected override void DataPortal_DeleteSelf()
        {
            var criteria = new SingleCriteria<Order, int>(ReadProperty<int>(IdProperty));
            DataPortal_Delete(criteria);
        }

        private void DataPortal_Delete(SingleCriteria<Order, int> criteria)
        {
            using (var context = EnsureDependency(_repository).CreateContext(true))
            {
                //delete order data
                context.DeleteOrder(criteria.Value);
                //reset child list field
                SetProperty<LineItemCollection>(LineItemsProperty, DataPortal.CreateChild<LineItemCollection>());
                //commit transaction
                context.CompleteTransaction();
            }
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
