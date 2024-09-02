using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.IO;

namespace JobApplicationService.IntegrationTests
{
	public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
	{
		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			builder.UseContentRoot(Directory.GetCurrentDirectory());

			builder.ConfigureServices(services =>
			{

			});
		}
	}
}
