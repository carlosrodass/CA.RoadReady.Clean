﻿using CA.RoadReady.Application.Abstractions.Email;
using CA.RoadReady.Domain.Rentings;
using CA.RoadReady.Domain.Rentings.Events;
using CA.RoadReady.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Application.Rentings.BookRenting
{
    internal sealed class BookingReservedDomainEventHandler
        : INotificationHandler<BookingReservedDomainEvent>
    {

        private readonly IRentingRepository _rentingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public BookingReservedDomainEventHandler(IRentingRepository rentingRepository,
                                                 IUserRepository userRepository,
                                                 IEmailService emailService)
        {
            _rentingRepository = rentingRepository;
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task Handle(BookingReservedDomainEvent notification,
                                 CancellationToken cancellationToken)
        {

            var booking = await _rentingRepository.GetByIdAsync(notification.RentingId, cancellationToken);

            if (booking is null)
            {
                return;
            }

            var user = await _userRepository.GetByIdAsync(booking.UserId, cancellationToken);

            if (user is null)
            {
                return;
            }

            await _emailService.SendAsync(
                user.Email!,
                "Renting Reserved",
                "You must comfirm this reserved");

        }
    }
}
