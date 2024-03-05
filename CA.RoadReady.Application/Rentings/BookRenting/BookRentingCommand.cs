using CA.RoadReady.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CA.RoadReady.Application.Rentings.BookRenting
{
    public record BookRentingCommand(
        Guid VehicleId,
        Guid UserId,
        DateOnly StartDate,
        DateOnly EndDate

        ) : ICommand<Guid>;
}
