namespace JobApplicationService.Core.Models
{
	public class JobApplication
	{
		public string Company { get; set; }
		public string CoverLetter { get; set; }
		public string CVPath { get; set; }
		public DateTime DateOfApplication { get; set; } = DateTime.Now;
		public int Id { get; set; }
		public DateTime? InterviewDate { get; set; }
		public string Status { get; set; }
		public string MainContact { get; set; }
		public string Notes { get; set; }
		public string Position { get; set; }
	}
}