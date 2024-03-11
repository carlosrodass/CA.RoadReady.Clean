using CA.RoadReady.Application.Behaviors;
using CA.RoadReady.Domain.Rentings;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace CA.RoadReady.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddTransient<PriceService>();


        return services;
    }

}
