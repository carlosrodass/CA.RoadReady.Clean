using CA.RoadReady.Application.Abstractions.Clock;
using CA.RoadReady.Application.Abstractions.Data;
using CA.RoadReady.Application.Abstractions.Email;
using CA.RoadReady.Domain.Abstractions;
using CA.RoadReady.Domain.Rentings;
using CA.RoadReady.Domain.Users;
using CA.RoadReady.Domain.Vehicles;
using CA.RoadReady.Infrastructure.Clock;
using CA.RoadReady.Infrastructure.Data;
using CA.RoadReady.Infrastructure.Email;
using CA.RoadReady.Infrastructure.Repositories;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CA.RoadReady.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                       IConfiguration configuration)
    {


        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IEmailService, EmailServices>();

        var ConnectionString = configuration.GetConnectionString("Database") ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(ConnectionString).UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IRentingRepository, RentingRepository>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ =>
        {
            return new SqlConnectionFactory(ConnectionString);
        });

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

        return services;
    }

}
