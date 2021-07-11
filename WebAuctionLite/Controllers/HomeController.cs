﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebAuctionLite.Domain;

namespace WebAuctionLite.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.Lots.GetLots().Where(x => x.LotStatus == Entities.Enums.LotStatus.Active).OrderBy(x => x.StartDate));
        }

        public IActionResult Contacts()
        {
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageContacts"));
        }
    }
}
