using System;
using System.Collections.Generic;

namespace HibernateTest.Models {

	/// <summary>[Table: Territories]</summary>
	public partial class Territory {

		private string _territoryID;
		/// <summary>[TerritoryID]</summary>
		public virtual string TerritoryID {
			get {
				return _territoryID;
			}
			set {
				_territoryID = value;
			}
		}
		private string _territoryDescription;
		/// <summary>[TerritoryDescription]</summary>
		public virtual string TerritoryDescription {
			get {
				return _territoryDescription;
			}
			set {
				_territoryDescription = value;
			}
		}
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
	}

}