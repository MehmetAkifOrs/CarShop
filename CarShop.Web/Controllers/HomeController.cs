using CarShop.Model;
using CarShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Web.Controllers
{
    public class HomeController : ControllerBase
    {
      
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        public HomeController(IProductService productService, ICategoryService categoryService) : base(categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public ActionResult Index()
        {
            var categories = categoryService.GetAll();
            return View(categories);
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