using PuppeteerSharp;
using RegalAuctionsWebCrawler.Models;

namespace RegalAuctionsWebCrawler.Helpers
{

    public class QualityListingExtractor
    {
        [Obsolete]
        public async Task<List<QualityListingModel>> GetAllListingDetailsAsync(IPage page, string make, string model)
        {
            List<QualityListingModel> details = [];

            string modelIdentifier = $"{make} {model}:";

            // Find the h3 element containing the make and model
            IElementHandle[] h3Tags = await page.QuerySelectorAllAsync("h3");
            foreach (IElementHandle h3Tag in h3Tags)
            {
                string title = await GetInnerText(h3Tag);
                if (title.Contains(modelIdentifier, System.StringComparison.OrdinalIgnoreCase))
                {
                    string imageUrl = await GetNextImageUrl(h3Tag);
                    if (!string.IsNullOrEmpty(imageUrl))
                    {
                        QualityListingModel listing = new()
                        {
                            Title = title,
                            URL = page.Url,
                            ImageURL = imageUrl
                        };
                        details.Add(listing);
                    }
                }
            }

            return details;
        }

        private async Task<string> GetInnerText(IElementHandle element)
        {
            if (element == null)
            {
                return "";
            }
            IJSHandle innerTextHandle = await element.GetPropertyAsync("innerText");
            string innerText = (string)await innerTextHandle.JsonValueAsync();
            return innerText;
        }

        [Obsolete]
        private async Task<string> GetNextImageUrl(IElementHandle element)
        {
            // Get the sibling image element
            IElementHandle[] imageElements = await element.XPathAsync("following-sibling::img");
            IElementHandle image = imageElements.FirstOrDefault();
            if (image == null)
            {
                return "";
            }
            IJSHandle imageUrlHandle = await image.GetPropertyAsync("src");
            string imageUrl = (string)await imageUrlHandle.JsonValueAsync();
            return imageUrl;
        }
    }

}
