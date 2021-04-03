using Application.Contracts.Persistence;
using Application.Features.Employees.Command.UpdateEmployee;
using Application.Profiles;
using Application.UnitTest.Mocks;
using AutoMapper;
using DataTransferObjects;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTest.Commands
{
    public class UpdateEmployeeTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;

        public UpdateEmployeeTests()
        {
            _mockEmployeeRepository = RepositoryMocks.GetEmployeeRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task HandleValidEmployeUpdatedToEmployeeRepo()
        {
            var handler = new UpdateEmployeeCommandHandler(_mapper, _mockEmployeeRepository.Object);

            var employee = new EmployeeRest
            {
                Id = 5,
                FirstName = "FirstName11",
                MiddleName = "MiddleName11",
                LastName = "LastName11"
            };
            await handler.Handle(new UpdateEmployeeCommand(employee), CancellationToken.None);

            var allEmployees = await _mockEmployeeRepository.Object.GetAllAsync();
            allEmployees.Count.ShouldBe(9);
            var updatedEmployee = await _mockEmployeeRepository.Object.GetByIdAsync(5);
            updatedEmployee.FirstName.ShouldBe("FirstName11");
            updatedEmployee.MiddleName.ShouldBe("MiddleName11");
            updatedEmployee.LastName.ShouldBe("LastName11");
        }
    }
}
