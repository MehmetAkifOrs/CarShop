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
        private readonly IPageContentService pageContentService;
        public HomeController(IProductService productService, ICategoryService categoryService, IPageContentService pageContentService) : base(categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.pageContentService = pageContentService;
        }
        public ActionResult Index()
        {
            ViewBag.PageContent = pageContentService.GetAll();
            ViewBag.SliderQuantity = pageContentService.GetAll().Where(p => p.CategoryPagePhoto != null).Count();
            var categories = categoryService.GetAll();
            return View(categories);
        }        

        public ActionResult About()
        {
            var PageContent = pageContentService.GetAll().FirstOrDefault();
            ViewBag.Message = "Your application description page.";

            return View(PageContent);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}