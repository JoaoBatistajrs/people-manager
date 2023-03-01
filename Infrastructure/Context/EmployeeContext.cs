using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class EmployeeContext : DbContext
{
    public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
    {
    }
    public DbSet<Employee> Employee { get; set; }
}
