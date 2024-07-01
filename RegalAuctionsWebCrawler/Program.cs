using RegalAuctionsWebCrawler.Models;

namespace RegalAuctionsWebCrawler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddHostedService<Worker>();

            var host = builder.Build();
//
            var yearRange = YearRangeModelFactory.GetYearRangeModel(2004, 2016);
            var odometerRange = OdometerRangeModelFactory.GetOdometerRangeModel(40000, 140000);

            var unitTypes = new List<BaseModel> { new BaseModel { Value = "U", Label = "Sport Utility" } };
            var makes = new List<BaseModel> { new BaseModel { Value = "Toyota", Label = "Toyota" } };
            var transmissions = new List<BaseModel> { new BaseModel { Value = "Automatic", Label = "Automatic" } };
            var engines = new List<BaseModel> { new BaseModel { Value = "4 Cylinder", Label = "4 Cylinder" } };
            var drivelines = new List<BaseModel> { new BaseModel { Value = "4WD", Label = "4WD" } };
            var fuelTypes = new List<BaseModel> { new BaseModel { Value = "Gas", Label = "Gas" } };
            var seats = new List<BaseModel> { new BaseModel { Value = "4", Label = "4" } };

            string url = UrlHelper.GenerateInventoryUrl(
                unitsPerPage: 25,
                page: 1,
                yearRange: yearRange,
                odometerRange: odometerRange,
                unitTypes: unitTypes,
                makes: makes,
                transmissions: transmissions,
                engines: engines,
                drivelines: drivelines,
                fuelTypes: fuelTypes,
                seats: seats);

            Console.WriteLine("Initial URL:");
            Console.WriteLine(url);

            string newUrl = UrlHelper.ChangePageNumber(url, 2);
            Console.WriteLine("URL with changed page number:");
            Console.WriteLine(newUrl);
            host.Run();
        
        }
    }
}