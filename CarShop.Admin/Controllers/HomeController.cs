using CarShop.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
       

        private readonly ApplicationUserManager userManager;

        public HomeController(ApplicationUserManager userManager, ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
            this.userManager = userManager;


        }
        public ActionResult Index()
        {
            var user = userManager.FindByName(User.Identity.Name);
            ViewBag.CurrentUser = user?.FullName;
            var category = categoryService.GetAll();
            ViewBag.Categories = category;
            var product = productService.GetAll();
            ViewBag.Products = product;
            ViewBag.ProductCount = productService.GetAll().Count();
            ViewBag.CategoryCount = categoryService.GetAll().Count();
            ViewBag.UserCount = userManager.Users.Count();


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}