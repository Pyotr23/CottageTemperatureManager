using System;
using System.Threading;
using System.Threading.Tasks;
using CottageTemperature.Libraries.Configuration;
using CottageTemperature.Libraries.Core.Services;
using Microsoft.Extensions.Logging;
using Telegram.Bot;

namespace CottageTemperature.Libraries.Telegram
{
    /// <inheritdoc cref="IBotService"/>
    public class BotService : IBotService
    {
        private readonly ILogger<BotService> _logger;
        
        /// <inheritdoc cref="IBotService.Client"/>
        public TelegramBotClient Client { get; }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger instance. </param>
        /// <param name="configuration"> Configuration parser. </param>
        public BotService(ILogger<BotService> logger, ConfigurationParser configuration)
        {
            _logger = logger;
            Client = new TelegramBotClient(configuration.AccessToken);
        }

        /// <summary>
        ///     Send text message.
        /// </summary>
        /// <param name="chatId"> Chat identificator. </param>
        /// <param name="message"> Response message. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        public async Task SendTextMessageAsync(long chatId, 
            string message, 
            CancellationToken cancellationToken = default)
        {
            await Client.SendTextMessageAsync(chatId, message, cancellationToken: cancellationToken);
        }
    }
}