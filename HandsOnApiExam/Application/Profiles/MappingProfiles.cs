using Application.Features.Employees.Command.CreateEmployee;
using Application.Features.Employees.Command.DeleteEmployee;
using Application.Features.Employees.Command.UpdateEmployee;
using AutoMapper;
using Domain.Entities;
using DataTransferObjects;

namespace Application.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeRest>().ReverseMap();
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, DeleteEmployeeCommand>().ReverseMap();
        }
    }
}
