using System.Collections.Generic;

namespace NhibernateMappingByCode.Entities {

    public class Store {

        public virtual int Id { get; protected set; }

        public virtual string Name { get; set; }

        public virtual IList<Product> Products { get; set; } = new List<Product>();

        public virtual IList<Employee> Staff { get; set; } = new List<Employee>();

        public virtual void AddProduct(Product product) {
            product.StoresStockedIn.Add(this);
            Products.Add(product);
        }

        public virtual void AddEmployee(Employee employee) {
            employee.Store = this;
            Staff.Add(employee);
        }
    }
}