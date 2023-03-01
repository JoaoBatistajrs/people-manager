using Application.Mapper;
using Application.Services.Interfaces;
using Application.Services.Service;
using Domain.Interfaces.Repositories;
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
        services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(configuration.GetConnectionString("EmployeeApiConnectionString")));
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        return services;
    }
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(DomainToDtoMapping));
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IEmployeeLogService, EmployeeLogService>();

        return services;
    }
}
