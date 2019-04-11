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
        private readonly IOrderService orderService;
        public CartController(ICartService cartService, IProductService productService, ICategoryService categoryService, IOrderService orderService) : base(categoryService, cartService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.cartService = cartService;
            this.orderService = orderService;
        }
        // GET: Cart          

        public ActionResult Index()
        {
            var cartProducts = cartService.GetAll();
            
            return View(cartProducts);
        }      
        
        public ActionResult Cart()
        {
            var carts = cartService.GetAll();
            return View(carts);
        }

        public ActionResult Delete(Guid id)
        {
            cartService.Delete(id);
            return RedirectToAction("Index","Cart");
        }
    }
}