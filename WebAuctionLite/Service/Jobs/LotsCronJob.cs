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
        private readonly DataManager dataManager;

        public LotsCronJob(IScheduleConfig<LotsCronJob> config, ILogger<LotsCronJob> logger, DataManager dataManager)
            : base(config.CronExpression, config.TimeZoneInfo, config.dataManager)
        {
            _logger = logger;
            this.dataManager = dataManager;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Lots starts.");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.Now:hh:mm:ss} Lots is working.");
            foreach (var l in dataManager.Lots.GetLotsByEndDateTime(DateTime.UtcNow))
            {
                dataManager.Lots.ChangeStatus(l, WebAuctionLite.Entities.Enums.LotStatus.Completed);
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
