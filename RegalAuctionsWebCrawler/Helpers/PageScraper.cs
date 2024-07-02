
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

        public async Task InitializeAsync()
        {
            LaunchOptions options = new()
            {
                Headless = true,
                ExecutablePath = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"
            };

            try
            {
                IBrowser browser = await Puppeteer.LaunchAsync(options, null);


                using PuppeteerSharp.IPage page = await browser.NewPageAsync();
                await page.GoToAsync(_pageURL);
                //await page.ScreenshotAsync("Screenshot.jpg", new ScreenshotOptions { FullPage = true, Quality = 100 });


                IElementHandle[] listings = await page.QuerySelectorAllAsync(".detail-box");
                foreach (IElementHandle? item in listings)
                {

                    IJSHandle innerTextHandle = await item.GetPropertyAsync("innerText");
                    object innerText = await innerTextHandle.JsonValueAsync();
                    Console.WriteLine(innerText);
                }



                await browser.CloseAsync();

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"There was an error getting data from the web: {ex.Message}");
                throw;
            }

            //await page.WaitForSelectorAsync("div.main-content");



        }
        private static async Task ClickLinkWithSelectorAndWaitForSelector(Page page, string linkSelector, string waitForSelector)
        {
            await page.ClickAsync(linkSelector);
            await page.WaitForSelectorAsync($"{waitForSelector}");
        }
    }
}

