using AutoMapper;
using DL;
using DTO;
using Entities_.Models;

namespace server
{
public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Employees, EmployeeData>();
            CreateMap<EmployeeData, Employees >();
        }
    }
}

