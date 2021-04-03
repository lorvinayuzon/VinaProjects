using Application.Contracts.Persistence;
using Application.Features.Employees.Queries;
using Application.Profiles;
using Application.UnitTest.Mocks;
using AutoMapper;
using DataTransferObjects;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTest.Queries
{
    public class GetEmployeesListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;

        public GetEmployeesListQueryHandlerTests()
        {
            _mockEmployeeRepository = RepositoryMocks.GetEmployeeRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetEmployeesListTest()
        {
            var handler = new GetEmployeesListQueryHandler(_mapper, _mockEmployeeRepository.Object);
            var result = await handler.Handle(new GetEmployeesListQuery(), CancellationToken.None);
            result.ShouldNotBeEmpty();
            result.ShouldNotBeOfType<IEnumerable<EmployeeRest>>();
            result.Count().ShouldBe(9);
        }
    }
}
