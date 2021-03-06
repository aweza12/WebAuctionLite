using System;
using System.IO;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAuctionLite.Domain;
using WebAuctionLite.Domain.Entities;
using WebAuctionLite.Service;
using System.Linq;
using System.Threading.Tasks;

namespace WebAuctionLite.Areas.User.Controllers
{
    [Area("User")]
    public class ProductsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private UserManager<IdentityUser> userManager;

        public ProductsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, UserManager<IdentityUser> userManager)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var id = userManager.GetUserId(User);
            return View(dataManager.Products.GetProducts().Where(x => x.ApplicationUserId.ToString() == id));
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new Product() : dataManager.Products.GetProductById(id);

            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Product model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    model.TitleImagePath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                model.DateAdded = DateTime.UtcNow;
                model.ApplicationUserId = new Guid(userManager.GetUserId(User));
                model.ApplicationUser = (ApplicationUser)userManager.FindByIdAsync(userManager.GetUserId(User)).Result;

                dataManager.Products.SaveProduct(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.Products.DeleteProduct(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}