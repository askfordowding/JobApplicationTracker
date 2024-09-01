using JobApplicationService.Models;
using JobApplicationService.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationService.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class JobApplicationsController : ControllerBase
	{
		private readonly IJobApplicationManager _jobApplicationManager;

		public JobApplicationsController(IJobApplicationManager jobApplicationManager)
		{
			_jobApplicationManager = jobApplicationManager;
		}

		[HttpPost]
		public async Task<ActionResult<JobApplication>> Create(JobApplication jobApplication)
		{
			await _jobApplicationManager.AddAsync(jobApplication);
			return CreatedAtAction(nameof(GetById), new { id = jobApplication.Id }, jobApplication);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _jobApplicationManager.DeleteAsync(id);
			return NoContent();
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<JobApplication>>> GetAll()
		{
			var jobApplications = await _jobApplicationManager.GetAllAsync();
			return Ok(jobApplications);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<JobApplication>> GetById(int id)
		{
			var jobApplication = await _jobApplicationManager.GetByIdAsync(id);
			if (jobApplication == null)
			{
				return NotFound();
			}
			return Ok(jobApplication);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, JobApplication jobApplication)
		{
			if (id != jobApplication.Id)
			{
				return BadRequest();
			}

			await _jobApplicationManager.UpdateAsync(jobApplication);
			return NoContent();
		}
	}
}