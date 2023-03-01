using Application.Dtos;
using AutoMapper;
using Domain.Models;

namespace Application.Mapper
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<EmployeeDto, Employee>();
        }
    }
}
