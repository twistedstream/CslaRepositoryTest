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


namespace CslaRepositoryTest.BusinessLayer
{
    
    
    /// <summary>
    /// The default implementation of the <see cref="ILineItem"/> interface.
    /// </summary>
    [Serializable]
    public sealed class LineItem
        : InjectableBusinessBase<LineItem>, ILineItem
    {

        private LineItem()
        {
        }

        #region ILineItem members

        //ProductName
        private static PropertyInfo<string> ProductNameProperty = RegisterProperty<string>(new PropertyInfo<string>("ProductName", "Product Name"));
        /// <summary>
        /// Implements the <see cref="ILineItem"/> interface's <see cref="ILineItem.ProductName"/> property.
        /// </summary>
        public string ProductName
        {
            get { return GetProperty<string>(ProductNameProperty); }
            set { SetProperty<string>(ProductNameProperty, value); }
        }

        //Price
        private static PropertyInfo<decimal> PriceProperty = RegisterProperty<decimal>(new PropertyInfo<decimal>("Price"));
        /// <summary>
        /// Implements the <see cref="ILineItem"/> interface's <see cref="ILineItem.Price"/> property.
        /// </summary>
        public decimal Price
        {
            get { return GetProperty<decimal>(PriceProperty); }
            set { SetProperty<decimal>(PriceProperty, value); }
        }

        //Quantity
        private static PropertyInfo<int> QuantityProperty = RegisterProperty<int>(new PropertyInfo<int>("Quantity"));
        /// <summary>
        /// Implements the <see cref="ILineItem"/> interface's <see cref="ILineItem.Quantity"/> property.
        /// </summary>
        public int Quantity
        {
            get { return GetProperty<int>(QuantityProperty); }
            set { SetProperty<int>(QuantityProperty, value); }
        }

        #endregion

        #region validation rules

        /// <summary>
        /// Overrides the <see cref="BusinessBase"/> class's 
        /// <see cref="BusinessBase.AddBusinessRules"/> method in order to 
        /// add the necessary business rules for the <see cref="LineItem"/> class.
        /// </summary>
        protected override void AddBusinessRules()
        {
            //ProductName
            ValidationRules.AddRule(CommonRules.StringRequired, new RuleArgs(ProductNameProperty));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(ProductNameProperty, 50));
            //Price
            ValidationRules.AddRule(CommonRules.MinValue<decimal>, new CommonRules.MinValueRuleArgs<decimal>(PriceProperty, 0));
            //Quantity
            ValidationRules.AddRule(CommonRules.MinValue<int>, new CommonRules.MinValueRuleArgs<int>(QuantityProperty, 0));
        }

        #endregion

        #region data access

        int _id;
        byte[] _timestamp = new byte[8];

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
        private void Child_Fetch(ILineItemDto dto)
        {
            _id = dto.Id;
            LoadProperty<string>(ProductNameProperty, dto.ProductName);
            LoadProperty<decimal>(PriceProperty, dto.Price);
            LoadProperty<int>(QuantityProperty, dto.Quantity);
            _timestamp = dto.Timestamp;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
        private void Child_Insert(IOrder parent, IOrderContext context)
        {
            //create DTO
            var dto = EnsureDependency(_repository).CreateLineItemDto();
            dto.OrderId = parent.Id;
            dto.ProductName = ReadProperty<string>(ProductNameProperty);
            dto.Price = ReadProperty<decimal>(PriceProperty);
            dto.Quantity = ReadProperty<int>(QuantityProperty);
            //insert line item data
            context.InsertLineItem(dto);
            _id = dto.Id;
            _timestamp = dto.Timestamp;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method is called indirectly by the CSLA.NET DataPortal.")]
        private void Child_Update(IOrder parent, IOrderContext context)
        {
            //create DTO
            var dto = EnsureDependency(_repository).CreateLineItemDto();
            dto.Id = _id;
            dto.OrderId = parent.Id;
            dto.ProductName = ReadProperty<string>(ProductNameProperty);
            dto.Price = ReadProperty<decimal>(PriceProperty);
            dto.Quantity = ReadProperty<int>(QuantityProperty);
            dto.Timestamp = _timestamp;
            //update line item data
            context.UpdateLineItem(dto);
            _timestamp = dto.Timestamp;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", 
            Justification="This method is called indirectly by the CSLA.NET DataPortal.")]
        private void Child_DeleteSelf(IOrder parent, IOrderContext context)
        {
            //delete line item data
            context.DeleteLineItem(_id, parent.Id);
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
