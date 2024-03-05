using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Domain.Vehicles
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    }
}
