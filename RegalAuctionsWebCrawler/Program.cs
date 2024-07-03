namespace RegalAuctionsWebCrawler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddHostedService<Worker>();
            //builder.Services.AddSingleton<PageScraper>();
            //builder.Services.AddSingleton<ListingExtractor>();
            //builder.Services.AddSingleton<Emailer>();


            IHost host = builder.Build();

            host.Run();

        }
    }
}