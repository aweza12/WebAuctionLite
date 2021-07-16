using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAuctionLite.Areas.User.Models;
using WebAuctionLite.Domain;
using WebAuctionLite.Domain.Entities;
using WebAuctionLite.Service;

namespace WebAuctionLite.Areas.User.Controllers
{
    [Area("User")]
    public class BidsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private UserManager<IdentityUser> userManager;

        public BidsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, UserManager<IdentityUser> userManager)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var id = userManager.GetUserId(User);
            var user = (ApplicationUser)userManager.FindByIdAsync(id).Result;
            return View(dataManager.ApplicationUsers.GetApplicationUserById(Guid.Parse(id)).Bids);
        }

        public IActionResult Edit(Guid lotId)
        {
            var entity = new AddBidViewModel();
            entity.LotId = lotId;

            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(AddBidViewModel model)
        {
            var id = userManager.GetUserId(User);
            var lot = dataManager.Lots.GetLotById(model.LotId);
            var user = dataManager.ApplicationUsers.GetApplicationUserById(Guid.Parse(id));

            if (lot.Bids.Count == 0 && lot.MinPrice + lot.MinBetMove > model.BidSum)
            {
                ModelState.AddModelError("BidSum", "Ставка ниже минимально необходимой (Максимальная предидущая ставка + минимальных ход)");
            }
            else if (lot.Bids.Count > 0 && model.BidSum < (lot.Bids.Max(x => x.BidSum)) + lot.MinBetMove)
            {
                ModelState.AddModelError("BidSum", "Ставка ниже минимально необходимой (Максимальная предидущая ставка + минимальных ход)");
            }
            if (id == lot.ApplicationUserId.ToString())
            {
                ModelState.AddModelError("BidSum", "Вы не можете делать ставки на свой лот");
            }
            if (lot.EndDate.CompareTo(DateTime.UtcNow) < 1)
            {
                ModelState.AddModelError("BidSum", "Время для продажи этого лота закончилось");
            }
            if (model.BidSum > user.MoneyAccount + (user.Bids.LastOrDefault(x => x.LotId == lot.Id && x.BidStatus == Entities.Enums.BidStatus.Active) != null ? user.Bids.LastOrDefault(x => x.LotId == lot.Id && x.BidStatus == Entities.Enums.BidStatus.Active).BidSum : 0m))
            {
                ModelState.AddModelError("BidSum", "У вас на счету недостаточно денег");
            }
            if (lot.LotStatus != Entities.Enums.LotStatus.Active)
            {
                ModelState.AddModelError("BidSum", "Сейчас нельзя сделать ставку на этот лот");
            }

            if (ModelState.IsValid)
            {
                if (user.Bids?.Where(x => x.Lot == lot).Where(x => x.BidStatus == Entities.Enums.BidStatus.Active) != null)
                {
                    foreach (var b in user.Bids.Where(x => x.Lot == lot).Where(x => x.BidStatus == Entities.Enums.BidStatus.Active))
                    {
                        b.BidStatus = Entities.Enums.BidStatus.Canceled;
                        user.MoneyAccount += b.BidSum;
                    }
                }
                var bid = new Bid();
                bid.BetTime = DateTime.UtcNow;
                bid.BidSum = model.BidSum;
                bid.BidStatus = Entities.Enums.BidStatus.Active;
                bid.BuyerId = id;
                bid.ApplicationUser = user;
                bid.LotId = lot.Id;
                bid.Lot = lot;
                user.MoneyAccount -= model.BidSum;
                dataManager.Bids.SaveBid(bid);
                return RedirectToAction("Show", "Lots", new { id = bid.LotId });
            }

            if (!ModelState.IsValid)
            {
                foreach (string s in ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage)))
                {
                    Console.WriteLine(s);
                }
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.Lots.DeleteLot(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
