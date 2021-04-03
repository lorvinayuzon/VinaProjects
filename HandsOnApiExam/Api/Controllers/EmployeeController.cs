using Application.Features.Employees.Command.CreateEmployee;
using Application.Features.Employees.Command.DeleteEmployee;
using Application.Features.Employees.Command.UpdateEmployee;
using Application.Features.Employees.Queries;
using DataTransferObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnExamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeRest>>> Get()
        {
            var dtos = await _mediator.Send(new GetEmployeesListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeRest>> Get(int id)
        {
            var dtos = await _mediator.Send(new GetEmployeeByIdQuery(id));
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(EmployeeRest employee)
        {
            var command = new CreateEmployeeCommand(employee);
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(EmployeeRest employee)
        {
            var command = new UpdateEmployeeCommand(employee);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteEmployeeCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
