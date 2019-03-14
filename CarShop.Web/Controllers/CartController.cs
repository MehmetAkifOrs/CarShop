﻿using CarShop.Service;
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
        public ActionResult Index(Guid id)
        {
            ViewBag.Product = productService.Find(id);
            return View();
        }
    }
}