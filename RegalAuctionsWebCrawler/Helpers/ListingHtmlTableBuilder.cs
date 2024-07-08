using RegalAuctionsWebCrawler.Models;
using System.Text;

namespace RegalAuctionsWebCrawler.Helpers
{
    public class HtmlTableBuilder
    {
        public string BuildTable(List<ListingModel> listings)
        {
            StringBuilder html = new();

            html.Append("<div>");

            foreach (ListingModel listing in listings)
            {
                html.Append("<div style='margin-bottom: 10px; border: 1px solid #ddd; padding: 10px;'>");

                // Image on top
                html.Append("<div style='text-align: center; margin-bottom: 10px;'>");
                html.Append($"<img src='{listing.ImageURL}' alt='Image' style='width: 100%; height: auto; max-width: 300px;'><br>");
                html.Append("</div>");

                // Details below the image
                html.Append("<div style='margin: 5px;'>");
                html.Append($"<strong>Title:</strong> {listing.Title}<br>");
                html.Append($"<strong>Reserve:</strong> {listing.Reserve}<br>");
                html.Append($"<strong>Odometer:</strong> {listing.Odometer}<br>");
                html.Append($"<strong>Options:</strong> {listing.Options}<br>");
                html.Append($"<strong>Other:</strong> {listing.Other ?? ""}<br>");
                html.Append($"<strong>URL:</strong> <a href='{listing.URL}'>Link</a><br>");
                html.Append("</div>");

                html.Append("</div>");
            }

            html.Append("</div>");

            return html.ToString();
        }


    }
}



