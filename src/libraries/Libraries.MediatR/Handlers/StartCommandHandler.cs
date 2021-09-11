using System.Threading;
using System.Threading.Tasks;
using CottageTemperature.Libraries.Core.Services;
using CottageTemperature.Libraries.MediatR.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CottageTemperature.Libraries.MediatR.Handlers
{
    public class StartCommandHandler : IRequestHandler<StartCommand>
    {
        private readonly ILogger<StartCommandHandler> _logger;
        private readonly IPortService _portService;
        private readonly IBotService _botService;
        private long _chatId;

        public StartCommandHandler(ILogger<StartCommandHandler> logger, 
            IPortService portService,
            IBotService botService)
        {
            _logger = logger;
            _portService = portService;
            _botService = botService;
        }
        
        public async Task<Unit> Handle(StartCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("[{id}] Handle the start command", request.Id);
            _chatId = request.ChatId;
            _portService.SubscribeToReceiveLine(SendMessageAsync);
            return Unit.Value;
        }

        private async Task SendMessageAsync(string messageText)
        {
            await _botService.SendTextMessageAsync(_chatId, messageText);
        }
    }
}