using System.Threading;
using System.Threading.Tasks;
using CottageTemperature.Libraries.Core.Services;
using CottageTemperature.Libraries.MediatR.Commands;
using CottageTemperature.Libraries.MediatR.Constants;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CottageTemperature.Libraries.MediatR.Handlers
{
    /// <summary>
    ///     Handler of stop bot command.
    /// </summary>
    public class StopCommandHandler : IRequestHandler<StopCommand>
    {
        private readonly ILogger<StopCommandHandler> _logger;
        private readonly IPortService _portService;
        private readonly IBotService _botService;

        /// <summary>
        ///     Constructor.    
        /// </summary>
        /// <param name="logger"> Logger instance. </param>
        /// <param name="portService"> Service for working with port. </param>
        /// <param name="botService"> Service for managing telegram bot client. </param>
        public StopCommandHandler(ILogger<StopCommandHandler> logger, 
            IPortService portService,
            IBotService botService)
        {
            _logger = logger;
            _portService = portService;
            _botService = botService;
        }
        
        /// <inheritdoc cref="IRequestHandler{TRequest,TResponse}"/>
        public async Task<Unit> Handle(StopCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("[{Id}] Handle the start command", request.Id);
            
            _portService.UnsubscribeToReceiveLine();
            
            await _botService.SendTextMessageAsync(request.ChatId, BotMessage.Unsubscribe, cancellationToken);

            return Unit.Value;
        }
    }
}