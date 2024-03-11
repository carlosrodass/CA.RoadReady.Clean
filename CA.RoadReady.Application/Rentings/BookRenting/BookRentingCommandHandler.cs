using CA.RoadReady.Application.Abstractions.Clock;
using CA.RoadReady.Application.Abstractions.Messaging;
using CA.RoadReady.Application.Exceptions;
using CA.RoadReady.Domain.Abstractions;
using CA.RoadReady.Domain.Rentings;
using CA.RoadReady.Domain.Users;
using CA.RoadReady.Domain.Vehicles;
using System.Runtime.CompilerServices;

namespace CA.RoadReady.Application.Rentings.BookRenting
{
    internal sealed class BookRentingCommandHandler : ICommandHandler<BookRentingCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IRentingRepository _rentingRepositorsky;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PriceService _priceService;
        private readonly IDateTimeProvider _dateTimeProvider;
        public BookRentingCommandHandler(IUserRepository userRepository,
                                         IVehicleRepository vehicleRepository,
                                         IRentingRepository rentingRepositorsky,
                                         PriceService priceService,
                                         IUnitOfWork unitOfWork,
                                         IDateTimeProvider dateTimeProvider)
        {
            _userRepository = userRepository;
            _vehicleRepository = vehicleRepository;
            _rentingRepositorsky = rentingRepositorsky;
            _priceService = priceService;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<Guid>> Handle(BookRentingCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetByIdAsync(request.UserId, cancellationToken);

            if (user is null)
            {
                return Result.Failure<Guid>(UserErrors.NotFound);
            }

            var vehicle = await _vehicleRepository.GetByIdAsync(request.VehicleId, cancellationToken);

            if (vehicle is null)
            {
                return Result.Failure<Guid>(VehicleErrors.NotFound);
            }

            var duration = DateRange.Create(request.StartDate, request.EndDate);

            if (await _rentingRepositorsky.IsOverlapingAsync(vehicle, duration, cancellationToken))
            {
                return Result.Failure<Guid>(RentingErrors.Overlap);
            }

            try
            {
                var renting = Renting.Book(vehicle,
                                           request.UserId,
                                           duration,
                                           _dateTimeProvider.CurrentTime,
                                           _priceService);

                _rentingRepositorsky.Add(renting);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return renting.Id;
            }
            catch (ConcurrencyException ex)
            {
                return Result.Failure<Guid>(RentingErrors.Overlap);
            }
        }
    }
}
