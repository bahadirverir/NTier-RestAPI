using System.Text.Json;
using Entities.DataTransferObjects;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Abstract;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [Authorize(Roles = "User,Admin,Manager")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllEmployees(false);
            return Ok(employees);
        }

        [Authorize(Roles = "User,Admin,Manager")]
        [HttpGet("ByParameters")]
        public async Task<IActionResult> GetEmployeesByParameters([FromQuery] EmployeeParameters employeeParameters)
        {
            var result = await _employeeService.GetEmployeesByParameters(employeeParameters,false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));
            return Ok(result.employees);
        }

        [Authorize(Roles = "User,Admin,Manager")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOne([FromRoute(Name = "id")]int id)
        {
            var employee = await _employeeService.GetOneEmployeeById(id, false);
            return Ok(employee);
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        [ModelValidationFilter]
        [JsonFilter]
        public async Task<IActionResult> Post([FromBody] EmployeeDto employeeDto)
        {
            var createdEmployee = await _employeeService.CreateEmployee(employeeDto);
            return StatusCode(201,createdEmployee);
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPut("{id:int}")]
        [ModelValidationFilter]
        [JsonFilter]
        public async Task<IActionResult> Put([FromRoute(Name = "id")]int id,[FromBody] EmployeeDtoForUpdate employeeDto)
        {
            var updatedEmployee = await _employeeService.UpdateEmployee(employeeDto, id);
            return Ok(updatedEmployee);
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")]int id)
        {
            await _employeeService.DeleteEmployee(id);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpOptions]
        public IActionResult GetEmployeesOptions()
        {
            Response.Headers.Add("Allow","GET, PUT, POST, DELETE, OPTIONS, HEAD");
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpHead]
        public async Task<IActionResult> GetEmployeeHeaders([FromQuery] EmployeeParameters employeeParameters)
        {
            var result = await _employeeService.GetEmployeesByParameters(employeeParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));
            return Ok(); 
        }
    }
}