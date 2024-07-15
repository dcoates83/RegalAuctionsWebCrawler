using PuppeteerSharp;
using RegalAuctionsWebCrawler.Helpers;
using RegalAuctionsWebCrawler.Models;

namespace RegalAuctionsWebCrawler
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly Emailer _emailer;
        private PageScraper _auctionScraper;
        private PageScraper _qualityScraper;
        private readonly ListingExtractor _auctionExtractor;
        private readonly QualityListingExtractor _qualityListingExtractor;
        private readonly string _rootAuctionUrl = "https://www.regalauctions.com/inventory";
        private readonly string _qualityBaseUrl = "https://www.dashboard-light.com/reports/";
        private readonly List<MakeModel> _makeModels;
        private readonly List<ListingModel> _previousListings;
        private Timer _timer;

        public Worker(ILogger<Worker> logger, ListingExtractor auctionExtractor, QualityListingExtractor qualityListingExtractor, Emailer emailer)
        {
            _logger = logger;
            _auctionExtractor = auctionExtractor;
            _qualityListingExtractor = qualityListingExtractor;
            _emailer = emailer;
            _makeModels = MakeModelFactory.GetMakeModels();
            _previousListings = [];
        }

        [Obsolete]
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    ExecuteDailyTask().GetAwaiter().GetResult();

                    await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
                }
            }

            catch (Exception ex)
            {
                _emailer.SendEmail("Regal Auctions Web Crawler Error", ex.Message);


                Environment.Exit(1);
            }
            //ExecuteDailyTask().GetAwaiter().GetResult();
            ////ScheduleDailyTask(20, 0); // Schedule to run at 8 PM every day
            //return Task.CompletedTask;
        }

        [Obsolete]
        private void ScheduleDailyTask(int hour, int minute)
        {
            DateTime now = DateTime.Now;
            DateTime firstRun = new(now.Year, now.Month, now.Day, hour, minute, 0, 0);

            if (now > firstRun)
            {
                firstRun = firstRun.AddDays(1);
            }

            TimeSpan timeToGo = firstRun - now;
            _timer = new Timer(x =>
            {
                ExecuteDailyTask().GetAwaiter().GetResult();
            }, null, timeToGo, TimeSpan.FromHours(24));
        }

        [Obsolete]
        private async Task ExecuteDailyTask()
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            OdometerRangeModel odometerRange = OdometerRangeModelFactory.GetOdometerRangeModel(0, 190_000);
            ReserveRangeModel reserveRange = ReserveModelFactory.GetReserveRangeModel(0, 6500, null);
            List<BaseModel> unitTypes = UnitTypeModelFactory.GetUnitTypeModels();
            List<BaseModel> carsAndSUVs = unitTypes.Where(x => x.Label is "Car" or "Sport Utility").ToList();
            List<BaseModel> transmissions = [new BaseModel { Value = "Automatic", Label = "Automatic" }];

            string auctionUrl = UrlHelper.GenerateInventoryUrl(
                unitsPerPage: 100,
                page: 1,
                odometerRange: odometerRange,
                reserveRange: reserveRange,
                unitTypes: carsAndSUVs,
                transmissions: transmissions
            );

            _auctionScraper = new PageScraper(auctionUrl);
            _qualityScraper = new PageScraper(_qualityBaseUrl);

            try
            {
                IPage auctionPage = await _auctionScraper.InitializeAsync();
                IPage qualityPage = await _qualityScraper.InitializeAsync();

                List<ListingModel> listingDetails = await _auctionExtractor.GetAllListingDetailsAsync(auctionPage);
                string[] otherFilter = { "REPAIR", "TRANSMISSION", "ROUGH", "NOISE", "RUSTED", "ENGINE", "TOW" };
                List<ListingModel> filteredList = _auctionExtractor.FilterListingsByOther(otherFilter, listingDetails);

                List<ListingModel> newListings = FilterNewListingsBySaleDate(filteredList);

                if (newListings.Count > 0)
                {
                    List<EnhancedQualityListingModel> enrichedListings = [];
                    foreach (ListingModel listing in newListings)
                    {
                        string make = GetMakeFromListingTitle(listing.Title);
                        string model = GetModelFromListingTitle(listing.Title, make);
                        if (make != null && model != null)
                        {
                            string qualitySearchUrl = $"{_qualityBaseUrl}{make}.html";
                            await qualityPage.GoToAsync(qualitySearchUrl);

                            List<QualityListingModel> qualityListingDetails = await _qualityListingExtractor.GetAllListingDetailsAsync(qualityPage, make, model);
                            foreach (QualityListingModel qualityListing in qualityListingDetails)
                            {
                                EnhancedQualityListingModel enrichedListing = new()
                                {
                                    Listing = listing,
                                    QualityListing = qualityListing
                                };
                                enrichedListings.Add(enrichedListing);
                            }
                        }
                    }

                    HtmlTableBuilder builder = new();
                    string htmlTable = builder.BuildTable(enrichedListings);

                    _emailer.SendEmail("Regal Auctions Listings", htmlTable);

                    _previousListings.AddRange(newListings);
                }

                await auctionPage.Browser.CloseAsync();
                await qualityPage.Browser.CloseAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing the worker.");
            }
        }

        private List<ListingModel> FilterNewListingsBySaleDate(List<ListingModel> listings)
        {
            return listings.Where(listing => !_previousListings.Any(prev => prev.SaleDate == listing.SaleDate && prev.Title == listing.Title)).ToList();
        }

        private string? GetMakeFromListingTitle(string title)
        {
            foreach (MakeModel makeModel in _makeModels)
            {
                if (title.Contains(makeModel.Label, StringComparison.OrdinalIgnoreCase))
                {
                    return makeModel.Label;
                }
            }
            return null;
        }

        private string? GetModelFromListingTitle(string title, string make)
        {
            if (string.IsNullOrEmpty(make))
            {
                return null;
            }

            string[] titleParts = title.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int makeIndex = Array.FindIndex(titleParts, part => part.Equals(make, StringComparison.OrdinalIgnoreCase));

            if (makeIndex < 0 || makeIndex >= titleParts.Length - 1)
            {
                return null;
            }

            return titleParts[makeIndex + 1]; // Assuming the model immediately follows the make
        }
    }
}
