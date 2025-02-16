﻿using PuppeteerSharp;
using RegalAuctionsWebCrawler.Models;
using System.Text.RegularExpressions;

namespace RegalAuctionsWebCrawler.Helpers
{
    public class ListingExtractor
    {
        public async Task<List<ListingModel>> GetAllListingDetailsAsync(IPage page)
        {
            List<ListingModel> details = [];

            IElementHandle[] listings = await page.QuerySelectorAllAsync(".detail-box");
            foreach (IElementHandle? item in listings)
            {
                string title = await GetInnerText(".detail-box-description", item);
                string reserve = await GetInnerText(".reserve", item);
                string odometer = await GetInnerText(".odometer", item);
                string options = await GetInnerText(".detail-box-info4", item);
                string thumbnailURL = await GetThumbnailUrl(item);
                string URL = await GetURL(item);
                string initialSaleDate = await GetValueFromLabel(item, "Sale Date:");
                string lotNumber = await GetValueFromLabel(item, "Lot#:");
                string seller = await GetValueFromLabel(item, "Seller:");
                string other = await GetValueFromLabel(item, "Other:");

                DateTime saleDate = ParseSaleDate(initialSaleDate);

                // Clean up options and other fields
                options = CleanUpField(options, "Options:");
                other = CleanUpField(other, "Other:");

                ListingModel listing = new()
                {
                    Title = title,
                    Reserve = reserve,
                    Odometer = odometer,
                    SaleDate = saleDate,
                    LotNumber = lotNumber,
                    Seller = seller,
                    Options = options,
                    URL = URL,
                    ImageURL = thumbnailURL,
                    Other = other
                };

                details.Add(listing);
            }

            return details;
        }

        public List<ListingModel> FilterListingsByOther(string[] filterStrings, List<ListingModel> listings)
        {
            List<ListingModel> filteredListings = [];

            foreach (ListingModel listing in listings)
            {
                bool addListing = true;

                if (listing.Other != null)
                {
                    foreach (string filter in filterStrings)
                    {
                        // make both filter and listing other lowercase to make the comparison case-insensitive
                        if (listing.Other.ToLower().Contains(filter.ToLower()))
                        {
                            addListing = false;
                            break;
                        }
                    }
                }

                if (addListing)
                {
                    filteredListings.Add(listing);
                }
            }

            return filteredListings;
        }

        public List<ListingModel> FilterListingsByTitle(string[] filterStrings, List<ListingModel> listings)
        {
            List<ListingModel> filteredListings = [];

            foreach (ListingModel listing in listings)
            {
                bool addListing = true;

                if (listing.Title != null)
                {
                    foreach (string filter in filterStrings)
                    {
                        // make both filter and listing other lowercase to make the comparison case-insensitive
                        if (listing.Title.ToLower().Contains(filter.ToLower()))
                        {
                            addListing = false;
                            break;
                        }
                    }
                }

                if (addListing)
                {
                    filteredListings.Add(listing);
                }
            }

            return filteredListings;
        }

        private async Task<string> GetInnerText(string selector, IElementHandle? item)
        {
            if (item == null)
            {
                return "";
            }
            IElementHandle result = await item.QuerySelectorAsync(selector);
            if (result == null)
            {
                return "";
            }
            IJSHandle innerTextHandle = await result.GetPropertyAsync("innerText");
            string innerText = (string)await innerTextHandle.JsonValueAsync();
            return innerText;
        }

        private async Task<string> GetURL(IElementHandle item)
        {
            IElementHandle link = await item.QuerySelectorAsync("a");
            if (link == null)
            {
                return "";
            }
            IJSHandle urlHandle = await link.GetPropertyAsync("href");
            string url = (string)await urlHandle.JsonValueAsync();
            return url;
        }

        private async Task<string> GetThumbnailUrl(IElementHandle item)
        {
            IElementHandle thumbnail = await item.QuerySelectorAsync(".thumbnail");
            if (thumbnail == null)
            {
                return "";
            }
            IJSHandle thumbnailUrlHandle = await thumbnail.GetPropertyAsync("src");
            string thumbnailUrl = (string)await thumbnailUrlHandle.JsonValueAsync();
            return thumbnailUrl;
        }

        private async Task<string> GetValueFromLabel(IElementHandle parent, string labelText)
        {
            return await parent.EvaluateFunctionAsync<string>(@"(element, label) => {
        const labels = element.querySelectorAll('span.label');
        for (let labelElement of labels) {
            if (labelElement.innerText.trim() === label) {
                const valueElement = labelElement.nextElementSibling;
                return valueElement ? valueElement.innerText : '';
            }
        }
        return '';
    }", labelText);
        }

        private DateTime ParseSaleDate(string saleDate)
        {
            // Remove ordinal suffixes and parse the date
            string cleanedDate = Regex.Replace(saleDate, @"(\d+)(st|nd|rd|th)", "$1");
            if (DateTime.TryParseExact(cleanedDate, "MMM d", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
            {
                // Assuming the year is the current year as the date string does not include it
                parsedDate = parsedDate.AddYears(DateTime.Now.Year - parsedDate.Year);
            }
            return parsedDate;
        }

        private string CleanUpField(string field, string label)
        {
            if (string.IsNullOrEmpty(field))
            {
                return field;
            }

            // Remove the label if it exists
            return field.Replace(label, "").Trim();
        }
    }
}
