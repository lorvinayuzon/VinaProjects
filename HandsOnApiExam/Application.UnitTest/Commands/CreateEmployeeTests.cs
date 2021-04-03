using Application.Contracts.Persistence;
using Application.Features.Employees.Command.CreateEmployee;
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
    public class CreateEmployeeTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;

        public CreateEmployeeTests()
        {
            _mockEmployeeRepository = RepositoryMocks.GetEmployeeRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task HandleValidEmployeeAddedToEmployeeRepo()
        {
            var handler = new CreateEmployeeCommandHandler(_mapper, _mockEmployeeRepository.Object);

            var employee = new EmployeeRest
            {
                FirstName = $"FirstName11",
                MiddleName = $"MiddleName11",
                LastName = $"LastName11"
            };
            await handler.Handle(new CreateEmployeeCommand(employee), CancellationToken.None);

            var allCategories = await _mockEmployeeRepository.Object.GetAllAsync();
            allCategories.Count.ShouldBe(10);
        }
    }
}
