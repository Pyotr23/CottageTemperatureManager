using CottageTemperature.Libraries.Core.DTOes.Telegram;
using MediatR;

namespace CottageTemperature.Libraries.MediatR.Commands
{
    /// <summary>
    ///     Base mediatR command.
    /// </summary>
    public record BaseCommand : IRequest<Unit>
    {
        /// <summary>
        ///     Bot message DTO.
        /// </summary>
        public Message Message { get; }

        /// <summary>
        ///     Bot message identificator.
        /// </summary>
        public int Id => Message.Id;

        /// <summary>
        ///     Chat identificator of the bot message.
        /// </summary>
        public long ChatId => Message.ChatId;

        /// <summary>
        ///     Bot message text.
        /// </summary>
        public string? Text => Message.Text;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="message"> Bot message DTO. </param>
        protected BaseCommand(Message message) => Message = message;
    }
}