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
        private readonly IMainPageService mainpageService;
        private readonly IAboutService aboutService;
        private readonly IContactPageService contactpageService;
        public HomeController(IProductService productService, ICategoryService categoryService, IMainPageService mainpageService,IAboutService aboutService,IContactPageService contactpageService) : base(categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.mainpageService = mainpageService;
            this.aboutService = aboutService;
            this.contactpageService = contactpageService;
        }
        public ActionResult Index()
        {            
            var mainpage = mainpageService.GetAll();          
            return View(mainpage);
        }        

        public ActionResult About()
        {
            var about = aboutService.GetAll();
            return View(about);
        }

        public ActionResult Contact()
        {
            var contact = contactpageService.GetAll();
            return View(contact);
        }
    }
}