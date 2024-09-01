using JobApplicationService.Core.Models;
using JobApplicationService.Core.Repositories;
using JobApplicationService.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace JobApplicationService.Infrastructure.Repositories
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
			_context.Entry(jobApplication).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}