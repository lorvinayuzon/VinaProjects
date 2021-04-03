using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Employees.Command.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepositoy;

        public UpdateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepositoy)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _employeeRepositoy = employeeRepositoy ?? throw new ArgumentNullException(nameof(employeeRepositoy));
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeToUpdate = await _employeeRepositoy.GetByIdAsync(request.Id);
            if (employeeToUpdate == null)
                throw new NotFoundException(nameof(Employee), request.Id);
            _mapper.Map(request, employeeToUpdate, typeof(UpdateEmployeeCommand), typeof(Employee));
            await _employeeRepositoy.UpdateAsync(employeeToUpdate);
            return Unit.Value;
        }
    }
}
