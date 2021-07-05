using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class ApplicationUserController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private UserManager<IdentityUser> userManager;
        
        public ApplicationUserController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, UserManager<IdentityUser> userManager)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
        }

        public IActionResult Index() => View();

        public async Task<IActionResult> Edit()
        {
            ApplicationUser user = (ApplicationUser)userManager.FindByIdAsync(userManager.GetUserId(User)).Result;
            if (user == null)
            {
                return NotFound();
            }
            //ApplicationUserViewModel model = new ApplicationUserViewModel { FirstName = user.FirstName, LastName = user.LastName, UserName = user.UserName, Email = user.Email, };
            ApplicationUser model = user;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser model)
        {
            //if (ModelState.IsValid)
            //{
            //    ApplicationUser user = (ApplicationUser)await userManager.FindByNameAsync(model.UserName);
            //    if (user != null)
            //    {
            //        user.Email = model.Email;
            //        user.UserName = model.Email;
            //        user.FirstName = model.FirstName;
            //        user.LastName = model.LastName;
            //        user.UserName = model.UserName;

            //        dataManager.ApplicationUsers.SaveApplicationUser(user);
            //        return RedirectToAction("Index");
            //    }
            //}
            if (ModelState.IsValid)
            {
                ApplicationUser user = (ApplicationUser)userManager.FindByIdAsync(userManager.GetUserId(User)).Result;
                if (model != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserName = model.UserName;

                    //dataManager.ApplicationUsers. .SaveApplicationUser(user);
                    await userManager.UpdateAsync(user);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.Products.DeleteProduct(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }

}

