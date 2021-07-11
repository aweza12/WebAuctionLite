﻿//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebAuctionLite.Domain;

//namespace WebAuctionLite.Areas.User.Controllers
//{
//    [Area("User")]
//    public class BidsController : Controller
//    {
//        private readonly DataManager dataManager;
//        private readonly IWebHostEnvironment hostingEnvironment;
//        private UserManager<IdentityUser> userManager;

//        public BidsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, UserManager<IdentityUser> userManager)
//        {
//            this.dataManager = dataManager;
//            this.hostingEnvironment = hostingEnvironment;
//            this.userManager = userManager;
//        }

//        public IActionResult Index()
//        {
//            var id = userManager.GetUserId(User);
//            return View(dataManager.Lots.GetLots().Where(x => x.ApplicationUserId.ToString() == id));
//        }

//        public IActionResult Edit(Guid id)
//        {
//            var entity = id == default ? new Lot() : dataManager.Lots.GetLotById(id);

//            return View(entity);
//        }

//        [HttpPost]
//        public IActionResult Edit(Lot model, IFormFile titleImageFile)
//        {
//            var id = userManager.GetUserId(User);

//            if (model.EndDate.CompareTo(model.StartDate) < 1)
//            {
//                ModelState.AddModelError("StartDate", "Дата окончания меньше или равна дате начала аукциона");
//            }
//            if (model.MinBetMove < 5)
//            {
//                ModelState.AddModelError("MinBetMove", "Ход аукциона не может быть меньше 5");
//            }
//            if (dataManager.Products.GetProducts().Where(x => x.ApplicationUserId.ToString() == id).Where(x => x.Id == model.ProductId) == null)
//            {
//                ModelState.AddModelError("ProductId", "Такого товара не существует в вашем списке");
//            }
//            else if (dataManager.Lots.GetLotByProductId(model.ProductId) != null)
//            {
//                ModelState.AddModelError("ProductId", "Товар уже был выставлен в другом лоте");
//            }

//            if (ModelState.IsValid)
//            {
//                if (titleImageFile != null)
//                {
//                    model.TitleImagePath = titleImageFile.FileName;
//                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
//                    {
//                        titleImageFile.CopyTo(stream);
//                    }
//                }
//                model.DateAdded = DateTime.UtcNow;
//                //model.StartDate = DateTime.UtcNow;
//                model.Product = dataManager.Products.GetProductById(model.ProductId);
//                //model.LotStatus = Entities.Enums.LotStatus.Active;

//                model.ApplicationUserId = new Guid(userManager.GetUserId(User));
//                model.ApplicationUser = (ApplicationUser)userManager.FindByIdAsync(userManager.GetUserId(User)).Result;

//                dataManager.Lots.SaveLot(model);
//                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
//            }
//            if (!ModelState.IsValid)
//            {

//                foreach (string s in ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage)))
//                {
//                    Console.WriteLine(s);
//                }
//            }
//            return View(model);
//        }

//        [HttpPost]
//        public IActionResult Delete(Guid id)
//        {
//            dataManager.Lots.DeleteLot(id);
//            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
//        }
//    }
//}