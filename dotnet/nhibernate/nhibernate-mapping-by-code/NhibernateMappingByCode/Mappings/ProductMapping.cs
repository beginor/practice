using NhibernateMappingByCode.Entities;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NhibernateMappingByCode.Mappings {

    public class ProductMapping : ClassMapping<Product> {

        public ProductMapping() {
            Table("product");

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

            Property(
                m => m.Price,
                map => {
                    map.Column("price");
                    map.Type(NHibernateUtil.Double);
                }
            );

            Bag(
                m => m.StoresStockedIn,
                map => {
                    map.Table("store_product");

                    map.Key(k => {
                        k.Column("product_id");
                        k.ForeignKey("store_product_to_product");
                    });
                },
                rel => rel.ManyToMany(map => {
                    map.Class(typeof(Store));
                    map.Column("store_id");
                })
            );
        }
    }
}