using Application.Contracts.Persistence;
using Application.Features.Employees.Command.DeleteEmployee;
using Application.Profiles;
using Application.UnitTest.Mocks;
using AutoMapper;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTest.Commands
{
    public class DeleteEmployeeTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;

        public DeleteEmployeeTests()
        {
            _mockEmployeeRepository = RepositoryMocks.GetEmployeeRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task HandleValidEmployeeDeletedToEmployeeRepo()
        {
            var handler = new DeleteEmployeeCommandHandler(_mapper, _mockEmployeeRepository.Object);
            await handler.Handle(new DeleteEmployeeCommand(4), CancellationToken.None);

            var allCategories = await _mockEmployeeRepository.Object.GetAllAsync();
            allCategories.Count.ShouldBe(8);
        }
    }
}
