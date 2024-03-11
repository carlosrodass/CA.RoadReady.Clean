using CA.RoadReady.Domain.Abstractions;
using CA.RoadReady.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Infrastructure.Repositories
{
    internal sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }



    }
}
