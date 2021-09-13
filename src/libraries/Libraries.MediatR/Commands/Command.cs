using CottageTemperature.Libraries.Core.DTOes.Telegram;

namespace CottageTemperature.Libraries.MediatR.Commands
{
    /// <summary>
    ///     Simple command.
    /// </summary>
    public record Command : BaseCommand
    {
        /// <inheritdoc />
        public Command(Message message) : base(message)
        { }
    }
}