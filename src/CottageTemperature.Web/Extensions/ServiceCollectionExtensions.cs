using CottageTemperature.Libraries.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CottageTemperature.Web.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddConfigurationParser(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddSingleton(provider =>
                {
                    var logger = provider.GetRequiredService<ILogger<ConfigurationParser>>();
                    return new ConfigurationParser(logger, configuration);
                });
        }
    }
}