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
            //var cart = new Cart();
            //var product = productService.Find(product);
            //cart.Piece = piece;
            //cart.ProductName = product.Name;
            //cart.Price = product.Price;
            //cart.CartProductPhoto = product.Photos.FirstOrDefault().Name;
            //cartService.Insert(cart);
            //var carts = cartService.GetAll();
            //var carts = cartService.GetAll();
            return View(cartProducts);
        }

        //[HttpPost]
        //public ActionResult Index(Product product, int piece)
        //{
        //    var cart = new Cart();

        //    //var product = productService.Find(product);
        //    cart.Piece = piece;
        //    cart.ProductName = product.Name;
        //    cart.Price = product.Price;
        //    cart.CartProductPhoto = product.Photos.FirstOrDefault().Name;
        //    cartService.Insert(cart);
        //    var carts = cartService.GetAll();
        //    //var carts = cartService.GetAll();
        //    return View(carts);

        //var order = new Order();
        ////var product = productService.Find(cart.Id);
        //order.Orders = product.Name;
        //order.piece = piece;
        //order.TotalPrice = product.Price * piece;
        //orderService.Insert(order);
        //return RedirectToAction("Index", "Checkout", order);
    //}



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