using System.Threading;
using System.Threading.Tasks;
using CottageTemperature.Libraries.MediatR.Commands;
using MediatR;

namespace CottageTemperature.Libraries.MediatR.Handlers
{
    public class StartCommandHandler : IRequestHandler<StartCommand>
    {
        public async Task<Unit> Handle(StartCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}