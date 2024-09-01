using JobApplicationService.Data.Repositories;
using JobApplicationService.Models;

namespace JobApplicationService.Services
{
	public class JobApplicationManager : IJobApplicationManager
	{
		private readonly IJobApplicationRepository _repository;

		public JobApplicationManager(IJobApplicationRepository repository)
		{
			_repository = repository;
		}

		public async Task AddAsync(JobApplication jobApplication)
		{
			await _repository.AddAsync(jobApplication);
		}

		public async Task DeleteAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<JobApplication>> GetAllAsync()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<JobApplication> GetByIdAsync(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task UpdateAsync(JobApplication jobApplication)
		{
			await _repository.UpdateAsync(jobApplication);
		}
	}
}