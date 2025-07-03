using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Presentation.ActionFilters;
using Entities.RequestFeatures;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [Authorize(Roles = "User,Admin,Manager")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentService.GetAllDepartments(false);
            return Ok(departments);
        }

        [Authorize(Roles = "User,Admin,Manager")]
        [HttpGet("ByParameters")]
        public async Task<IActionResult> GetDepartmentsByParameters([FromQuery] DepartmentParameters departmentParameters)
        {
            var result = await _departmentService.GetDepartmentsByParameters(departmentParameters,false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));
            return Ok(result.departments);
        }

        [Authorize(Roles = "User,Admin,Manager")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOne([FromRoute(Name = "id")]int id)
        {
           var department = await _departmentService.GetOneDepartmentById(id, false);
           return Ok(department);
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        [ModelValidationFilter]
        [JsonFilter]
        public async Task<IActionResult> Post([FromBody] DepartmentDto departmentDto)
        {
            var createdDepartment = await _departmentService.CreateDepartment(departmentDto);
            return StatusCode(201,createdDepartment);
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPut("{id:int}")]
        [ModelValidationFilter]
        [JsonFilter]
        public async Task<IActionResult> Put([FromRoute(Name = "id")]int id,[FromBody] DepartmentDtoForUpdate departmentDto)
        {
            var updatedDepartment = await _departmentService.UpdateDepartment(departmentDto, id);
            return Ok(updatedDepartment);
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")]int id)
        {
            await _departmentService.DeleteDepartment(id);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpOptions]
        public IActionResult GetDepartmentsOptions()
        {
            Response.Headers.Add("Allow","GET, PUT, POST, DELETE, OPTIONS, HEAD");
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpHead]
        public async Task<IActionResult> GetDepartmentHeaders([FromQuery] DepartmentParameters departmentParameters)
        {
            var result = await _departmentService.GetDepartmentsByParameters(departmentParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));
            return Ok(); 
        }
    }
}