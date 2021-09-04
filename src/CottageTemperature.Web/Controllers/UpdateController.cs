using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;

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

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger instance. </param>
        public UpdateController(ILogger<UpdateController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///     Post method for receive messages from Bot (Using webhook).
        /// </summary>
        /// <param name="update"> New update from bot. </param>
        /// <returns> Ok action. </returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            _logger.LogInformation("Start to handle update");
            return Ok(); 
        }
    }
}