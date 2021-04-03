using DataTransferObjects;
using MediatR;

namespace Application.Features.Employees.Command.CreateEmployee
{
    public class CreateEmployeeCommand: IRequest<int>
    {
        public CreateEmployeeCommand(EmployeeRest employee)
        {
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
