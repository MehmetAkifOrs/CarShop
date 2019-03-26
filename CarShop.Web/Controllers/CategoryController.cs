using CarShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Web.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        public CategoryController(IProductService productService, ICategoryService categoryService): base(categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        // GET: Category       
        public ActionResult Index(Guid id)
        {           
            var category = categoryService.Find(id);
            ViewBag.CategoryPagePhoto = category.PagePhoto;
            var products = productService.GetAll().Where(i => i.CategoryId == category.Id);
            return View(products);
        }
    }
}