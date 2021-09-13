using System.Threading;
using System.Threading.Tasks;
using CottageTemperature.Libraries.MediatR.Commands;
using CottageTemperature.Libraries.MediatR.Constants;
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
                case BotCommand.Start:
                    command = new StartCommand(message);
                    break;
                case BotCommand.Stop:
                    command = new StopCommand(message);
                    break;
                default:
                    command = new Command(message);;
                    break;
            }

            await _mediator.Send(command, cancellationToken);
            return Unit.Value;
        }
    }
}