using Application.Contracts.Persistence;
using AutoMapper;
using DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Employees.Queries
{
    public class GetEmployeesListQueryHandler : IRequestHandler<GetEmployeesListQuery, IEnumerable<EmployeeRest>>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepositoy;

        public GetEmployeesListQueryHandler(IMapper mapper, IEmployeeRepository employeeRepositoy)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _employeeRepositoy = employeeRepositoy ?? throw new ArgumentNullException(nameof(employeeRepositoy));
        }

        public async Task<IEnumerable<EmployeeRest>> Handle(GetEmployeesListQuery request, CancellationToken cancellationToken)
        {
            var allEmployees = await _employeeRepositoy.GetAllAsync();
            return _mapper.Map<List<EmployeeRest>>(allEmployees);
        }
    }
}
