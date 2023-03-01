using Application.Dtos;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Application.Services.Service
{
    public class EmployeeService : IEmployeeService
    {
        public readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public int Create(EmployeeDto eployeeDto)
        {
            var venda = _mapper.Map<Employee>(eployeeDto);

            var vendaSalva = _employeeRepository.Create(venda);

            return vendaSalva;
        }

        public void Delete(int id)
        {
            _employeeRepository.Delete(id);
        }

        public EmployeeDto GetById(int id)
        {
            var employeeBD = _employeeRepository.GetById(id);
            var employeeDto = _mapper.Map<EmployeeDto>(employeeBD);

            return employeeDto;
        }

        public EmployeeDto Update(int id, EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
   
            var employeeUpdated = _employeeRepository.Update(id, employee);

            return _mapper.Map<EmployeeDto>(employeeUpdated);
        }
    }
}
