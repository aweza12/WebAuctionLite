using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAuctionLite.Domain;
using WebAuctionLite.Domain.Entities;

namespace WebAuctionLite.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        private UserManager<IdentityUser> userManager;

        public HomeController(DataManager dataManager, UserManager<IdentityUser> userManager)
        {
            this.dataManager = dataManager;
            this.userManager = userManager;
    }

        public IActionResult Index()
        {
            return View((ApplicationUser) userManager.FindByIdAsync(userManager.GetUserId(User)).Result);
        }

        public void AddMoney()
        {
            ((ApplicationUser)userManager.FindByIdAsync(userManager.GetUserId(User)).Result).MoneyAccount += 100;
            dataManager.ApplicationUsers.SaveApplicationUser((ApplicationUser)userManager.FindByIdAsync(userManager.GetUserId(User)).Result);
        }
    }
}