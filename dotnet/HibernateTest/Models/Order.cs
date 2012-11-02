using System;
using System.Collections.Generic;

namespace HibernateTest.Models {

	/// <summary>[Table: Orders]</summary>
	public partial class Order {

		private int _orderID;
		/// <summary>[OrderID]</summary>
		public virtual int OrderID {
			get {
				return _orderID;
			}
			set {
				_orderID = value;
			}
		}
		private string _customerID;
		/// <summary>[CustomerID]</summary>
		public virtual string CustomerID {
			get {
				return _customerID;
			}
			set {
				_customerID = value;
			}
		}
		private int? _employeeID;
		/// <summary>[EmployeeID]</summary>
		public virtual int? EmployeeID {
			get {
				return _employeeID;
			}
			set {
				_employeeID = value;
			}
		}
		private System.DateTime? _orderDate;
		/// <summary>[OrderDate]</summary>
		public virtual System.DateTime? OrderDate {
			get {
				return _orderDate;
			}
			set {
				_orderDate = value;
			}
		}
		private System.DateTime? _requiredDate;
		/// <summary>[RequiredDate]</summary>
		public virtual System.DateTime? RequiredDate {
			get {
				return _requiredDate;
			}
			set {
				_requiredDate = value;
			}
		}
		private System.DateTime? _shippedDate;
		/// <summary>[ShippedDate]</summary>
		public virtual System.DateTime? ShippedDate {
			get {
				return _shippedDate;
			}
			set {
				_shippedDate = value;
			}
		}
		private int? _shipVia;
		/// <summary>[ShipVia]</summary>
		public virtual int? ShipVia {
			get {
				return _shipVia;
			}
			set {
				_shipVia = value;
			}
		}
		private decimal? _freight;
		/// <summary>[Freight]</summary>
		public virtual decimal? Freight {
			get {
				return _freight;
			}
			set {
				_freight = value;
			}
		}
		private string _shipName;
		/// <summary>[ShipName]</summary>
		public virtual string ShipName {
			get {
				return _shipName;
			}
			set {
				_shipName = value;
			}
		}
		private string _shipAddress;
		/// <summary>[ShipAddress]</summary>
		public virtual string ShipAddress {
			get {
				return _shipAddress;
			}
			set {
				_shipAddress = value;
			}
		}
		private string _shipCity;
		/// <summary>[ShipCity]</summary>
		public virtual string ShipCity {
			get {
				return _shipCity;
			}
			set {
				_shipCity = value;
			}
		}
		private string _shipRegion;
		/// <summary>[ShipRegion]</summary>
		public virtual string ShipRegion {
			get {
				return _shipRegion;
			}
			set {
				_shipRegion = value;
			}
		}
		private string _shipPostalCode;
		/// <summary>[ShipPostalCode]</summary>
		public virtual string ShipPostalCode {
			get {
				return _shipPostalCode;
			}
			set {
				_shipPostalCode = value;
			}
		}
		private string _shipCountry;
		/// <summary>[ShipCountry]</summary>
		public virtual string ShipCountry {
			get {
				return _shipCountry;
			}
			set {
				_shipCountry = value;
			}
		}
	}

}