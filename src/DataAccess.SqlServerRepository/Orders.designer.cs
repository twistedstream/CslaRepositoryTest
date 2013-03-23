﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CslaRepositoryTest.DataAccess.SqlServerRepository
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="Orders")]
	public partial class OrdersDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertLineItem(LineItem instance);
    partial void UpdateLineItem(LineItem instance);
    partial void DeleteLineItem(LineItem instance);
    partial void InsertOrder(Order instance);
    partial void UpdateOrder(Order instance);
    partial void DeleteOrder(Order instance);
    #endregion
		
		public OrdersDataContext() : 
				base(global::CslaRepositoryTest.DataAccess.SqlServerRepository.Properties.Settings.Default.OrdersConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public OrdersDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OrdersDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OrdersDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OrdersDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<LineItem> LineItems
		{
			get
			{
				return this.GetTable<LineItem>();
			}
		}
		
		public System.Data.Linq.Table<Order> Orders
		{
			get
			{
				return this.GetTable<Order>();
			}
		}
		
		[Function(Name="dbo.delete_order")]
		public int delete_order([Parameter(DbType="Int")] System.Nullable<int> id)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id);
			return ((int)(result.ReturnValue));
		}
		
		[Function(Name="dbo.insert_order")]
		public int insert_order([Parameter(DbType="Int")] ref System.Nullable<int> id, [Parameter(DbType="NVarChar(50)")] string customer, [Parameter(DbType="DateTime")] System.Nullable<System.DateTime> date, [Parameter(DbType="Money")] System.Nullable<decimal> shipping_cost, [Parameter(DbType="Timestamp")] ref System.Data.Linq.Binary timestamp)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id, customer, date, shipping_cost, timestamp);
			id = ((System.Nullable<int>)(result.GetParameterValue(0)));
			timestamp = ((System.Data.Linq.Binary)(result.GetParameterValue(4)));
			return ((int)(result.ReturnValue));
		}
		
		[Function(Name="dbo.update_order")]
		public int update_order([Parameter(DbType="Int")] System.Nullable<int> id, [Parameter(DbType="NVarChar(50)")] string customer, [Parameter(DbType="DateTime")] System.Nullable<System.DateTime> date, [Parameter(DbType="Money")] System.Nullable<decimal> shipping_cost, [Parameter(DbType="Timestamp")] System.Data.Linq.Binary old_timestamp, [Parameter(DbType="Timestamp")] ref System.Data.Linq.Binary timestamp)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id, customer, date, shipping_cost, old_timestamp, timestamp);
			timestamp = ((System.Data.Linq.Binary)(result.GetParameterValue(5)));
			return ((int)(result.ReturnValue));
		}
		
		[Function(Name="dbo.delete_line_item")]
		public int delete_line_item([Parameter(DbType="Int")] System.Nullable<int> id, [Parameter(DbType="Int")] System.Nullable<int> order_id)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id, order_id);
			return ((int)(result.ReturnValue));
		}
		
		[Function(Name="dbo.insert_line_item")]
		public int insert_line_item([Parameter(DbType="Int")] ref System.Nullable<int> id, [Parameter(DbType="Int")] System.Nullable<int> order_id, [Parameter(DbType="NVarChar(50)")] string product_name, [Parameter(DbType="Money")] System.Nullable<decimal> price, [Parameter(DbType="Int")] System.Nullable<int> quantity, [Parameter(DbType="Timestamp")] ref System.Data.Linq.Binary timestamp)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id, order_id, product_name, price, quantity, timestamp);
			id = ((System.Nullable<int>)(result.GetParameterValue(0)));
			timestamp = ((System.Data.Linq.Binary)(result.GetParameterValue(5)));
			return ((int)(result.ReturnValue));
		}
		
		[Function(Name="dbo.update_line_item")]
		public int update_line_item([Parameter(DbType="Int")] System.Nullable<int> id, [Parameter(DbType="Int")] System.Nullable<int> order_id, [Parameter(DbType="NVarChar(50)")] string product_name, [Parameter(DbType="Money")] System.Nullable<decimal> price, [Parameter(DbType="Int")] System.Nullable<int> quantity, [Parameter(DbType="Timestamp")] System.Data.Linq.Binary old_timestamp, [Parameter(DbType="Timestamp")] ref System.Data.Linq.Binary timestamp)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id, order_id, product_name, price, quantity, old_timestamp, timestamp);
			timestamp = ((System.Data.Linq.Binary)(result.GetParameterValue(6)));
			return ((int)(result.ReturnValue));
		}
	}
	
	[Table(Name="dbo.line_item")]
	public partial class LineItem : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _OrderId;
		
		private string _ProductName;
		
		private decimal _Price;
		
		private int _Quantity;
		
		private System.Data.Linq.Binary _Timestamp;
		
		private EntityRef<Order> _Order;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnOrderIdChanging(int value);
    partial void OnOrderIdChanged();
    partial void OnProductNameChanging(string value);
    partial void OnProductNameChanged();
    partial void OnPriceChanging(decimal value);
    partial void OnPriceChanged();
    partial void OnQuantityChanging(int value);
    partial void OnQuantityChanged();
    partial void OnTimestampChanging(System.Data.Linq.Binary value);
    partial void OnTimestampChanged();
    #endregion
		
		public LineItem()
		{
			this._Order = default(EntityRef<Order>);
			OnCreated();
		}
		
		[Column(Name="id", Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[Column(Name="order_id", Storage="_OrderId", DbType="Int NOT NULL", UpdateCheck=UpdateCheck.Never)]
		public int OrderId
		{
			get
			{
				return this._OrderId;
			}
			set
			{
				if ((this._OrderId != value))
				{
					this.OnOrderIdChanging(value);
					this.SendPropertyChanging();
					this._OrderId = value;
					this.SendPropertyChanged("OrderId");
					this.OnOrderIdChanged();
				}
			}
		}
		
		[Column(Name="product_name", Storage="_ProductName", DbType="NVarChar(50) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string ProductName
		{
			get
			{
				return this._ProductName;
			}
			set
			{
				if ((this._ProductName != value))
				{
					this.OnProductNameChanging(value);
					this.SendPropertyChanging();
					this._ProductName = value;
					this.SendPropertyChanged("ProductName");
					this.OnProductNameChanged();
				}
			}
		}
		
		[Column(Name="price", Storage="_Price", DbType="Money NOT NULL", UpdateCheck=UpdateCheck.Never)]
		public decimal Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[Column(Name="quantity", Storage="_Quantity", DbType="Int NOT NULL", UpdateCheck=UpdateCheck.Never)]
		public int Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
				}
			}
		}
		
		[Column(Name="timestamp", Storage="_Timestamp", AutoSync=AutoSync.Always, DbType="rowversion NOT NULL", CanBeNull=false, IsDbGenerated=true, IsVersion=true, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Timestamp
		{
			get
			{
				return this._Timestamp;
			}
			set
			{
				if ((this._Timestamp != value))
				{
					this.OnTimestampChanging(value);
					this.SendPropertyChanging();
					this._Timestamp = value;
					this.SendPropertyChanged("Timestamp");
					this.OnTimestampChanged();
				}
			}
		}
		
		[Association(Name="Order_LineItem", Storage="_Order", ThisKey="OrderId", OtherKey="Id", IsForeignKey=true)]
		public Order Order
		{
			get
			{
				return this._Order.Entity;
			}
			set
			{
				Order previousValue = this._Order.Entity;
				if (((previousValue != value) 
							|| (this._Order.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Order.Entity = null;
						previousValue.LineItems.Remove(this);
					}
					this._Order.Entity = value;
					if ((value != null))
					{
						value.LineItems.Add(this);
						this._OrderId = value.Id;
					}
					else
					{
						this._OrderId = default(int);
					}
					this.SendPropertyChanged("Order");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.[order]")]
	public partial class Order : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Customer;
		
		private System.DateTime _Date;
		
		private decimal _ShippingCost;
		
		private System.Data.Linq.Binary _Timestamp;
		
		private EntitySet<LineItem> _LineItems;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnCustomerChanging(string value);
    partial void OnCustomerChanged();
    partial void OnDateChanging(System.DateTime value);
    partial void OnDateChanged();
    partial void OnShippingCostChanging(decimal value);
    partial void OnShippingCostChanged();
    partial void OnTimestampChanging(System.Data.Linq.Binary value);
    partial void OnTimestampChanged();
    #endregion
		
		public Order()
		{
			this._LineItems = new EntitySet<LineItem>(new Action<LineItem>(this.attach_LineItems), new Action<LineItem>(this.detach_LineItems));
			OnCreated();
		}
		
		[Column(Name="id", Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[Column(Name="customer", Storage="_Customer", DbType="NVarChar(50) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Customer
		{
			get
			{
				return this._Customer;
			}
			set
			{
				if ((this._Customer != value))
				{
					this.OnCustomerChanging(value);
					this.SendPropertyChanging();
					this._Customer = value;
					this.SendPropertyChanged("Customer");
					this.OnCustomerChanged();
				}
			}
		}
		
		[Column(Name="date", Storage="_Date", DbType="DateTime NOT NULL", UpdateCheck=UpdateCheck.Never)]
		public System.DateTime Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[Column(Name="shipping_cost", Storage="_ShippingCost", DbType="Money NOT NULL", UpdateCheck=UpdateCheck.Never)]
		public decimal ShippingCost
		{
			get
			{
				return this._ShippingCost;
			}
			set
			{
				if ((this._ShippingCost != value))
				{
					this.OnShippingCostChanging(value);
					this.SendPropertyChanging();
					this._ShippingCost = value;
					this.SendPropertyChanged("ShippingCost");
					this.OnShippingCostChanged();
				}
			}
		}
		
		[Column(Name="timestamp", Storage="_Timestamp", AutoSync=AutoSync.Always, DbType="rowversion NOT NULL", CanBeNull=false, IsDbGenerated=true, IsVersion=true, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Timestamp
		{
			get
			{
				return this._Timestamp;
			}
			set
			{
				if ((this._Timestamp != value))
				{
					this.OnTimestampChanging(value);
					this.SendPropertyChanging();
					this._Timestamp = value;
					this.SendPropertyChanged("Timestamp");
					this.OnTimestampChanged();
				}
			}
		}
		
		[Association(Name="Order_LineItem", Storage="_LineItems", ThisKey="Id", OtherKey="OrderId")]
		public EntitySet<LineItem> LineItems
		{
			get
			{
				return this._LineItems;
			}
			set
			{
				this._LineItems.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_LineItems(LineItem entity)
		{
			this.SendPropertyChanging();
			entity.Order = this;
		}
		
		private void detach_LineItems(LineItem entity)
		{
			this.SendPropertyChanging();
			entity.Order = null;
		}
	}
}
#pragma warning restore 1591