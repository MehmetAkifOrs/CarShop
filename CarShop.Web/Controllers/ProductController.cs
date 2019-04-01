using CarShop.Model;
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
        private readonly ICartService cartService;
        public ProductController(IProductService productService, ICategoryService categoryService, ICartService cartService) : base(categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.cartService = cartService;
        }
        // GET: Product
        public ActionResult Index(Guid id)
        {
            var categoryId = productService.Find(id).CategoryId;
            var category = categoryService.GetAll().Where(c => c.Id == categoryId);
            var product = productService.Find(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Index(Guid id, int piece)
        {

            var product = productService.Find(id);
            var cartProduct = new Cart();
            cartProduct.ProductId = product.Id;
            if (cartService.GetAll().Where(i => i.ProductId == id).FirstOrDefault() != null)
            {
                var cartId = cartService.GetAll().Where(i => i.ProductId == id).FirstOrDefault();
                cartId.Piece += piece;
                cartService.Update(cartId);
                return RedirectToAction("Index", "Cart");

            }
            cartProduct.ProductName = product.Name;
            cartProduct.Piece = piece;
            cartProduct.Price = product.Price;
            cartProduct.CartProductPhoto = product.Photos.FirstOrDefault().Name;
            cartService.Insert(cartProduct);
            return RedirectToAction("Index", "Cart");
        }
    }
}