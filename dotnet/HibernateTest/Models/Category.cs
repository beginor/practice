using System;
using System.Collections.Generic;

namespace HibernateTest.Models {

	/// <summary>[Table: Categories]</summary>
	public partial class Category {

		private int _categoryID;
		/// <summary>[CategoryID]</summary>
		public virtual int CategoryID {
			get {
				return _categoryID;
			}
			set {
				_categoryID = value;
			}
		}
		private string _categoryName;
		/// <summary>[CategoryName]</summary>
		public virtual string CategoryName {
			get {
				return _categoryName;
			}
			set {
				_categoryName = value;
			}
		}
		private string _description;
		/// <summary>[Description]</summary>
		public virtual string Description {
			get {
				return _description;
			}
			set {
				_description = value;
			}
		}
		private byte[] _picture;
		/// <summary>[Picture]</summary>
		public virtual byte[] Picture {
			get {
				return _picture;
			}
			set {
				_picture = value;
			}
		}
	}

}