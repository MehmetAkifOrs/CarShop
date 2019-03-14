using CarShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Web.Controllers
{
    public class CheckoutController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        public CheckoutController(IProductService productService, ICategoryService categoryService) : base(categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }
    }
}