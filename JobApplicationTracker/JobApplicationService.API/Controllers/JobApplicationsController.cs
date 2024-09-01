using JobApplicationService.Core.Models;
using JobApplicationService.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class JobApplicationsController : ControllerBase
{
	private readonly IJobApplicationRepository _repository;

	public JobApplicationsController(IJobApplicationRepository repository)
	{
		_repository = repository;
	}

	[HttpPost]
	public async Task<ActionResult<JobApplication>> Create(JobApplication jobApplication)
	{
		await _repository.AddAsync(jobApplication);
		return CreatedAtAction(nameof(GetById), new { id = jobApplication.Id }, jobApplication);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		await _repository.DeleteAsync(id);
		return NoContent();
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<JobApplication>>> GetAll()
	{
		var jobApplications = await _repository.GetAllAsync();
		return Ok(jobApplications);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<JobApplication>> GetById(int id)
	{
		var jobApplication = await _repository.GetByIdAsync(id);
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
		await _repository.UpdateAsync(jobApplication);
		return NoContent();
	}
}