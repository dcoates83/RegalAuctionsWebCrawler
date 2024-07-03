using PuppeteerSharp;
using RegalAuctionsWebCrawler.Models;

namespace RegalAuctionsWebCrawler.Helpers
{
    public class ListingExtractor
    {
        public async Task<List<ListingModel>> GetListingDetailsAsync(IPage page)
        {
            List<ListingModel> details = [];

            IElementHandle[] listings = await page.QuerySelectorAllAsync(".detail-box");
            foreach (IElementHandle? item in listings)
            {
                string title = await GetInnerText(".detail-box-description", item);


                Console.WriteLine($"title: {title}");
                ListingModel listing = new()
                {
                    Title = title,
                    Reserve = 0,
                    Odometer = 0,
                    SaleDate = DateTime.Now,
                    LotNumber = "",
                    Seller = "",
                    Options = "",
                    URL = "",
                    ImageURL = ""
                };

                Console.WriteLine(listing.ToString());
                details.Add(listing);
            }

            return details;
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
    }
}
