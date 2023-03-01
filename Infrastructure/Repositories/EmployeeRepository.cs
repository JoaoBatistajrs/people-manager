using Domain.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public int Create(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();

            return employee.Id;
        }

        public void Delete(int id)
        {          
            _context.Remove(GetById(id));
            _context.SaveChanges();
        }

        public Employee GetById(int id)
        {
            var employeeDb = _context.Employee.Find(id);

            if (employeeDb == null)
                return null;

            return employeeDb;
        }

        public Employee Update(int id, Employee employee)
        {
            var employeeDb = GetById(id);

            employeeDb.Name = employee.Name;
            employeeDb.Adress = employee.Adress;
            employeeDb.ProfessionalEmail = employee.ProfessionalEmail;
            employeeDb.Salary = employee.Salary;
            employeeDb.Department = employee.Department;
            employeeDb.Phone = employee.Phone;

            _context.Update(employeeDb);
            _context.SaveChanges();

            return employeeDb;
        }
    }
}
