using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace StoryboardDemo {

	/// <summary>[Table: Products]</summary>
	[Description("[Table: Products]")]
	public partial class Product {

		private long _productID;
		/// <summary>[ProductID]</summary>
		[Description("[ProductID]")]
		public virtual long ProductID {
			get {
				return _productID;
			}
			set {
				_productID = value;
			}
		}
		private string _productName;
		/// <summary>[ProductName]</summary>
		[Description("[ProductName]")]
		public virtual string ProductName {
			get {
				return _productName;
			}
			set {
				_productName = value;
			}
		}
		private long? _supplierID;
		/// <summary>[SupplierID]</summary>
		[Description("[SupplierID]")]
		public virtual long? SupplierID {
			get {
				return _supplierID;
			}
			set {
				_supplierID = value;
			}
		}
		private long? _categoryID;
		/// <summary>[CategoryID]</summary>
		[Description("[CategoryID]")]
		public virtual long? CategoryID {
			get {
				return _categoryID;
			}
			set {
				_categoryID = value;
			}
		}
		private string _quantityPerUnit;
		/// <summary>[QuantityPerUnit]</summary>
		[Description("[QuantityPerUnit]")]
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
		[Description("[UnitPrice]")]
		public virtual decimal? UnitPrice {
			get {
				return _unitPrice;
			}
			set {
				_unitPrice = value;
			}
		}
		private long? _unitsInStock;
		/// <summary>[UnitsInStock]</summary>
		[Description("[UnitsInStock]")]
		public virtual long? UnitsInStock {
			get {
				return _unitsInStock;
			}
			set {
				_unitsInStock = value;
			}
		}
		private long? _unitsOnOrder;
		/// <summary>[UnitsOnOrder]</summary>
		[Description("[UnitsOnOrder]")]
		public virtual long? UnitsOnOrder {
			get {
				return _unitsOnOrder;
			}
			set {
				_unitsOnOrder = value;
			}
		}
		private long? _reorderLevel;
		/// <summary>[ReorderLevel]</summary>
		[Description("[ReorderLevel]")]
		public virtual long? ReorderLevel {
			get {
				return _reorderLevel;
			}
			set {
				_reorderLevel = value;
			}
		}
		private long _discontinued;
		/// <summary>[Discontinued]</summary>
		[Description("[Discontinued]")]
		public virtual long Discontinued {
			get {
				return _discontinued;
			}
			set {
				_discontinued = value;
			}
		}
	}

}