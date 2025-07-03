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
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [Authorize(Roles = "User,Admin,Manager")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobs = await _jobService.GetAllJobs(false);
            return Ok(jobs);
        }

        [Authorize(Roles = "User,Admin,Manager")]
        [HttpGet("ByParameters")]
        public async Task<IActionResult> GetJobsByParameters([FromQuery] JobParameters jobParameters)
        {
            var result = await _jobService.GetJobsByParameters(jobParameters,false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));
            return Ok(result.jobs);
        }

        [Authorize(Roles = "User,Admin,Manager")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOne([FromRoute(Name = "id")]int id)
        {
            var job = await _jobService.GetOneJobById(id, false);
            return Ok(job);
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        [ModelValidationFilter]
        [JsonFilter]
        public async Task<IActionResult> Post([FromBody] JobDto jobDto)
        {
            var createdJob = await _jobService.CreateJob(jobDto);
            return StatusCode(201,createdJob);
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPut("{id:int}")]
        [ModelValidationFilter]
        [JsonFilter]
        public async Task<IActionResult> Put([FromRoute(Name = "id")]int id,[FromBody] JobDtoForUpdate jobDto)
        {
            var updatedJob = await _jobService.UpdateJob(jobDto, id);
            return Ok(updatedJob);
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")]int id)
        {
            await _jobService.DeleteJob(id);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpOptions]
        public IActionResult GetJobsOptions()
        {
            Response.Headers.Add("Allow","GET, PUT, POST, DELETE, OPTIONS, HEAD");
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpHead]
        public async Task<IActionResult> GetJobHeaders([FromQuery] JobParameters jobParameters)
        {
            var result = await _jobService.GetJobsByParameters(jobParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));
            return Ok(); 
        }
    }
}