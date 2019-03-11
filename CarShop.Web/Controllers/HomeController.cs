using CarShop.Model;
using CarShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Web.Controllers
{
    public class HomeController : Controller
    {
      
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        public HomeController(IProductService productService, ICategoryService categoryService) : base()
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public ActionResult Index()
        {                   
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