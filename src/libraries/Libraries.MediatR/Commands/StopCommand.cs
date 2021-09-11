using CottageTemperature.Libraries.Core.DTOes.Telegram;

namespace CottageTemperature.Libraries.MediatR.Commands
{
    /// <summary>
    ///     Command for stopping bot.
    /// </summary>
    public record StopCommand : BaseCommand
    {
        /// <inheritdoc />
        public StopCommand(Message message) : base(message)
        {
        }
    }
}