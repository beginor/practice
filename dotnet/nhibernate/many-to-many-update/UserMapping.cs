using System;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate;
using NHibernate.Mapping.ByCode;

namespace ManyToManyUpdate {

    public class UserMapping : ClassMapping<User> {

        public UserMapping() {
            Table("[User]");

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
                m => m.Roles,
                map => {
                    map.Table("[User_Role]");
                    map.Key(k => { k.Column("[UserId]"); });
                },
                rel => {
                    rel.ManyToMany(map => {
                        map.Class(typeof(Role));
                        map.Column("[RoleId]");
                    });
                }
            );
        }
    }

}

