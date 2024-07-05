using RegalAuctionsWebCrawler.Helpers;

namespace RegalAuctionsWebCrawler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<ListingExtractor>();
                    services.AddHostedService<Worker>();
                });
        }
    }
}
