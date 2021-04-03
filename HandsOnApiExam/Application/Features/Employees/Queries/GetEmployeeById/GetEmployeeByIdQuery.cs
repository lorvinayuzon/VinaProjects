using DataTransferObjects;
using MediatR;
using System;

namespace Application.Features.Employees.Queries
{
    public class GetEmployeeByIdQuery: IRequest<EmployeeRest>
    {
        public int Id { get; }

        public GetEmployeeByIdQuery(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            Id = id;
        }
    }
}
