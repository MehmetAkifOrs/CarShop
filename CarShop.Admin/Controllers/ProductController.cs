using CarShop.Model;
using CarShop.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product product, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(upload.FileName);
                    string extension = Path.GetExtension(fileName).ToLower();
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                    {
                        string path = Path.Combine(ConfigurationManager.AppSettings["uploadPath"], fileName);
                        upload.SaveAs(path);
                        product.Photo = fileName;
                        productService.Insert(product);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");
                    }
                }
                else
                {
                    productService.Insert(product);
                    return RedirectToAction("index");
                }

            }
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        public ActionResult Edit(Guid id)
        {
            var product = productService.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product product, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(upload.FileName);
                    string extension = Path.GetExtension(fileName).ToLower();
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                    {
                        string path = Path.Combine(ConfigurationManager.AppSettings["uploadPath"], fileName);
                        upload.SaveAs(path);
                        product.Photo = fileName;
                        productService.Update(product);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");

                    }
                }
                else
                {
                    // resim seçilip yüklenmese bile diğer bilgileri güncelle
                    productService.Update(product);
                    return RedirectToAction("index");
                }
                //var model = productService.Find(product.Id);
                //model.Name = product.Name;
                //model.Description = product.Description;                
                ////model.GithubLink = project.GithubLink;
                ////model.Year = project.Year;
                //model.Photo = product.Photo;
                //model.Stock = product.Stock;
                //model.CategoryId = product.CategoryId;
                //productService.Update(model);
                //return RedirectToAction("Index");


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
            var product = productService.Find(id);
            if (product == null)
            {
                return HttpNotFound();

            }

            return View(product);
        }
    }
}