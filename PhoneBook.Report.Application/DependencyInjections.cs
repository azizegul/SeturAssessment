using System.Reflection;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Report.Application.EventHandlers;

namespace PhoneBook.Report.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)

    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // services.AddMassTransitService(configuration);
        return services;
    }

    // private static IServiceCollection AddMassTransitService(this IServiceCollection services,
    //     IConfiguration configuration)
    // {
    //     services.AddMassTransit(x =>
    //     {
    //         x.AddConsumers(typeof(PrepareReportWhenReportCreatedEventHandler).Assembly);
    //
    //         x.SetKebabCaseEndpointNameFormatter();
    //
    //         x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));
    //     });
    //
    //     services.Configure<MassTransitHostOptions>(options => { options.WaitUntilStarted = true; });
    //
    //     return services;
    // }
}