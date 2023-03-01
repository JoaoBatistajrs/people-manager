using AutoMapper;
using Domain.Models;
using Application.Dtos;

namespace Application.Mapper
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
