using System;
using System.Collections.Generic;

namespace NHibernateTest.Data {

	/// <summary>[Table: Products]</summary>
	public partial class Product {

		private int _productID;
		/// <summary>[ProductID]</summary>
		public virtual int ProductID {
			get {
				return _productID;
			}
			set {
				_productID = value;
			}
		}
		private string _productName;
		/// <summary>[ProductName]</summary>
		public virtual string ProductName {
			get {
				return _productName;
			}
			set {
				_productName = value;
			}
		}
		private int? _supplierID;
		/// <summary>[SupplierID]</summary>
		public virtual int? SupplierID {
			get {
				return _supplierID;
			}
			set {
				_supplierID = value;
			}
		}
		private int? _categoryID;
		/// <summary>[CategoryID]</summary>
		public virtual int? CategoryID {
			get {
				return _categoryID;
			}
			set {
				_categoryID = value;
			}
		}
		private string _quantityPerUnit;
		/// <summary>[QuantityPerUnit]</summary>
		public virtual string QuantityPerUnit {
			get {
				return _quantityPerUnit;
			}
			set {
				_quantityPerUnit = value;
			}
		}
		private decimal? _unitPrice;
		/// <summary>[UnitPrice]</summary>
		public virtual decimal? UnitPrice {
			get {
				return _unitPrice;
			}
			set {
				_unitPrice = value;
			}
		}
		private short? _unitsInStock;
		/// <summary>[UnitsInStock]</summary>
		public virtual short? UnitsInStock {
			get {
				return _unitsInStock;
			}
			set {
				_unitsInStock = value;
			}
		}
		private short? _unitsOnOrder;
		/// <summary>[UnitsOnOrder]</summary>
		public virtual short? UnitsOnOrder {
			get {
				return _unitsOnOrder;
			}
			set {
				_unitsOnOrder = value;
			}
		}
		private short? _reorderLevel;
		/// <summary>[ReorderLevel]</summary>
		public virtual short? ReorderLevel {
			get {
				return _reorderLevel;
			}
			set {
				_reorderLevel = value;
			}
		}
		private bool _discontinued;
		/// <summary>[Discontinued]</summary>
		public virtual bool Discontinued {
			get {
				return _discontinued;
			}
			set {
				_discontinued = value;
			}
		}
	}

}