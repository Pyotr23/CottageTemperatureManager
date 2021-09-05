using CottageTemperature.Libraries.Core.DTOes.Telegram;

namespace CottageTemperature.Libraries.MediatR.Commands
{
    /// <summary>
    ///     Info command.
    /// </summary>
    public record InfoCommand : BaseCommand
    {
        /// <inheritdoc />
        public InfoCommand(Message message) : base(message)
        { }
    }
}