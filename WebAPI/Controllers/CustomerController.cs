using Application.Handlers.Customer.Commands.DeleteCustomer;
using Application.Handlers.Customer.Commands.InsertCustomer;
using Application.Handlers.Customer.Commands.UpdateCustomer;
using Application.Handlers.Customer.Queries.GetCustomerByName;
using Application.Handlers.Customer.Queries.GetCustomer;
using Application.Handlers.Customer.Queries.GetCustomerList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace API.Controllers
{
    [ApiController]
    public class CustomerController(IMediator? mediator) : ControllerBase
    {
        private IMediator? Mediator => mediator ?? HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers(CancellationToken cancellationToken)
        {
            var data = await Mediator?.Send(new GetCustomerListQuery(), cancellationToken)!;

            return Ok(data);
        }

        [HttpGet("GetCustomerByName")]
        public async Task<IActionResult> GetCustomerByName(string name, CancellationToken cancellationToken)
        {
            var data = await Mediator?.Send(new GetCustomerByNameQuery(name), cancellationToken)!;

            return Ok(data);
        }

        [HttpGet("GetCustomer/{id}")]
        public async Task<IActionResult> GetCustomer(int id, CancellationToken cancellationToken)
        {
            var data = await Mediator?.Send(new GetCustomerQuery(id), cancellationToken)!;

            return Ok(data);
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(InsertCustomerCommand command, CancellationToken cancellationToken)
        {
            var data = await Mediator?.Send(command, cancellationToken)!;

            return Ok(data);
        }

        [HttpPut("UpdateCustomer/{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var data = await Mediator?.Send(command, cancellationToken)!;

            return Ok(data);
        }

        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id, CancellationToken cancellationToken)
        {
            var data = await Mediator?.Send(new DeleteCustomerCommand(id), cancellationToken)!;

            return Ok(data);
        }
    }
}
