using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using DataTransferObjects;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Employees.Queries
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeRest>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepositoy;

        public GetEmployeeByIdQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _employeeRepositoy = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<EmployeeRest> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepositoy.GetByIdAsync(request.Id);
            if (employee == null)
                throw new NotFoundException(nameof(Employee), request.Id);
            return _mapper.Map<EmployeeRest>(employee);
        }
    }
}
