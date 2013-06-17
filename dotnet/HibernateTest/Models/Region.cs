using System;
using System.Collections.Generic;

namespace HibernateTest.Models {

	/// <summary>[Table: Region]</summary>
	public partial class Region {

		private int _regionID;
		/// <summary>[RegionID]</summary>
		public virtual int RegionID {
			get {
				return _regionID;
			}
			set {
				_regionID = value;
			}
		}
		private string _regionDescription;
		/// <summary>[RegionDescription]</summary>
		public virtual string RegionDescription {
			get {
				return _regionDescription;
			}
			set {
				_regionDescription = value;
			}
		}
	}

}