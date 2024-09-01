using JobApplicationService.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationService.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<JobApplication> JobApplications { get; set; }
	}
}