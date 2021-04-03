using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts.Persistence
{
    public interface IEmployeeRepository: IAsyncRepository<Employee>
    {
    }
}
