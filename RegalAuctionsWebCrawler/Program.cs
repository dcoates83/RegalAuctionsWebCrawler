using Microsoft.Extensions.Options;
using RegalAuctionsWebCrawler;
using RegalAuctionsWebCrawler.Helpers;
using RegalAuctionsWebCrawler.Models;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .UseWindowsService() // This line makes the application run as a Windows service
            .ConfigureServices((hostContext, services) =>
            {
                IConfiguration configuration = hostContext.Configuration;

                services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

                services.AddSingleton<Emailer>(provider =>
                {
                    EmailSettings emailSettings = provider.GetRequiredService<IOptions<EmailSettings>>().Value;
                    return new Emailer(emailSettings.SenderEmail, emailSettings.Password, emailSettings.RecipientEmail, emailSettings.CcEmails);
                });

                services.AddHostedService<Worker>();
                services.AddSingleton<ListingExtractor>();
                services.AddSingleton<QualityListingExtractor>();
            });
    }
}
