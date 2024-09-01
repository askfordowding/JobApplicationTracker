using JobApplicationService.Core.Models;

namespace JobApplicationService.Core.Managers
{
	public interface IJobApplicationManager
	{
		Task AddJobApplicationAsync(JobApplication jobApplication);

		Task DeleteJobApplicationAsync(int id);

		Task<IEnumerable<JobApplication>> GetAllJobApplicationsAsync();

		Task<JobApplication> GetJobApplicationByIdAsync(int id);

		Task UpdateJobApplicationAsync(JobApplication jobApplication);
	}
}