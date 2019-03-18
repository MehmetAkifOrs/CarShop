using CarShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Admin.Controllers
{
    public class PageContentController : ControllerBase
    {
        // GET: Project
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private readonly IPageContentService pageContentService;
        public PageContentController(IProductService productService, ICategoryService categoryService, IPageContentService pageContentService) : base()
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.pageContentService = pageContentService;
        }
        // GET: PageContent
        public ActionResult Index()
        {
            var pageContent = pageContentService.GetAll();
            return View(pageContent);
        }
    }
}