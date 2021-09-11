using System.Threading;
using System.Threading.Tasks;
using CottageTemperature.Libraries.Core.Services;
using CottageTemperature.Libraries.MediatR.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CottageTemperature.Libraries.MediatR.Handlers
{
    public class StopCommandHandler : IRequestHandler<StopCommand>
    {
        private readonly ILogger<StopCommandHandler> _logger;
        private readonly IPortService _portService;
        private readonly IBotService _botService;
        private long _chatId;

        public StopCommandHandler(ILogger<StopCommandHandler> logger, 
            IPortService portService,
            IBotService botService)
        {
            _logger = logger;
            _portService = portService;
            _botService = botService;
        }
        
        public async Task<Unit> Handle(StopCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("[{id}] Handle the start command", request.Id);
            _chatId = request.ChatId;
            _portService.UnsubscribeToReceiveLine(SendMessageAsync);
            return Unit.Value;
        }

        private async Task SendMessageAsync(string messageText)
        {
            await _botService.SendTextMessageAsync(_chatId, messageText);
        }
    }
}