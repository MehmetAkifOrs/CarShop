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
        public ControllerBase(ICategoryService categoryService)
        {       
            this.categoryService = categoryService;
        }
        // bu metot tüm actionlardan önce çalışır
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           
            base.OnActionExecuting(filterContext);
        }
        // bu metot tüm actionlardan sonra çalışır
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (categoryService != null)
            {
                ViewBag.Categories = categoryService.GetAll();
            }
            ViewBag.AssetsUrl = ConfigurationManager.AppSettings["assetsUrl"];
            base.OnActionExecuted(filterContext);
        }
    }
}