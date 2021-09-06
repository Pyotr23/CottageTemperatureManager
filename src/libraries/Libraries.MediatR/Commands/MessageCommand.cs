using CottageTemperature.Libraries.Core.DTOes.Telegram;

namespace CottageTemperature.Libraries.MediatR.Commands
{
    /// <summary>
    ///     Сommand for selecting the bot's command handler.
    /// </summary>
    public record MessageCommand : BaseCommand
    {
        /// <inheritdoc />
        public MessageCommand(Message message) : base(message)
        { }
    }
}