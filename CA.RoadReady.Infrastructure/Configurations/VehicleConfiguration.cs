using CA.RoadReady.Domain.Abstractions;
using CA.RoadReady.Domain.Shared;
using CA.RoadReady.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace CA.RoadReady.Infrastructure.Configurations;

internal sealed class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {

        builder.ToTable("Vehicles");
        builder.HasKey(vehicle => vehicle.Id);

        //Si las propiedades del objectValue son varias y primitivos
        builder.OwnsOne(vehicle => vehicle.Direction);

        //Si las propiedades del objectValue es una y primitiva
        builder.Property(vehicle => vehicle.Model)
            .HasMaxLength(200)
            .HasConversion(model => model!.Value, value => new Model(value));

        builder.Property(vehicle => vehicle.Vin)
            .HasMaxLength(500)
            .HasConversion(vin => vin!.Value, value => new Vin(value));

        //Si las propiedades del objectValue son varias y hay alguna que contiene otro objectValue en su interior
        builder.OwnsOne(vehicle => vehicle.Price, priceBuilder =>
        {
            priceBuilder.Property(coin => coin.CurrencyType)
                .HasConversion(currencyType => currencyType.Code, code => CurrencyType.FromCode(code!));
        });


        builder.OwnsOne(vehicle => vehicle.Maintenance, priceBuider =>
        {
            priceBuider.Property(coin => coin.CurrencyType)
                .HasConversion(currencyType => currencyType.Code, code => CurrencyType.FromCode(code!));
        });

        builder.Property<uint>("Version").IsRowVersion();
    }
}
