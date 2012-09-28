using System;
using System.Collections.Generic;

namespace HibernateTest.Models {

	/// <summary>[Table: EmployeeTerritories]</summary>
	public partial class EmployeeTerritory {

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
	}

}