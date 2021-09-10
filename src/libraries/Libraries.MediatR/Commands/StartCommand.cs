using CottageTemperature.Libraries.Core.DTOes.Telegram;

namespace CottageTemperature.Libraries.MediatR.Commands
{
    /// <summary>
    ///     Start bot command.
    /// </summary>
    public record StartCommand : BaseCommand
    {
        
        /// <inheritdoc />
        protected StartCommand(Message message) : base(message)
        { }
    }
}