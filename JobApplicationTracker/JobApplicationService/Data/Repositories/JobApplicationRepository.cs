using JobApplicationService.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationService.Data.Repositories
{
	public class JobApplicationRepository : IJobApplicationRepository
	{
		private readonly ApplicationDbContext _context;

		public JobApplicationRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(JobApplication jobApplication)
		{
			_context.JobApplications.Add(jobApplication);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var jobApplication = await _context.JobApplications.FindAsync(id);
			if (jobApplication != null)
			{
				_context.JobApplications.Remove(jobApplication);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<JobApplication>> GetAllAsync()
		{
			return await _context.JobApplications.ToListAsync();
		}

		public async Task<JobApplication> GetByIdAsync(int id)
		{
			return await _context.JobApplications.FindAsync(id);
		}

		public async Task UpdateAsync(JobApplication jobApplication)
		{
			_context.JobApplications.Update(jobApplication);
			await _context.SaveChangesAsync();
		}
	}
}