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
        private readonly ICartService cartService;
        public CartController(ICartService cartService, IProductService productService, ICategoryService categoryService) : base(categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.cartService = cartService;
        }
        // GET: Cart          
       
        public ActionResult Index(Guid id)
        {
            var cart = new Cart();
            var product = productService.Find(id);
            //, int adet
            //adet = 2;
            cart.ProductName = product.Name;
            cart.Price = product.Price;
            //cart.Piece = adet;
            cartService.Insert(cart);
            ViewBag.Carts = cartService.GetAll();
            
           // var carts = cartService.GetAll();

            return View();
        }
    }
}