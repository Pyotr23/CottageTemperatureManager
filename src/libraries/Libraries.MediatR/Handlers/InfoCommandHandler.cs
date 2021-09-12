using System.Threading;
using System.Threading.Tasks;
using CottageTemperature.Libraries.Core.Services;
using CottageTemperature.Libraries.MediatR.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CottageTemperature.Libraries.MediatR.Handlers
{
    /// <summary>
    ///     Handler of info command.
    /// </summary>
    public class InfoCommandHandler : IRequestHandler<InfoCommand>
    {
        private readonly ILogger<InfoCommandHandler> _logger;
        private readonly IPortService _portService;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger instance. </param>
        /// <param name="portService"> Service for working with port. </param>
        public InfoCommandHandler(ILogger<InfoCommandHandler> logger, IPortService portService)
        {
            _logger = logger;
            _portService = portService;
        }
        
        /// <inheritdoc cref="IRequestHandler{TRequest,TResponse}"/>
        public async Task<Unit> Handle(InfoCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Information command processing begins");

            if (request.Text is null)
            {
                _logger.LogWarning("Empty command text");
                return Unit.Value;
            }
                
            _portService.Write(request.Text);
            return Unit.Value;
        }
    }
}