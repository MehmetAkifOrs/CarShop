using CarShop.Model;
using CarShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Project
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public ActionResult Index()
        {
            var product = productService.GetAll();
            return View(product);
        }
        public ActionResult Create()
        {
            var product = new Product();
            ViewBag.Categories = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Insert(product);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        public ActionResult Edit(Guid id)
        {
            var product = productService.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var model = productService.Find(product.Id);
                model.Name = product.Name;
                model.Description = product.Description;                
                //model.GithubLink = project.GithubLink;
                //model.Year = project.Year;
                model.Photo = product.Photo;
                model.Stock = product.Stock;
                model.CategoryId = product.CategoryId;
                productService.Update(model);
                return RedirectToAction("Index");


            }
            ViewBag.Categories = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            productService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            return View(productService.Find(id));
        }
    }
}