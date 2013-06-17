using System;
using System.Collections.Generic;

namespace HibernateTest.Models {

	/// <summary>[Table: Customers]</summary>
	public partial class Customer {

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
		private string _contactName;
		/// <summary>[ContactName]</summary>
		public virtual string ContactName {
			get {
				return _contactName;
			}
			set {
				_contactName = value;
			}
		}
		private string _contactTitle;
		/// <summary>[ContactTitle]</summary>
		public virtual string ContactTitle {
			get {
				return _contactTitle;
			}
			set {
				_contactTitle = value;
			}
		}
		private string _address;
		/// <summary>[Address]</summary>
		public virtual string Address {
			get {
				return _address;
			}
			set {
				_address = value;
			}
		}
		private string _city;
		/// <summary>[City]</summary>
		public virtual string City {
			get {
				return _city;
			}
			set {
				_city = value;
			}
		}
		private string _region;
		/// <summary>[Region]</summary>
		public virtual string Region {
			get {
				return _region;
			}
			set {
				_region = value;
			}
		}
		private string _postalCode;
		/// <summary>[PostalCode]</summary>
		public virtual string PostalCode {
			get {
				return _postalCode;
			}
			set {
				_postalCode = value;
			}
		}
		private string _country;
		/// <summary>[Country]</summary>
		public virtual string Country {
			get {
				return _country;
			}
			set {
				_country = value;
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
		private string _fax;
		/// <summary>[Fax]</summary>
		public virtual string Fax {
			get {
				return _fax;
			}
			set {
				_fax = value;
			}
		}
	}

}