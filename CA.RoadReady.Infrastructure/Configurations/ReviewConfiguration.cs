using CA.RoadReady.Domain.Rentings;
using CA.RoadReady.Domain.Reviews;
using CA.RoadReady.Domain.Users;
using CA.RoadReady.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace CA.RoadReady.Infrastructure.Configurations;

internal sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Reviews");
        builder.HasKey(review => review.Id);

        builder.Property(review => review.Rating)
                .HasConversion(rating => rating.Value, value => Rating.Create(value).Value);

        builder.Property(review => review.Comment)
                .HasMaxLength(200)
                .HasConversion(comment => comment!.Value, value => new Comment(value));

        builder.HasOne<Vehicle>()
            .WithMany()
            .HasForeignKey(review => review.VehicleId);

        builder.HasOne<Renting>()
            .WithMany()
            .HasForeignKey(review => review.RentingId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(review => review.UserId);
    }
}
