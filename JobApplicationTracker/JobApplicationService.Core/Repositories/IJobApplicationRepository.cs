using JobApplicationService.Core.Models;

namespace JobApplicationService.Core.Repositories
{
	public interface IJobApplicationRepository
	{
		Task AddAsync(JobApplication jobApplication);

		Task DeleteAsync(int id);

		Task<IEnumerable<JobApplication>> GetAllAsync();

		Task<JobApplication> GetByIdAsync(int id);

		Task UpdateAsync(JobApplication jobApplication);
	}
}