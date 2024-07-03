using PuppeteerSharp;
using RegalAuctionsWebCrawler.Helpers;
using RegalAuctionsWebCrawler.Models;

namespace RegalAuctionsWebCrawler
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddHostedService<Worker>();

            IHost host = builder.Build();
            //
            YearRangeModel yearRange = YearRangeModelFactory.GetYearRangeModel(2004, 2016);
            OdometerRangeModel odometerRange = OdometerRangeModelFactory.GetOdometerRangeModel(40000, 140000);

            List<BaseModel> unitTypes = [new BaseModel { Value = "U", Label = "Sport Utility" }];
            List<BaseModel> makes = [new BaseModel { Value = "Toyota", Label = "Toyota" }];
            List<BaseModel> transmissions = [new BaseModel { Value = "Automatic", Label = "Automatic" }];
            List<BaseModel> engines = [new BaseModel { Value = "4 Cylinder", Label = "4 Cylinder" }];
            List<BaseModel> drivelines = [new BaseModel { Value = "4WD", Label = "4WD" }];
            List<BaseModel> fuelTypes = [new BaseModel { Value = "Gas", Label = "Gas" }];
            List<BaseModel> seats = [new BaseModel { Value = "4", Label = "4" }];

            string url = UrlHelper.GenerateInventoryUrl(
                unitsPerPage: 25,
                page: 1
                //yearRange: yearRange,
                //odometerRange: odometerRange,
                //unitTypes: unitTypes,
                //makes: makes,
                //transmissions: transmissions,
                //engines: engines,
                //drivelines: drivelines,
                //fuelTypes: fuelTypes,
                //seats: seats
                );

            Console.WriteLine("Initial URL:");
            Console.WriteLine(url);



            PageScraper scraper = new(url);
            ListingExtractor extractor = new();

            IPage page = await scraper.InitializeAsync();
            List<ListingModel> listingDetails = await extractor.GetAllListingDetailsAsync(page);


            await page.Browser.CloseAsync(); // Ensure the browser is closed after use
            host.Run();

        }
    }
}