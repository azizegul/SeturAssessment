using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Report.Application.Common.Interfaces;
using PhoneBook.Report.Infrastructure.Persistence;

namespace PhoneBook.Report.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        return services;
    }
}