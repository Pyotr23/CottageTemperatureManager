using CottageTemperature.Web.ServiceFactories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CottageTemperature.Web.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddSingleton(provider => BotServiceFactory.Create(provider, configuration));
        }
    }
}