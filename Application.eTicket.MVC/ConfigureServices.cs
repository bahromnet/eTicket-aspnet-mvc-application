using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.eTicket.MVC;
public static class ConfigureServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

        });

        return services;
    }
}
