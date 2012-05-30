using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HttpWebApp.Models {

	/// <summary>[Table: Categories]</summary>
	[Description("[Table: Categories]")]
	public partial class Category {

		private int _categoryID;
		/// <summary>[CategoryID]</summary>
		[Description("[CategoryID]")]
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
		[Description("[CategoryName]")]
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
		[Description("[Description]")]
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
		[Description("[Picture]")]
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