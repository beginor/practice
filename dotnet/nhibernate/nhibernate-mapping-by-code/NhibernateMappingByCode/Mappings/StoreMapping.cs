using NhibernateMappingByCode.Entities;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NhibernateMappingByCode.Mappings {

    public class StoreMapping : ClassMapping<Store> {

        public StoreMapping() {
            Table("store");

            Id(
                m => m.Id,
                map => {
                    map.Column("id");
                    map.Type(NHibernateUtil.Int32);
                    map.Generator(Generators.Identity);
                }
            );

            Property(
                m => m.Name,
                map => {
                    map.Column("name");
                    map.Type(NHibernateUtil.String);
                    map.Length(20);
                }
            );
            Bag(
                m => m.Staff,
                map => {
                    map.Table("employee");
                    map.Key(k => {
                        k.Column("store_id");
                        k.ForeignKey("employee_to_store");
                    });
                },
                rel => {
                    rel.OneToMany(map => map.Class(typeof(Employee)));
                }
            );

            Bag(
                m => m.Products,
                map => {
                    map.Table("store_product");
                    map.Key(k => {
                        k.Column("store_id");
                        k.ForeignKey("store_product_to_store");
                    });
                },
                rel => rel.ManyToMany(map => {
                    map.Class(typeof(Product));
                    map.Column("product_id");
                })
            );
        }
    }
}