using MediatR;

namespace Application.Features.Employees.Command.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest
    {
        public DeleteEmployeeCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
