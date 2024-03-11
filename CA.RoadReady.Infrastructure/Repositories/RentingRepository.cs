using CA.RoadReady.Domain.Rentings;
using CA.RoadReady.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Infrastructure.Repositories
{
    internal sealed class RentingRepository : Repository<Renting>, IRentingRepository
    {

        private static readonly RentingStatus[] ActiveRentingStatuses = {
            RentingStatus.Reserved,
            RentingStatus.Confirmed,
            RentingStatus.Completed
        };

        public RentingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsOverlapingAsync(Vehicle vehicle, DateRange duration, CancellationToken cancellationToken = default)
        {

            return await _DbContext.Set<Renting>()
                .AnyAsync(
                    renting => renting.VehicleId == vehicle.Id &&
                    renting.Duration!.Start <= duration.End &&
                    renting.Duration!.End >= duration.Start &&
                    ActiveRentingStatuses.Contains(renting.Status),
                    cancellationToken
                );


        }
    }
}
