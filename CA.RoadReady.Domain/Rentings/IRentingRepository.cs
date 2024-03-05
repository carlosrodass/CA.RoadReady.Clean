using CA.RoadReady.Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Domain.Rentings
{
    public interface IRentingRepository
    {
        Task<Renting> GetByIdAsync(Guid RentingId, CancellationToken cancellationToken);
        Task<bool> IsOverlapingAsync(Vehicle vehicle, DateRange duration, CancellationToken cancellationToken = default);
        void Add(Renting renting);

    }
}
