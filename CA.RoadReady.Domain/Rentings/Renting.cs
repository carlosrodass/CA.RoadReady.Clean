using CA.RoadReady.Domain.Abstractions;
using CA.RoadReady.Domain.Rentings.Events;
using CA.RoadReady.Domain.Shared;
using CA.RoadReady.Domain.Vehicles;


namespace CA.RoadReady.Domain.Rentings
{
    public sealed class Renting : Entity
    {

        public Guid VehicleId { get; private set; }
        public Guid UserId { get; private set; }
        public DateRange? Duration { get; private set; }
        public Coin? PricePerTimeSpan { get; private set; }
        public Coin? Maintenance { get; private set; }
        public Coin? Accesories { get; private set; }
        public Coin? TotalAmount { get; private set; }
        public RentingStatus Status { get; private set; }
        public DateTime? CreationTime { get; private set; }
        public DateTime? ConfirmationTime { get; private set; }
        public DateTime? RejectionTime { get; private set; }
        public DateTime? CompletionTime { get; private set; }
        public DateTime? CancelationTime { get; private set; }


        private Renting(Guid id,
                        Guid vehicleId,
                        Guid userId,
                        DateRange? duration,
                        Coin? pricePerTimeSpan,
                        Coin? maintenance,
                        Coin? accesories,
                        Coin? totalAmount,
                        RentingStatus status,
                        DateTime? creationTime) : base(id)
        {
            VehicleId = vehicleId;
            UserId = userId;
            PricePerTimeSpan = pricePerTimeSpan;
            Maintenance = maintenance;
            Accesories = accesories;
            TotalAmount = totalAmount;
            Status = status;
            Duration = duration;
            CreationTime = creationTime;
        }


        public static Renting Book(Vehicle vehicle, Guid userId, DateRange? duration, DateTime? creationTime, PriceService priceService)
        {
            PriceDetail priceDetail = priceService.CalculatePrice(vehicle, duration);

            var renting = new Renting(Guid.NewGuid(),
                                      vehicle.Id,
                                      userId,
                                      duration,
                                      priceDetail.PricePerTimeSpan,
                                      priceDetail.Maintenance,
                                      priceDetail.Accesories,
                                      priceDetail.TotalPrice,
                                      RentingStatus.Reserved,
                                      creationTime);

            renting.RaiseDomainEvent(new BookingReservedDomainEvent(renting.Id));

            vehicle.LastRentDate = creationTime;

            return renting;
        }

        public Result Confirm(DateTime utcNow)
        {
            if (Status != RentingStatus.Reserved)
            {
                return Result.Failure(RentingErrors.NotReserved);
            }

            Status = RentingStatus.Confirmed;
            ConfirmationTime = utcNow;

            RaiseDomainEvent(new BookingConfirmedDomainEvent(Id));
            return Result.Success();
        }

        public Result Reject(DateTime utcNow)
        {
            if (Status != RentingStatus.Reserved)
            {
                return Result.Failure(RentingErrors.NotReserved);
            }


            Status = RentingStatus.Rejected;
            RejectionTime = utcNow;
            RaiseDomainEvent(new BookingRejectedDomainEvent(Id));

            return Result.Success();
        }

        public Result Cancel(DateTime utcNow)
        {
            if (Status != RentingStatus.Confirmed)
            {
                return Result.Failure(RentingErrors.NotConfirmed);
            }

            var currentDate = DateOnly.FromDateTime(utcNow);
            if (currentDate > Duration!.Start)
            {
                return Result.Failure(RentingErrors.AlreadyStarted);
            }

            Status = RentingStatus.Canceled;
            CancelationTime = utcNow;
            RaiseDomainEvent(new BookingCanceledDomainEvent(Id));

            return Result.Success();
        }


        public Result Complete(DateTime utcNow)
        {
            if (Status != RentingStatus.Confirmed)
            {
                return Result.Failure(RentingErrors.NotConfirmed);
            }


            Status = RentingStatus.Completed;
            CompletionTime = utcNow;
            RaiseDomainEvent(new BookingCompletedDomainEvent(Id));

            return Result.Success();
        }


    }
}







