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
        private readonly IAboutService aboutService;
        public HomeController(IProductService productService, ICategoryService categoryService, IAboutService aboutService) : base(categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.aboutService = aboutService;
        }
        public ActionResult Index()
        {
            //ViewBag.PageContent = aboutService.GetAll();
           // ViewBag.SliderQuantity = aboutService.GetAll().Where(p => p.AboutPagePhoto != null).Count();
           // var abouts = aboutService.GetAll();
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