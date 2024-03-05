using CA.RoadReady.Domain.Shared;


namespace CA.RoadReady.Domain.Rentings
{
    public record PriceDetail(Coin PricePerTimeSpan, Coin Maintenance, Coin Accesories, Coin TotalPrice);
}
