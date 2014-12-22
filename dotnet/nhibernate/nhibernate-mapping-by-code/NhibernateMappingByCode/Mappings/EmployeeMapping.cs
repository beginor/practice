using NhibernateMappingByCode.Entities;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NhibernateMappingByCode.Mappings {

    public class EmployeeMapping : ClassMapping<Employee> {

        public EmployeeMapping() {
            Table("employee");
            //Schema("dbo");
            Id(
                m => m.Id,
                map => {
                    map.Column("id");
                    map.Type(NHibernateUtil.Int32);
                    map.Generator(Generators.Identity);
                }
            );
            Property(
                m => m.FirstName,
                map => {
                    map.Column("first_name");
                    map.Type(NHibernateUtil.String);
                    map.Length(20);
                }
            );
            Property(
                m => m.LastName,
                map => {
                    map.Column("last_name");
                    map.Type(NHibernateUtil.String);
                    map.Length(20);
                }
            );
            ManyToOne(
                m => m.Store,
                map => {
                    map.Class(typeof(Store));
                    map.Cascade(Cascade.All);
                    map.Column("store_id");
                    map.ForeignKey("employee_to_store");
                }
            );
        }
    }
}