using Application.eTicket.MVC.Commons.Interfaces;
using Infrastructure.eTicket.MVC.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.eTicket.MVC;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(option =>
        {
            option.UseNpgsql(configuration.GetConnectionString("DbConnection"));
            option.UseLazyLoadingProxies();
        });

        return services;
    }
}
