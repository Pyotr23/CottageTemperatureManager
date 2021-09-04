using CottageTemperature.Libraries.Core.Services;
using Microsoft.Extensions.Logging;
using Telegram.Bot;

namespace CottageTemperature.Libraries.Telegram
{
    /// <inheritdoc cref="IBotService"/>
    public class BotService : IBotService
    {
        private readonly ILogger<BotService> _logger;
        private readonly string? _accessToken;
        
        /// <inheritdoc cref="IBotService.Client"/>
        public TelegramBotClient Client { get; }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger instance. </param>
        /// <param name="accessToken"> Access token. </param>
        public BotService(ILogger<BotService> logger, string? accessToken)
        {
            _logger = logger;
            _accessToken = accessToken;
            Client = new TelegramBotClient(accessToken);
        }
    }
}