

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace JobApplicationService.Infrastructure.Data
{
	public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

			// Automatically locate appsettings.json for the API project
			var directory = Directory.GetCurrentDirectory();
			var path = Path.Combine(directory, "../JobApplicationService.API/appsettings.json");

			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(directory)
				.AddJsonFile(path, optional: false, reloadOnChange: true)
				.Build();

			var connectionString = configuration.GetConnectionString("DefaultConnection");

			optionsBuilder.UseSqlServer(connectionString);

			return new ApplicationDbContext(optionsBuilder.Options);
		}
	}
}

