using FluentValidation.AspNetCore;

namespace PhoneBook.Contact.Api;

public static class DependencyInjections
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllersWithViews()
            .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

        return services;
    }
}