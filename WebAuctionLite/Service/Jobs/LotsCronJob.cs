using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAuctionLite.Domain;

namespace WebAuctionLite.Service.Jobs
{
    public class LotsCronJob : CronJobService
    {
        private readonly ILogger<LotsCronJob> _logger;
        private readonly IServiceScopeFactory scopeFactory;

        public LotsCronJob(IScheduleConfig<LotsCronJob> config, ILogger<LotsCronJob> logger, IServiceScopeFactory scopeFactory)
            : base(config.CronExpression, config.TimeZoneInfo, scopeFactory)
        {
            _logger = logger;
            this.scopeFactory = scopeFactory;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Lots starts.");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.Now:hh:mm:ss} Lots is working.");

            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                foreach (var l in dbContext.Lots.Where(x => x.EndDate <= DateTime.UtcNow && x.LotStatus == Entities.Enums.LotStatus.Active))
                {
                    l.LotStatus = Entities.Enums.LotStatus.Completed;
                }

                dbContext.SaveChanges();
            }

            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Lots is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}
