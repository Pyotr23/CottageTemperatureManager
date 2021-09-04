using CottageTemperature.Libraries.Core.Services;
using Telegram.Bot;

namespace CottageTemperature.Libraries.Telegram
{
    /// <inheritdoc cref="IBotService"/>
    public class BotService : IBotService
    {
        /// <inheritdoc cref="IBotService.Client"/>
        public TelegramBotClient Client { get; }

        public BotService(string accessToken)
        {
            Client = new TelegramBotClient(accessToken);
        }
    }
}