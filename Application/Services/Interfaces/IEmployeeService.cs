using Application.Dtos;

namespace Application.Services.Interfaces;

public interface IEmployeeService
{
    int Create(EmployeeDto vendaDto);
    EmployeeDto GetById(int id);
    void Delete(int id);
    EmployeeDto Update(int id, EmployeeDto employeeDto);
}
