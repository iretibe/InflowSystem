using InflowSystem.Modules.Customers.Core.Commands;
using InflowSystem.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InflowSystem.Bootstrapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public CustomersController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost("PostCustomer")]
        public async Task<IActionResult> PostCustomer(CreateCustomer command)
        {
            await _commandDispatcher.SendAsync(command);

            return Ok(command);
        }
    }
}
