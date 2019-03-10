using CarShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        public CategoryController(IProductService productService, ICategoryService categoryService) : base()
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        // GET: Category       
        public ActionResult Index(Guid id)
        {
            ViewBag.Categories = categoryService.GetAll();
            var category = categoryService.Find(id);
            ViewBag.Products = productService.GetAll().Where(i => i.CategoryId == category.Id);

            return View();
        }
    }
}