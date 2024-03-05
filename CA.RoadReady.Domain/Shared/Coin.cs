
namespace CA.RoadReady.Domain.Shared
{
    public record Coin(decimal Amount, CurrencyType CurrencyType)
    {
        public static Coin operator +(Coin first, Coin second)
        {
            if (first.CurrencyType != second.CurrencyType)
            {
                throw new InvalidOperationException("Currency Type must be the same");
            }

            return new Coin(first.Amount + second.Amount, first.CurrencyType);
        }

        public static Coin Zero()
        {
            return new(0, CurrencyType.None);
        }

        public static Coin Zero(CurrencyType currencyType)
        {
            return new(0, currencyType);
        }

        public bool IsZero => this == Zero(CurrencyType);
    }
}
