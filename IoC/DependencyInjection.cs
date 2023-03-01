using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraStrucuture(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(configuration.GetConnectionString("PaymentApiConnectionString")));
        services.AddScoped<EmployeeRepository, EmployeeRepository>();

        return services;
    }
}
