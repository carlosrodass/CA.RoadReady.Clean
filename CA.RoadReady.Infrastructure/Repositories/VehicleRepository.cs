using CA.RoadReady.Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Infrastructure.Repositories
{
    internal sealed class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }


    }
}
