using JobApplicationService.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationService.Infrastructure.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<JobApplication> JobApplications { get; set; }
	}
}