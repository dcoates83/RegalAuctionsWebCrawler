using PuppeteerSharp;

namespace RegalAuctionsWebCrawler.Helpers
{
    public class PageScraper
    {
        private readonly string _pageURL;

        public PageScraper(string pageURL)
        {
            _pageURL = pageURL;
        }

        public async Task<IPage> InitializeAsync()
        {
            LaunchOptions options = new()
            {
                Headless = true,
                ExecutablePath = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"
            };

            try
            {
                IBrowser browser = await Puppeteer.LaunchAsync(options, null);
                IPage page = await browser.NewPageAsync();
                await page.GoToAsync(_pageURL);

                return page;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"There was an error initializing the page: {ex.Message}");
                throw;
            }
        }

        private static async Task ClickLinkWithSelectorAndWaitForSelector(Page page, string linkSelector, string waitForSelector)
        {
            await page.ClickAsync(linkSelector);
            await page.WaitForSelectorAsync($"{waitForSelector}");
        }
    }
}
