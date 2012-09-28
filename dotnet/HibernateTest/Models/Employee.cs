using System;
using System.Collections.Generic;

namespace HibernateTest.Models {

	/// <summary>[Table: Employees]</summary>
	public partial class Employee {

		private int _employeeID;
		/// <summary>[EmployeeID]</summary>
		public virtual int EmployeeID {
			get {
				return _employeeID;
			}
			set {
				_employeeID = value;
			}
		}
		private string _lastName;
		/// <summary>[LastName]</summary>
		public virtual string LastName {
			get {
				return _lastName;
			}
			set {
				_lastName = value;
			}
		}
		private string _firstName;
		/// <summary>[FirstName]</summary>
		public virtual string FirstName {
			get {
				return _firstName;
			}
			set {
				_firstName = value;
			}
		}
		private string _title;
		/// <summary>[Title]</summary>
		public virtual string Title {
			get {
				return _title;
			}
			set {
				_title = value;
			}
		}
		private string _titleOfCourtesy;
		/// <summary>[TitleOfCourtesy]</summary>
		public virtual string TitleOfCourtesy {
			get {
				return _titleOfCourtesy;
			}
			set {
				_titleOfCourtesy = value;
			}
		}
		private System.DateTime? _birthDate;
		/// <summary>[BirthDate]</summary>
		public virtual System.DateTime? BirthDate {
			get {
				return _birthDate;
			}
			set {
				_birthDate = value;
			}
		}
		private System.DateTime? _hireDate;
		/// <summary>[HireDate]</summary>
		public virtual System.DateTime? HireDate {
			get {
				return _hireDate;
			}
			set {
				_hireDate = value;
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
		private string _homePhone;
		/// <summary>[HomePhone]</summary>
		public virtual string HomePhone {
			get {
				return _homePhone;
			}
			set {
				_homePhone = value;
			}
		}
		private string _extension;
		/// <summary>[Extension]</summary>
		public virtual string Extension {
			get {
				return _extension;
			}
			set {
				_extension = value;
			}
		}
		private byte[] _photo;
		/// <summary>[Photo]</summary>
		public virtual byte[] Photo {
			get {
				return _photo;
			}
			set {
				_photo = value;
			}
		}
		private string _notes;
		/// <summary>[Notes]</summary>
		public virtual string Notes {
			get {
				return _notes;
			}
			set {
				_notes = value;
			}
		}
		private int? _reportsTo;
		/// <summary>[ReportsTo]</summary>
		public virtual int? ReportsTo {
			get {
				return _reportsTo;
			}
			set {
				_reportsTo = value;
			}
		}
		private string _photoPath;
		/// <summary>[PhotoPath]</summary>
		public virtual string PhotoPath {
			get {
				return _photoPath;
			}
			set {
				_photoPath = value;
			}
		}
	}

}