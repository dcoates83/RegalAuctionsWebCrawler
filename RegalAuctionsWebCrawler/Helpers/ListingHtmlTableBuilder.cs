using RegalAuctionsWebCrawler.Models;
using System.Text;

namespace RegalAuctionsWebCrawler.Helpers
{
    public class HtmlTableBuilder
    {
        public string BuildTable(List<EnhancedQualityListingModel> listings)
        {
            StringBuilder html = new();

            html.Append("<div>");

            foreach (EnhancedQualityListingModel listing in listings)
            {
                html.Append("<div style='margin-bottom: 10px; border: 1px solid #ddd; padding: 10px;'>");

                // Auction listing details on top
                html.Append("<div style='margin: 5px;'>");
                html.Append($"<strong>Auction Title:</strong> <a href='{listing.Listing.URL}'>{listing.Listing.Title}</a><br>");
                html.Append($"<strong>Reserve:</strong> {listing.Listing.Reserve}<br>");
                html.Append($"<strong>Odometer:</strong> {listing.Listing.Odometer}<br>");
                html.Append($"<strong>Sale Date:</strong> {listing.Listing.SaleDate}<br>");
                html.Append($"<strong>Options:</strong> {listing.Listing.Options}<br>");
                html.Append($"<strong>Other:</strong> {listing.Listing.Other ?? ""}<br>");
                html.Append("</div>");

                // Auction image
                html.Append("<div style='text-align: center; margin-top: 10px;'>");
                html.Append($"<img src='{listing.Listing.ImageURL}' alt='Auction Image' style='width: 100%; height: auto; max-width: 300px;'><br>");
                html.Append("</div>");

                // Divider
                html.Append("<hr style='margin: 20px 0;'>");

                // Quality listing details
                html.Append("<div style='margin: 5px;'>");
                html.Append($"<strong>Quality For:</strong> <a href='{listing.QualityListing.URL}'>{listing.QualityListing.Title}</a><br>");
                html.Append("</div>");

                // Quality image
                html.Append("<div style='text-align: center; margin-top: 10px;'>");
                html.Append($"<img src='{listing.QualityListing.ImageURL}' alt='Quality Image' style='width: 100%; height: auto; max-width: 300px;'><br>");
                html.Append("</div>");

                html.Append("</div>");
            }

            html.Append("</div>");

            return html.ToString();
        }
    }
}



