using Application.Contracts.Persistence;
using Application.Features.Employees.Queries;
using Application.Profiles;
using Application.UnitTest.Mocks;
using AutoMapper;
using DataTransferObjects;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTest.Queries
{
    public class GetEmployeeByIdHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;

        public GetEmployeeByIdHandlerTests()
        {
            _mockEmployeeRepository = RepositoryMocks.GetEmployeeRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetValidEmployeeIdTest()
        {
            var handler = new GetEmployeeByIdQueryHandler(_mapper, _mockEmployeeRepository.Object);
            var result = await handler.Handle(new GetEmployeeByIdQuery(3), CancellationToken.None);
            result.ShouldBeOfType<EmployeeRest>();
            result.Id.ShouldBe(3);
        }
    }
}
