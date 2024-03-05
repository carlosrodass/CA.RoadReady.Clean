using CA.RoadReady.Domain.Abstractions;
using CA.RoadReady.Domain.Rentings;
using CA.RoadReady.Domain.Reviews.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Domain.Reviews
{
    public sealed class Review : Entity
    {
        public Guid VehicleId { get; private set; }
        public Guid RentingId { get; private set; }
        public Guid UserId { get; private set; }
        public Rating Rating { get; private set; }
        public Comment? Comment { get; private set; }
        public DateTime CreationDate { get; private set; }

        private Review(Guid id,
                       Guid vehicleId,
                       Guid rentingId,
                       Guid userId,
                       Rating rating,
                       Comment? comment,
                       DateTime creationDate) : base(id)
        {
            VehicleId = vehicleId;
            RentingId = rentingId;
            UserId = userId;
            Rating = rating;
            Comment = comment;
            CreationDate = creationDate;
        }


        public static Result<Review> Create(Renting renting,
                                            Rating rating,
                                            Comment comment,
                                            DateTime creationDate)
        {
            if (renting.Status != RentingStatus.Completed)
            {
                return Result.Failure<Review>(ReviewErrors.NotElegible);
            }

            var review = new Review(Guid.NewGuid(),
                                    renting.VehicleId,
                                    renting.Id,
                                    renting.UserId,
                                    rating,
                                    comment,
                                    creationDate);

            review.RaiseDomainEvent(new ReviewCreateDomainEvent(review.Id));

            return review;
        }


    }
}
