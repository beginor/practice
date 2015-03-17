using System;
using System.Collections.Generic;

namespace ManyToManyUpdate {


    public class Role {

        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public Role() {
            Users = new HashSet<User>();
        }

    }
}
