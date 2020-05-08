using MassTransit;
using Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace API1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DefaultController : ControllerBase
    {
        private readonly ILogger<DefaultController> _logger;
        private readonly IBus _bus;

        public DefaultController(ILogger<DefaultController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _bus.Publish<ToAPI2>(
                new
                {
                    Value = "From API1"
                });

            return Ok("API1");
        }
    }
}
