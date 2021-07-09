using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAuctionLite.Domain;

namespace WebAuctionLite.Service
{
    public interface IScheduleConfig<T>
    {
        //private readonly DataManager dataManager;
        DataManager dataManager { get; set; }
        string CronExpression { get; set; }
        TimeZoneInfo TimeZoneInfo { get; set; }
    }
}
