using DataTransferObjects;
using MediatR;

namespace Application.Features.Employees.Command.UpdateEmployee
{
    public class UpdateEmployeeCommand: IRequest
    {
        public UpdateEmployeeCommand(EmployeeRest employee)
        {
            Id = employee.Id;
            FirstName = employee.FirstName;
            MiddleName = employee.MiddleName;
            LastName = employee.LastName;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
    }
}
