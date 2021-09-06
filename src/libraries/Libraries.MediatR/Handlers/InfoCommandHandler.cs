using System.Threading;
using System.Threading.Tasks;
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

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger instance. </param>
        public InfoCommandHandler(ILogger<InfoCommandHandler> logger)
        {
            _logger = logger;
        }
        
        /// <inheritdoc cref="IRequestHandler{TRequest,TResponse}"/>
        public async Task<Unit> Handle(InfoCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}