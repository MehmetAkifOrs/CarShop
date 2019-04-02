using CarShop.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Web.Controllers
{
    public class ControllerBase : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ICartService cartService;
        public ControllerBase(ICategoryService categoryService, ICartService cartService)
        {       
            this.categoryService = categoryService;
            this.cartService = cartService;
        }
        // bu metot tüm actionlardan önce çalışır
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           
            base.OnActionExecuting(filterContext);
        }
        // bu metot tüm actionlardan sonra çalışır
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            if (cartService.GetAll().Count() > 0)
            {
                ViewBag.CartCount = cartService.GetAll().Count();
            }else
            {
                ViewBag.CartCount = 0;
            }

            if (categoryService != null)
            {
                ViewBag.Categories = categoryService.GetAll();
            }
            ViewBag.AssetsUrl = ConfigurationManager.AppSettings["assetsUrl"];
            base.OnActionExecuted(filterContext);
        }
    }
}