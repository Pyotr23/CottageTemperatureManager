using System.Threading.Tasks;
using AutoMapper;
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

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger instance. </param>
        /// <param name="mapper"> Mapper instance. </param>
        public UpdateController(ILogger<UpdateController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        ///     Post method for receive messages from Bot (Using webhook).
        /// </summary>
        /// <param name="update"> New update from bot. </param>
        /// <returns> Ok action. </returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            try
            {
                var message = _mapper.Map<Message>(update);
                _logger.LogInformation("Start to handle {Message}", message);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Failed mapping from update to message");
            }
            return Ok(); 
        }
    }
}