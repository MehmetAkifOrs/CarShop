using CarShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Web.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService) : base(categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        // GET: Product
        public ActionResult Index(Guid id)
        {
            
            var categoryId = productService.Find(id).CategoryId;
            var category = categoryService.GetAll().Where(c => c.Id == categoryId);            
            var product = productService.Find(id);            
            return View(product);
        }
    }
}