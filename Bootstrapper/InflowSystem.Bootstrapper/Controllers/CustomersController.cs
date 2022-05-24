using InflowSystem.Modules.Customers.Core.Commands;
using InflowSystem.Modules.Customers.Core.DTO;
using InflowSystem.Shared.Abstractions.Dispatchers;
using InflowSystem.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace InflowSystem.Bootstrapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public CustomersController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomers(Guid customerId)
        {
            var result = await _dispatcher.QueryAsync(new GetCustomer
            {
                customerId = customerId
            });

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("PostCustomer")]
        public async Task<IActionResult> PostCustomer(CreateCustomer command)
        {
            //await _commandDispatcher.SendAsync(command);
            await _dispatcher.SendAsync(command);

            return Ok(command);
        }
    }

    internal class GetCustomer : IQuery<object>
    {
        public Guid customerId { get; set; }
    }
}
