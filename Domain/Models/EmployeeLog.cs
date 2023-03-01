using Domain.Enums;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Text.Json;

namespace Domain.Models;

public class EmployeeLog : Employee, ITableEntity
{

    public EmployeeLog(Employee employee, LogAction logAction, string partitionKey, string rowKey)
    {
        base.Id = employee.Id ;
        base.Name = employee.Name;
        base.Adress = employee.Adress;
        base.Phone = employee.Phone;
        base.ProfessionalEmail = employee.ProfessionalEmail;
        base.Department = employee.Department;
        base.Salary = employee.Salary;
        base.AdmissionDate = employee.AdmissionDate;
        LogAction = logAction;
        JSON = JsonSerializer.Serialize(employee);
        PartitionKey = partitionKey;
        RowKey = rowKey;
    }

    public LogAction LogAction { get; set; }
    public string JSON { get; set; }
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    DateTimeOffset ITableEntity.Timestamp { get; set; }
    string ITableEntity.ETag { get; set; }

    public void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
    {
        throw new NotImplementedException();
    }

    public IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
    {
        throw new NotImplementedException();
    }
}
