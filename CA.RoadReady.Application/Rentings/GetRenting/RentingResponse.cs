

namespace CA.RoadReady.Application.Rentings.GetRenting;

public sealed class RentingResponse
{

    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public Guid VehicleId { get; init; }
    public int Status { get; init; }
    public decimal PricePerTimeSpan { get; init; }
    public string? RentingCurrencyType { get; init; }
    public decimal MaintenancePrice { get; init; }
    public string? MaintenanceCurrencyType { get; init; }
    public decimal AccesoriesPrice { get; init; }
    public string? AccesoryCurrencyType { get; init; }
    public decimal TotalPrice { get; init; }
    public string? TotalCurrencyType { get; init; }
    public DateOnly DurationStart { get; init; }
    public DateOnly DurationEnd { get; init; }
    public DateTime CreationDate { get; init; }

}
