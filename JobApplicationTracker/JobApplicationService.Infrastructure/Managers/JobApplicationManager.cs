using JobApplicationService.Core.Managers;
using JobApplicationService.Core.Models;
using JobApplicationService.Core.Repositories;

namespace JobApplicationService.Infrastructure.Managers
{
	public class JobApplicationManager : IJobApplicationManager
	{
		private readonly IJobApplicationRepository _repository;

		public JobApplicationManager(IJobApplicationRepository repository)
		{
			_repository = repository;
		}

		public async Task AddJobApplicationAsync(JobApplication jobApplication)
		{
			// Add business rules and validation here
			await _repository.AddAsync(jobApplication);
		}

		public async Task DeleteJobApplicationAsync(int id)
		{
			// Add business rules and validation here
			await _repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<JobApplication>> GetAllJobApplicationsAsync()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<JobApplication> GetJobApplicationByIdAsync(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task UpdateJobApplicationAsync(JobApplication jobApplication)
		{
			// Add business rules and validation here
			await _repository.UpdateAsync(jobApplication);
		}
	}
}