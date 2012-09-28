using System;
using System.Collections.Generic;

namespace HibernateTest.Models {

	/// <summary>[Table: Shippers]</summary>
	public partial class Shipper {

		private int _shipperID;
		/// <summary>[ShipperID]</summary>
		public virtual int ShipperID {
			get {
				return _shipperID;
			}
			set {
				_shipperID = value;
			}
		}
		private string _companyName;
		/// <summary>[CompanyName]</summary>
		public virtual string CompanyName {
			get {
				return _companyName;
			}
			set {
				_companyName = value;
			}
		}
		private string _phone;
		/// <summary>[Phone]</summary>
		public virtual string Phone {
			get {
				return _phone;
			}
			set {
				_phone = value;
			}
		}
	}

}