using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Domain.Shared
{
    public record CurrencyType
    {
        public static readonly CurrencyType None = new(" ");

        public static readonly CurrencyType Usd = new("USD");

        public static readonly CurrencyType Eur = new("EUR");

        public string? Code { get; init; }

        private CurrencyType(string code)
        {
            Code = code;
        }

        public static readonly IReadOnlyCollection<CurrencyType> All =
        [
            Usd,
            Eur
        ];


        public static CurrencyType FromCode(string code)
        {
            return All.FirstOrDefault(c => c.Code == code) ?? throw new ApplicationException("Invalid Currency type");
        }

    }
}
