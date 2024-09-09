// Controllers/JobApplicationsController.cs
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
	public async Task<ActionResult<JobApplication>> Create([FromBody] JobApplication jobApplication)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}

		await _repository.AddAsync(jobApplication);
		return CreatedAtAction(nameof(GetById), new { id = jobApplication.Id }, jobApplication);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		var existing = await _repository.GetByIdAsync(id);
		if (existing == null)
		{
			return NotFound();
		}

		await _repository.DeleteAsync(id);
		return NoContent();
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<JobApplication>>> GetAll(int page = 1, int pageSize = 10)
	{
		var jobApplications = await _repository.GetAllAsync();

		var paginatedApplications = jobApplications
			.Skip((page - 1) * pageSize)
			.Take(pageSize)
			.ToList();

		return Ok(paginatedApplications);
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
	public async Task<IActionResult> Update(int id, [FromBody] JobApplication jobApplication)
	{
		if (id != jobApplication.Id)
		{
			return BadRequest("ID mismatch.");
		}

		var existing = await _repository.GetByIdAsync(id);
		if (existing == null)
		{
			return NotFound();
		}

		await _repository.UpdateAsync(jobApplication);
		return NoContent();
	}
}
