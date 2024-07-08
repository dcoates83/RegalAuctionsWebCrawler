namespace RegalAuctionsWebCrawler.Models
{
    public class EmailSettings
    {
        public required string SenderEmail { get; set; }
        public required string Password { get; set; }
        public required string RecipientEmail { get; set; }
        public required List<string> CcEmails { get; set; }
    }
}
