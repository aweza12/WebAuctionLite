using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAuctionLite.Domain;
using WebAuctionLite.Domain.Entities;

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

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.Now:hh:mm:ss} Lots is working.");

            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                foreach (var l in dbContext.Lots.Where(x => x.EndDate <= DateTime.UtcNow && x.LotStatus == Entities.Enums.LotStatus.Active).Include(x => x.Bids).ThenInclude(x => x.ApplicationUser).ThenInclude(x => x.Products).Include(x => x.Product).Include(x => x.ApplicationUser))
                {
                    l.LotStatus = Entities.Enums.LotStatus.Completed;
                    if(l.Bids != null && l.Bids.Count != 0)
                    {
                        Bid maxBid = l.Bids.First(x => x.BidSum == l.Bids.Max(x => x.BidSum));
                        maxBid.BidStatus = Entities.Enums.BidStatus.Win;
                        maxBid.ApplicationUser.Products.Add(maxBid.Lot.Product);
                        maxBid.Lot.Product.ApplicationUserId = Guid.Parse(maxBid.BuyerId);
                        l.ApplicationUser.MoneyAccount += maxBid.BidSum;
                        foreach (var b in l.Bids)
                        {
                            if(b.BidStatus != Entities.Enums.BidStatus.Win)
                            {
                                b.BidStatus = Entities.Enums.BidStatus.Loss;
                                b.ApplicationUser.MoneyAccount += b.BidSum;
                            }
                        }
                    }
                }

                dbContext.SaveChanges();
            }

            return Task.CompletedTask;
        }
    }
}
