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
        private readonly PageScraper _scraper;
        private readonly ListingExtractor _extractor;
        private readonly string url = "https://www.regalauctions.com/inventory";

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            PageScraper scraper = new(url);
            ListingExtractor extractor = new();
            _emailer = new Emailer(
                    "test@gmail.com", "password", "receiverEmail@gmail.com"
            );
            _interval = new TimeSpan(24, 0, 0);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                //YearRangeModel yearRange = YearRangeModelFactory.GetYearRangeModel(1980, 2024);
                OdometerRangeModel odometerRange = OdometerRangeModelFactory.GetOdometerRangeModel(0, 19000);
                List<BaseModel> unitTypes = UnitTypeModelFactory.GetUnitTypeModels();

                List<BaseModel> carsAndSUVs = unitTypes.Where(x => x.Label is "Car" or "Sport Utility").ToList();



                //List<UnitTypeModel> unitTypes = [new UnitTypeModel { Value = "U", Label = "Sport Utility" }];
                //List<BaseModel> makes = [new BaseModel { Value = "Toyota", Label = "Toyota" }];
                List<BaseModel> transmissions = [new BaseModel { Value = "Automatic", Label = "Automatic" }];
                List<BaseModel> engines = [new BaseModel { Value = "4 Cylinder", Label = "4 Cylinder" }];
                List<BaseModel> drivelines = [new BaseModel { Value = "4WD", Label = "4WD" }];
                //List<BaseModel> fuelTypes = [new BaseModel { Value = "Gas", Label = "Gas" }];
                //List<BaseModel> seats = [new BaseModel { Value = "4", Label = "4" }];

                string url = UrlHelper.GenerateInventoryUrl(
                    unitsPerPage: 25,
                    page: 1,
                    //yearRange: yearRange,
                    //odometerRange: odometerRange,
                    unitTypes: carsAndSUVs,
                    //makes: makes,
                    transmissions: transmissions,
                    //engines: engines,
                    drivelines: drivelines
                    //fuelTypes: fuelTypes,
                    //seats: seats
                    );
                Console.WriteLine(url);



                IPage page = await _scraper.InitializeAsync();
                List<ListingModel> listingDetails = await _extractor.GetAllListingDetailsAsync(page);


                await page.Browser.CloseAsync(); // Ensure the browser is closed after use

                await Task.Delay(_interval);

            }
        }
    }
}
