using Application.Dtos;
using Domain.Models;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Azure.Data.Tables;
using Application.Services.Interfaces;
using Domain.Enums;

namespace Application.Services.Service;

public class EmployeeLogService : IEmployeeLogService
{
    private readonly IMapper _mapper;
    private readonly string _connectionString;
    private readonly string _tableName;

    public EmployeeLogService(IMapper mapper, IConfiguration configuration)
    {
        _mapper = mapper;
        _connectionString = configuration.GetConnectionString("SAConnectionString");
        _tableName = configuration.GetConnectionString("EmployeeLog");
    }

    private TableClient GetTableClient()
    {
        var serviceClient = new TableServiceClient(_connectionString);
        var tableClient = serviceClient.GetTableClient(_tableName);

        tableClient.CreateIfNotExists();
        return tableClient;
    }

    public void CreateLog(EmployeeDto employeeDto, LogAction logAction)
    {
        var tableClient = GetTableClient();
        var employee = _mapper.Map<Employee>(employeeDto);
        var partitionKey = Guid.NewGuid().ToString();

        var employeeLog = new EmployeeLog(employee, logAction, partitionKey, employeeDto.Department);

        tableClient.UpsertEntity(employeeLog);
    }
}