using CA.RoadReady.Domain.Rentings;
using CA.RoadReady.Domain.Shared;
using CA.RoadReady.Domain.Users;
using CA.RoadReady.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace CA.RoadReady.Infrastructure.Configurations;

internal sealed class RentingConfiguration : IEntityTypeConfiguration<Renting>
{
    public void Configure(EntityTypeBuilder<Renting> builder)
    {
        builder.ToTable("Rentings");
        builder.HasKey(renting => renting.Id);

        builder.OwnsOne(renting => renting.PricePerTimeSpan, priceBuilder =>
        {
            priceBuilder.Property(coin => coin.CurrencyType)
                .HasConversion(currencyType => currencyType.Code, code => CurrencyType.FromCode(code!));
        });


        builder.OwnsOne(renting => renting.Maintenance, priceBuilder =>
        {
            priceBuilder.Property(coin => coin.CurrencyType)
                .HasConversion(currencyType => currencyType.Code, code => CurrencyType.FromCode(code!));
        });

        builder.OwnsOne(renting => renting.Accesories, priceBuilder =>
        {
            priceBuilder.Property(coin => coin.CurrencyType)
                .HasConversion(currencyType => currencyType.Code, code => CurrencyType.FromCode(code!));
        });

        builder.OwnsOne(renting => renting.TotalAmount, priceBuilder =>
        {
            priceBuilder.Property(coin => coin.CurrencyType)
                .HasConversion(currencyType => currencyType.Code, code => CurrencyType.FromCode(code!));
        });

        builder.OwnsOne(renting => renting.Duration);


        builder.HasOne<Vehicle>()
            .WithMany()
            .HasForeignKey(renting => renting.VehicleId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(renting => renting.UserId);
    }
}
