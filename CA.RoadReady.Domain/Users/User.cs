using CA.RoadReady.Domain.Abstractions;
using CA.RoadReady.Domain.Users.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Domain.Users
{
    public sealed class User : Entity
    {
        public Name? Name { get; private set; }
        public LastName? LastName { get; private set; }
        public Email? Email { get; private set; }

        private User(Guid id,
                     Name name,
                     LastName lastName,
                     Email email) : base(id)
        {
            Name = name;
            LastName = lastName;
            Email = email;
        }

        public static User Create(Name name,
                                  LastName lastName,
                                  Email email)
        {
            var user = new User(Guid.NewGuid(), name, lastName, email);
            user.RaiseDomainEvent(new UserCreateDomainEvent(user.Id));
            return user;
        }

    }
}
