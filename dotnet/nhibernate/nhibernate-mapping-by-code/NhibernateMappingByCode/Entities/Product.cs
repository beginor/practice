using System.Collections.Generic;

namespace NhibernateMappingByCode.Entities {

    public class Product {

        public virtual int Id { get; protected set; }

        public virtual string Name { get; set; }

        public virtual double Price { get; set; }

        public virtual IList<Store> StoresStockedIn { get; protected set; } = new List<Store>();

    }
}