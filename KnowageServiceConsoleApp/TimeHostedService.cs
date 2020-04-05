using KnowageService.Models;
using KnowageService.Models.Result;
using KnowageServiceConsoleApp.Controllers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KnowageService
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<TimedHostedService> _logger;
        private Timer _timer;

        public TimedHostedService(ILogger<TimedHostedService> logger, IOptions<AppSettings> appSettings,
                        IOptions<KnowageHeaders> headers, IOptions<URLs> urls,
                        IOptions<Paths> paths, IOptions<SMTPConfig> smtp)
        {
            _logger = logger;
            AppSettings _appSettings1 = appSettings.Value;
            KnowageHeaders _headers = headers.Value;
            URLs _urls = urls.Value;
            Paths _paths = paths.Value;
            SMTPConfig _smtp = smtp.Value;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");


            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(600)); // runs every 10 minutes or 600 seconds


            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            KnowageController controller = new KnowageController();
            SearchRecordResult result = new SearchRecordResult();
            result = controller.GetScheduledTasks();

            // get list of scheduled task from result.DataTable, if any.
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }



    }
}
