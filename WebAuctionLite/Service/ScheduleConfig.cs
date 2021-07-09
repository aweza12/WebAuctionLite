using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAuctionLite.Domain;

namespace WebAuctionLite.Service
{
    public class ScheduleConfig<T> : IScheduleConfig<T>
    {
        //private readonly DataManager dataManager;
        public DataManager dataManager { get; set; }
        public string CronExpression { get; set; }
        public TimeZoneInfo TimeZoneInfo { get; set; }
    }
}
