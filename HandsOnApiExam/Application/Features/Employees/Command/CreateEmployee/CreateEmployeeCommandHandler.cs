using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Employees.Command.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepositoy;

        public CreateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepositoy)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _employeeRepositoy = employeeRepositoy ?? throw new ArgumentNullException(nameof(employeeRepositoy));
        }

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request);
            employee = await _employeeRepositoy.AddAsync(employee);
            return employee.Id;
        }
    }
}
