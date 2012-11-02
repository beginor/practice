using System;
using System.Collections.Generic;

namespace HibernateTest.Models {

	/// <summary>[Table: CustomerCustomerDemo]</summary>
	public partial class CustomerCustomerDemo {

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
		private string _customerTypeID;
		/// <summary>[CustomerTypeID]</summary>
		public virtual string CustomerTypeID {
			get {
				return _customerTypeID;
			}
			set {
				_customerTypeID = value;
			}
		}
	}

}