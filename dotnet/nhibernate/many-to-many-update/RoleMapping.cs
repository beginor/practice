using System;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate;
using NHibernate.Mapping.ByCode;

namespace ManyToManyUpdate {

    public class RoleMapping : ClassMapping<Role> {

        public RoleMapping() {
            Table("[Role]");

            Id(m => m.Id, map => {
                map.Column("[Id]");
                map.Type(NHibernateUtil.Int32);
                map.Generator(Generators.Identity);
            });

            Property(m => m.Name, map => {
                map.Column("[Name]");
                map.Type(NHibernateUtil.String);
            });


            Set(
                m => m.Users,
                map => {
                    map.Table("[User_Role]");
                    map.Key(k => { k.Column("[RoleId]"); });
                    map.Inverse(true);
                },
                rel => {
                    rel.ManyToMany(map => {
                        map.Class(typeof(User));
                        map.Column("[UserId]");
                    });
                }
            );

        }
    }
}
