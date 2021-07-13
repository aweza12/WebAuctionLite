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
            ApplicationUser model = user;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser model)
        {
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

                    await userManager.UpdateAsync(user);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public async Task<IActionResult> ChangePassword()
        {
            IdentityUser user = userManager.FindByIdAsync(userManager.GetUserId(User)).Result;
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = userManager.FindByIdAsync(userManager.GetUserId(User)).Result;
                if (user != null)
                {
                    var _passwordValidator =
                        HttpContext.RequestServices.GetService(typeof(IPasswordValidator<IdentityUser>)) as IPasswordValidator<IdentityUser>;
                    var _passwordHasher =
                        HttpContext.RequestServices.GetService(typeof(IPasswordHasher<IdentityUser>)) as IPasswordHasher<IdentityUser>;

                    IdentityResult result =
                        await _passwordValidator.ValidateAsync(userManager, user, model.NewPassword);
                    if (result.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
                        await userManager.UpdateAsync(user);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddMoney()
        {
            ApplicationUser user = (ApplicationUser)userManager.FindByIdAsync(userManager.GetUserId(User)).Result;
            user.MoneyAccount += Convert.ToDecimal(100);
            await userManager.UpdateAsync(user);

            return new RedirectResult("/User");
        }

        public async Task<IActionResult> WithdrawMoney()
        {
            ApplicationUser user = (ApplicationUser)userManager.FindByIdAsync(userManager.GetUserId(User)).Result;
            user.MoneyAccount -= Convert.ToDecimal(100);
            await userManager.UpdateAsync(user);

            return new RedirectResult("/User");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.Products.DeleteProduct(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }

}

