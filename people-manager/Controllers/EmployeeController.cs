using Application.Dtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace people_manager.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    public readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost]
    public IActionResult Create(EmployeeDto employeeDto)
    {
        if(employeeDto.Equals(null))
            return BadRequest();

        var employee = _employeeService.Create(employeeDto);

        return Ok(employee);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _employeeService.GetById(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateById(int id, EmployeeDto employeeDto)
    {
        var result = _employeeService.Update(id, employeeDto);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult UpdateById(int id)
    {
        var result = _employeeService.GetById(id);

        if (result == null)
            return NotFound();

        _employeeService.Delete(result.Id);

        return NoContent();
    }
}
