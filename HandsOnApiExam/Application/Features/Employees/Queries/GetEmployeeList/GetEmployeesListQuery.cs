using DataTransferObjects;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Employees.Queries
{
    public class GetEmployeesListQuery : IRequest<IEnumerable<EmployeeRest>>
    {
    }
}
