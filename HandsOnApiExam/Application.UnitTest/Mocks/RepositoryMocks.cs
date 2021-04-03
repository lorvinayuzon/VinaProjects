using Application.Contracts.Persistence;
using Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Application.UnitTest.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IEmployeeRepository> GetEmployeeRepository()
        {
            var employees = new List<Employee>();
            for (int i = 1; i < 10; i++)
            {
                employees.Add(new Employee
                {
                    Id = i,
                    FirstName = $"FirstName{i}",
                    MiddleName = $"MiddleName{i}",
                    LastName = $"LastName{i}"
                });
            }

            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            mockEmployeeRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employees);
            mockEmployeeRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
                (int id) =>
                {
                    var getId = employees.FirstOrDefault(x => x.Id == id);
                    return getId;
                });

            mockEmployeeRepository.Setup(repo => repo.AddAsync(It.IsAny<Employee>())).ReturnsAsync(
                (Employee employee) =>
                {
                    employees.Add(employee);
                    return employee;
                });

            mockEmployeeRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Employee>()));
            mockEmployeeRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Employee>())).Callback<Employee>((employee) => employees.Remove(employee)); 

            return mockEmployeeRepository;
        }
    }
}
