using FluentValidation;

namespace CA.RoadReady.Application.Rentings.BookRenting;



public class BookRentingCommandValidator : AbstractValidator<BookRentingCommand>
{
    public BookRentingCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.VehicleId).NotEmpty();
        RuleFor(c => c.StartDate).LessThan(c => c.EndDate);
    }


}
