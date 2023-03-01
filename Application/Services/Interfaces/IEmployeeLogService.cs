using Application.Dtos;

namespace Application.Services.Interfaces;

public interface IEmployeeLogService
{
    void Create(EmployeeDto employeeDto);
    void Update(EmployeeDto employeeDto);
    void Delete(EmployeeDto employeeDto);
}
