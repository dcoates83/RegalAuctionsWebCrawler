namespace RegalAuctionsWebCrawler.Models
{
    public class ListingModel
    {
        public required string Title { get; set; }
        public int Reserve { get; set; }
        public int Odometer { get; set; }
        public DateTime SaleDate { get; set; }
        public required string LotNumber { get; set; }
        public required string Seller { get; set; }
        public required string Options { get; set; }
        public required string URL { get; set; }
        public required string ImageURL { get; set; }

    }
}
