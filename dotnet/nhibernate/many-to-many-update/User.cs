using System;
using System.Collections.Generic;

namespace ManyToManyUpdate {

    public class User {

        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public User() {
            Roles = new HashSet<Role>();
        }
    }
    
}
