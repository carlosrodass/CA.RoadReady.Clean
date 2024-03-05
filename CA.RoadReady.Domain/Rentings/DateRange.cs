using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Domain.Rentings
{
    public sealed record DateRange
    {
        public DateOnly Start { get; init; }
        public DateOnly End { get; init; }
        public int TotalDays => End.DayNumber - Start.DayNumber;

        private DateRange(DateOnly start, DateOnly end)
        {
            Start = start;
            End = end;
        }

        public static DateRange Create(DateOnly start, DateOnly end)
        {
            if (start > end)
            {
                throw new ApplicationException("Start Date must be smaller than End Date ");
            }

            return new DateRange(start, end);
        }

    }
}
