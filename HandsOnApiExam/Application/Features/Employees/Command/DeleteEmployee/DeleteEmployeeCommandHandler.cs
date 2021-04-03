using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Employees.Command.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepositoy;

        public DeleteEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepositoy)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _employeeRepositoy = employeeRepositoy ?? throw new ArgumentNullException(nameof(employeeRepositoy));
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeToDelete = await _employeeRepositoy.GetByIdAsync(request.Id);
            if (employeeToDelete == null)
                throw new NotFoundException(nameof(Employee), request.Id);
            await _employeeRepositoy.DeleteAsync(employeeToDelete);
            return Unit.Value;
        }
    }
}
