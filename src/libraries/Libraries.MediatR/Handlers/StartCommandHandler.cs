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
    ///     Handler of start bot command.
    /// </summary>
    public class StartCommandHandler : IRequestHandler<StartCommand>
    {
        private readonly ILogger<StartCommandHandler> _logger;
        private readonly IPortService _portService;
        private readonly IBotService _botService;

        /// <summary>
        ///     Constructor.    
        /// </summary>
        /// <param name="logger"> Logger instance. </param>
        /// <param name="portService"> Service for working with port. </param>
        /// <param name="botService"> Service for managing telegram bot client. </param>
        public StartCommandHandler(ILogger<StartCommandHandler> logger, 
            IPortService portService,
            IBotService botService)
        {
            _logger = logger;
            _portService = portService;
            _botService = botService;
        }
        
        /// <inheritdoc cref="IRequestHandler{TRequest,TResponse}"/>
        public async Task<Unit> Handle(StartCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("[{Id}] Handle the start command", request.Id);
            
            _portService.SubscribeToReceiveLine(async text => 
                await _botService.SendTextMessageAsync(request.ChatId, text, cancellationToken));

            await _botService.SendTextMessageAsync(request.ChatId, BotMessage.Subscribe, cancellationToken);
            
            _portService.Write(BotCommand.Info);
                
            return Unit.Value;
        }
    }
}