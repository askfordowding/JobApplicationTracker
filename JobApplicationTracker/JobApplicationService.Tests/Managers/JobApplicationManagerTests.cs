using JobApplicationService.Core.Managers;
using JobApplicationService.Core.Models;
using JobApplicationService.Core.Repositories;
using JobApplicationService.Infrastructure.Managers;
using Moq;

namespace JobApplicationService.Tests.Managers
{
	public class JobApplicationManagerTests
	{
		private readonly IJobApplicationManager _manager;
		private readonly Mock<IJobApplicationRepository> _mockRepository;

		public JobApplicationManagerTests()
		{
			_mockRepository = new Mock<IJobApplicationRepository>();
			_manager = new JobApplicationManager(_mockRepository.Object);
		}

		[Fact]
		public async Task AddJobApplicationAsync_CallsRepositoryAdd()
		{
			// Arrange
			var jobApplication = new JobApplication { Id = 1, Position = "Developer" };

			// Act
			await _manager.AddJobApplicationAsync(jobApplication);

			// Assert
			_mockRepository.Verify(repo => repo.AddAsync(jobApplication), Times.Once);
		}

		[Fact]
		public async Task DeleteJobApplicationAsync_CallsRepositoryDelete()
		{
			// Arrange
			var id = 1;

			// Act
			await _manager.DeleteJobApplicationAsync(id);

			// Assert
			_mockRepository.Verify(repo => repo.DeleteAsync(id), Times.Once);
		}

		[Fact]
		public async Task GetAllJobApplicationsAsync_ReturnsAllApplications()
		{
			// Arrange
			var jobApplications = new List<JobApplication>
			{
				new JobApplication { Id = 1, Position = "Developer" },
				new JobApplication { Id = 2, Position = "Tester" }
			};
			_mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(jobApplications);

			// Act
			var result = await _manager.GetAllJobApplicationsAsync();

			// Assert
			Assert.Equal(2, result.Count());
		}

		[Fact]
		public async Task GetJobApplicationByIdAsync_ReturnsCorrectApplication()
		{
			// Arrange
			var jobApplication = new JobApplication { Id = 1, Position = "Developer" };
			_mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(jobApplication);

			// Act
			var result = await _manager.GetJobApplicationByIdAsync(1);

			// Assert
			Assert.Equal("Developer", result.Position);
		}

		[Fact]
		public async Task UpdateJobApplicationAsync_CallsRepositoryUpdate()
		{
			// Arrange
			var jobApplication = new JobApplication { Id = 1, Position = "Developer" };

			// Act
			await _manager.UpdateJobApplicationAsync(jobApplication);

			// Assert
			_mockRepository.Verify(repo => repo.UpdateAsync(jobApplication), Times.Once);
		}
	}
}