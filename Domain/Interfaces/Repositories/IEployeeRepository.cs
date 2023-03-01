using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IEployeeRepository
{
    Employee GetById(int id);
    int Create(Employee employee);
    Employee Update(int id, Employee employee);
    void Delete(int id);
}
