using PuppeteerSharp;
using RegalAuctionsWebCrawler.Helpers;
using RegalAuctionsWebCrawler.Models;

namespace RegalAuctionsWebCrawler
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly TimeSpan _interval;
        private readonly Emailer _emailer;
        private PageScraper _scraper;
        private readonly ListingExtractor _extractor;
        private readonly string url = "https://www.regalauctions.com/inventory";

        public Worker(ILogger<Worker> logger, ListingExtractor extractor, Emailer emailer)
        {
            _logger = logger;
            _extractor = extractor;
            _emailer = emailer;
            _interval = new TimeSpan(24, 0, 0);

        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                //Initialize the scraper with the target URL
                //YearRangeModel yearRange = YearRangeModelFactory.GetYearRangeModel(1980, 2024);
                OdometerRangeModel odometerRange = OdometerRangeModelFactory.GetOdometerRangeModel(0, 190_000);
                ReserveRangeModel reserveRange = ReserveModelFactory.GetReserveRangeModel(0, 6500, null);
                List<BaseModel> unitTypes = UnitTypeModelFactory.GetUnitTypeModels();
                List<BaseModel> carsAndSUVs = unitTypes.Where(x => x.Label is "Car" or "Sport Utility").ToList();



                //List<UnitTypeModel> unitTypes = [new UnitTypeModel { Value = "U", Label = "Sport Utility" }];
                //List<BaseModel> makes = [new BaseModel { Value = "Toyota", Label = "Toyota" }];
                //List<BaseModel> transmissions = [new BaseModel { Value = "Automatic", Label = "Automatic" }];
                //List<BaseModel> engines = [new BaseModel { Value = "4 Cylinder", Label = "4 Cylinder" }];
                //List<BaseModel> drivelines = [new BaseModel { Value = "4WD", Label = "4WD" }];
                //List<BaseModel> fuelTypes = [new BaseModel { Value = "Gas", Label = "Gas" }];
                //List<BaseModel> seats = [new BaseModel { Value = "4", Label = "4" }];

                string url = UrlHelper.GenerateInventoryUrl(
                    unitsPerPage: 100,
                    page: 1,
                    //yearRange: yearRange,
                    odometerRange: odometerRange,
                    reserveRange: reserveRange,
                    unitTypes: carsAndSUVs
                    //makes: makes,
                    //transmissions: transmissions
                    //engines: engines,
                    //drivelines: drivelines
                    //fuelTypes: fuelTypes,
                    //seats: seats,

                    );

                _scraper = new PageScraper(url);

                try
                {
                    // Initialize the browser page
                    IPage page = await _scraper.InitializeAsync();

                    // Extract listing details
                    List<ListingModel> listingDetails = await _extractor.GetAllListingDetailsAsync(page);
                    string[] otherFilter = { "REPAIR", "TRANSMISSION", "ROUGH", "NOISE", "RUSTED", "ENGINE", "TOW" };

                    //string[] titleFilter = { "HATCHBACK" };

                    List<ListingModel> filteredList = _extractor.FilterListingsByOther(otherFilter, listingDetails);

                    // Generate HTML table
                    HtmlTableBuilder builder = new();
                    string htmlTable = builder.BuildTable(filteredList);





                    // Send email with the HTML table
                    _emailer.SendEmail("Regal Auctions Listings", htmlTable);



                    // Close the browser after use
                    await page.Browser.CloseAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while executing the worker.");
                }

                // Delay before the next iteration
                await Task.Delay(_interval, stoppingToken);
            }
        }


    }
}
