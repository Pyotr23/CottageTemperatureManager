using System;
using CottageTemperature.Libraries.Telegram;
using CottageTemperature.Web.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CottageTemperature.Web.ServiceFactories
{
    internal static class BotServiceFactory
    {
        internal static BotService Create(IServiceProvider provider, IConfiguration configuration)
        {
            var botConfigurationSection = configuration
                .GetSection(nameof(Bot))
                .Get<Bot>();

            var logger = provider.GetRequiredService<ILogger<BotService>>();
            
            return new BotService(logger, botConfigurationSection.AccessToken);
        }
    }
}