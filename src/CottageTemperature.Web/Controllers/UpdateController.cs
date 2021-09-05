using System.Threading.Tasks;
using AutoMapper;
using CottageTemperature.Libraries.MediatR.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Message = CottageTemperature.Libraries.Core.DTOes.Telegram.Message;

namespace CottageTemperature.Web.Controllers
{
    /// <summary>
    ///     Endpoint for telegram messages.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateController : Controller
    {
        private readonly ILogger<UpdateController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger instance. </param>
        /// <param name="mapper"> Mapper instance. </param>
        /// <param name="mediator"> Mediator instance. </param>
        public UpdateController(ILogger<UpdateController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        ///     Post method for receive messages from Bot (Using webhook).
        /// </summary>
        /// <param name="update"> New update from bot. </param>
        /// <exception cref="AutoMapperMappingException"> Mapping exception. </exception>
        /// <returns> Ok action. </returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            try
            {
                var message = _mapper.Map<Message>(update);
                if (message.IsCommand)
                {
                    _logger.LogInformation("Start to handle {Message}", message);
                    await _mediator.Send(new MessageCommand(message));
                }
                else
                    _logger.LogInformation("{Message} is not a command", message);
            }
            catch (AutoMapperMappingException exception)
            {
                _logger.LogError(exception, "Failed mapping from update to message");
            }
            return Ok(); 
        }
    }
}