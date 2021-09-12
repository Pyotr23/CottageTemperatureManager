using System.Threading;
using System.Threading.Tasks;
using CottageTemperature.Libraries.Core.Constants;
using CottageTemperature.Libraries.MediatR.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CottageTemperature.Libraries.MediatR.Handlers
{
    /// <summary>
    ///     Handler for processing bot messages.
    /// </summary>
    public class MessageCommandHandler : IRequestHandler<MessageCommand>
    {
        private readonly ILogger<MessageCommandHandler> _logger;
        private readonly IMediator _mediator;
        
        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger instance. </param>
        /// <param name="mediator"> Mediator instance. </param>
        public MessageCommandHandler(ILogger<MessageCommandHandler> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        
        /// <inheritdoc />
        public async Task<Unit> Handle(MessageCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Start message {MessageId} handler", request.Id);

            var message = request.Message;
            BaseCommand command;

            switch (request.Text?.ToLower())
            {
                case BotCommand.Info:
                    command = new InfoCommand(message);
                    break;
                case BotCommand.Start:
                    command = new StartCommand(message);
                    break;
                case BotCommand.Stop:
                    command = new StopCommand(message);
                    break;
                default:
                    _logger.LogWarning("Unknown bot command \"{Text}\"", request.Text);
                    return Unit.Value;
            }

            await _mediator.Send(command, cancellationToken);
            return Unit.Value;
        }
    }
}