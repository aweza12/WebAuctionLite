using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAuctionLite.Domain;

namespace WebAuctionLite.Controllers
{
    public class LotController : Controller
    {
        private readonly DataManager dataManager;

        public LotController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.Lots.GetLots().Where(x => x.LotStatus == Entities.Enums.LotStatus.Active).OrderBy(x => x.StartDate));
        }
    }
}
