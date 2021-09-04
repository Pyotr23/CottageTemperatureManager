using Telegram.Bot;

namespace CottageTemperature.Libraries.Core.Services
{
    /// <summary>
    ///     Service for managing telegram bot client.
    /// </summary>
    public interface IBotService
    {
        /// <summary>
        ///     Telegram bot client.
        /// </summary>
        public TelegramBotClient Client { get; }
    }
}