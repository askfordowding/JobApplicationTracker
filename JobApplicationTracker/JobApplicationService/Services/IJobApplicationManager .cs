using JobApplicationService.Models;

namespace JobApplicationService.Services
{
	public interface IJobApplicationManager
	{
		Task AddAsync(JobApplication jobApplication);

		Task DeleteAsync(int id);

		Task<IEnumerable<JobApplication>> GetAllAsync();

		Task<JobApplication> GetByIdAsync(int id);

		Task UpdateAsync(JobApplication jobApplication);
	}
}