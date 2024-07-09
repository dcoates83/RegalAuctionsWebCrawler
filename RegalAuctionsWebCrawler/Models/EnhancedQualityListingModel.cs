namespace RegalAuctionsWebCrawler.Models
{
    public class EnhancedQualityListingModel
    {
        public required ListingModel Listing { get; set; }
        public required QualityListingModel QualityListing { get; set; }
    }
}
