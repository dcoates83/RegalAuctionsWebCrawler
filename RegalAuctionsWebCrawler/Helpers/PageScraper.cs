using HtmlAgilityPack;

namespace RegalAuctionsWebCrawler.Helpers
{
    public class PageScraper
    {
        private readonly string _pageURL;
        public PageScraper(string pageURL)
        {
            _pageURL = pageURL;
        }

        public async Task InitializeAsync()
        {
            HtmlWeb web = new();
            HtmlDocument doc = web.Load(_pageURL);

            try
            {
                HtmlNode header = doc.GetElementbyId("header");
                Console.WriteLine(header.ToString());
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"There was an error getting data from the web: {ex.Message}");
                throw;
            }

            //await page.WaitForSelectorAsync("div.main-content");



        }
    }
}

