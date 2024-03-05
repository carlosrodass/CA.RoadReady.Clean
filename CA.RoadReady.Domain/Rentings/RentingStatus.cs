using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Domain.Rentings
{
    public enum RentingStatus
    {
        Reserved = 1,
        Confirmed = 2,
        Rejected = 3,
        Canceled = 4,
        Completed = 5
    }
}
