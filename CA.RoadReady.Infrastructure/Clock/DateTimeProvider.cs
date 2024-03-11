using CA.RoadReady.Application.Abstractions.Clock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Infrastructure.Clock
{
    internal sealed class DateTimeProvider : IDateTimeProvider
    {
        public DateTime CurrentTime => DateTime.UtcNow;
    }
}
