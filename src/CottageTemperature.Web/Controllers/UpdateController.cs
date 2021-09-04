using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;

namespace CottageTemperature.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UpdateController : Controller
    {
        private readonly ILogger<UpdateController> _logger;

        public UpdateController(ILogger<UpdateController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            _logger.LogInformation("Start to handle update");
            return Ok(); 
        }
    }
}