using System;
using System.Collections.Generic;

namespace HibernateTest.Models {

	/// <summary>[Table: CustomerDemographics]</summary>
	public partial class CustomerDemographic {

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
		private string _customerDesc;
		/// <summary>[CustomerDesc]</summary>
		public virtual string CustomerDesc {
			get {
				return _customerDesc;
			}
			set {
				_customerDesc = value;
			}
		}
	}

}