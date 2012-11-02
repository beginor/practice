using System;
using System.Collections.Generic;

namespace HibernateTest.Models {

	/// <summary>[Table: Order Details]</summary>
	public partial class OrderDetail {

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
		private decimal _unitPrice;
		/// <summary>[UnitPrice]</summary>
		public virtual decimal UnitPrice {
			get {
				return _unitPrice;
			}
			set {
				_unitPrice = value;
			}
		}
		private short _quantity;
		/// <summary>[Quantity]</summary>
		public virtual short Quantity {
			get {
				return _quantity;
			}
			set {
				_quantity = value;
			}
		}
		private float _discount;
		/// <summary>[Discount]</summary>
		public virtual float Discount {
			get {
				return _discount;
			}
			set {
				_discount = value;
			}
		}
		protected bool Equals(OrderDetail other) {
			return this.OrderID == other.OrderID && this.ProductID == other.ProductID;
		}

		public override int GetHashCode() {
			unchecked {
				int hashCode;
				hashCode = this.OrderID.GetHashCode();
				hashCode = (hashCode * 397) ^ this.ProductID.GetHashCode();
				return hashCode;
			}
		}

		public override bool Equals(object obj) {
			if (ReferenceEquals(null, obj)) {
				return false;
			}
			if (ReferenceEquals(this, obj)) {
				return true;
			}
			if (obj.GetType() != this.GetType()) {
				return false;
			}
			return Equals((OrderDetail)obj);
		}
	}

}