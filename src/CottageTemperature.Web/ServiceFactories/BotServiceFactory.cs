using CottageTemperature.Libraries.Telegram;
using CottageTemperature.Web.Configurations;
using Microsoft.Extensions.Configuration;

namespace CottageTemperature.Web.ServiceFactories
{
    internal static class BotServiceFactory
    {
        internal static BotService Create(IConfiguration configuration)
        {
            var botConfigurationSection = configuration
                .GetSection(nameof(Bot))
                .Get<Bot>();
            
            return new BotService(botConfigurationSection.AccessToken);
        }
    }
}