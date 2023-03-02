using Application.Dtos;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Application.Services.Service;

public class EmployeeService : IEmployeeService
{
    public readonly IEmployeeRepository _employeeRepository;
    public readonly IEmployeeLogService _employeeLogService;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IEmployeeLogService employeeLogService)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _employeeLogService = employeeLogService;
    }

    public int Create(EmployeeDto employeeDto)
    {
        var employee = _mapper.Map<Employee>(employeeDto);

        var employeeBD = _employeeRepository.Create(employee);

        _employeeLogService.CreateLog(employeeDto, LogAction.New);

        return employeeBD;
    }

    public void Delete(int id)
    {
        var employeeBD = _employeeRepository.GetById(id);
        var employeeDto = _mapper.Map<EmployeeDto>(employeeBD);

        _employeeRepository.Delete(id);
        _employeeLogService.CreateLog(employeeDto, LogAction.Deleted);
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

        _employeeLogService.CreateLog(employeeDto, LogAction.Updated);

        return _mapper.Map<EmployeeDto>(employeeUpdated);
    }
}
