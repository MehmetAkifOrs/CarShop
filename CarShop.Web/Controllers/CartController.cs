using CarShop.Model;
using CarShop.Service;
using CarShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Web.Controllers
{
   
    public class CartController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        public CartController(IProductService productService, ICategoryService categoryService) : base(categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        // GET: Cart
       private List<Product> products = new List<Product>();
       public void AddToCart(Product p)
        {

            products.Add(p);
        }
       
        public ActionResult Index(Guid id)
        {
           
           var  product = productService.Find(id);
            AddToCart(product);
            ViewBag.Products = products;
            return View();
        }
    }
}