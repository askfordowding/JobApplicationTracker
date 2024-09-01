namespace JobApplicationService.Models
{
	public class JobApplication
	{
		public DateTime ApplicationDate { get; set; }
		public string ContactDetails { get; set; }
		public string CoverLetterFilePath { get; set; }
		public string CVFilePath { get; set; }
		public int Id { get; set; }
		public string MainContact { get; set; }
		public string Position { get; set; }
	}
}