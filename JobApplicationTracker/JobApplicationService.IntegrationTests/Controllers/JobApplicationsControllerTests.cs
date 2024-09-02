using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace JobApplicationService.IntegrationTests.Controllers
{
	public class JobApplicationsControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
	{
		private readonly HttpClient _client;
		private readonly CustomWebApplicationFactory<Program> _factory;

		public JobApplicationsControllerTests(CustomWebApplicationFactory<Program> factory)
		{
			_factory = factory;
			_client = factory.CreateClient(); // Create an HttpClient to send requests to the test server
		}

		//[Fact]
		//public async Task Delete_JobApplication_ReturnsNoContent()
		//{
		//	// Arrange
		//	var requestUri = "/api/jobapplications/1"; // Example URI

		//	// Act
		//	var response = await _client.DeleteAsync(requestUri);

		//	// Assert
		//	response.EnsureSuccessStatusCode(); // Check if the response status is successful
		//	Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode); // Check for NoContent status
		//}
	}
}
