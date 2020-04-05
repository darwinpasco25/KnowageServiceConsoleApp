using KnowageService.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
namespace KnowageService
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; }
        public static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddEnvironmentVariables();

                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddOptions();
                    services.Configure<AppSettings>(hostContext.Configuration.GetSection("AppSettings"));
                    services.Configure<Paths>(hostContext.Configuration.GetSection("Paths"));
                    services.Configure<URLs>(hostContext.Configuration.GetSection("URLs"));
                    services.Configure<KnowageHeaders>(hostContext.Configuration.GetSection("KnowageHeaders"));
                    services.Configure<SMTPConfig>(hostContext.Configuration.GetSection("SMTPConfig"));
                    services.AddHostedService<TimedHostedService>();

                })
                .ConfigureLogging((hostingContext, logging) => {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();

                });

            await builder.RunConsoleAsync();

        }
    }
}
