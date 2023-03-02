using Application.Dtos;
using Domain.Enums;

namespace Application.Services.Interfaces;

public interface IEmployeeLogService
{
    void CreateLog(EmployeeDto employeeDto, LogAction logAction);
}
