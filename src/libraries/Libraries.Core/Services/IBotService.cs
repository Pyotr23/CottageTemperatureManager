using System.Threading;
using System.Threading.Tasks;
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

        /// <summary>
        ///     Send text message.
        /// </summary>
        /// <param name="chatId"> Chat identifier. </param>
        /// <param name="message"> Message for send. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns> Task. </returns>
        public Task SendTextMessageAsync(long chatId,
            string message,
            CancellationToken cancellationToken = default);
    }
}