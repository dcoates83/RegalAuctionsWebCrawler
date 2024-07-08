namespace RegalAuctionsWebCrawler.Models
{
    public class ListingModel
    {
        public required string Title { get; set; }
        public required string Reserve { get; set; }
        public required string Odometer { get; set; }
        public DateTime SaleDate { get; set; }
        public required string LotNumber { get; set; }
        public required string Seller { get; set; }
        public required string Options { get; set; }
        public required string URL { get; set; }
        public required string ImageURL { get; set; }
        public string? Other { get; set; }

    }
}
