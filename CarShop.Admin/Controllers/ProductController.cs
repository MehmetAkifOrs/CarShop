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
    public class ProductController : ControllerBase
    {
        // GET: Project
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private readonly IPhotoService photoService;
        public ProductController(IProductService productService, ICategoryService categoryService, IPhotoService photoService) :base()
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.photoService = photoService;
        }
        public ActionResult Index()
        {
            var product = productService.GetAll();
            return View(product);
        }
        public ActionResult Create()
        {
            var product = new Product();
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name");
            return View(product);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product product, HttpPostedFileBase[] Uploads)
        {
            if (ModelState.IsValid)
            {
                if (Uploads != null && Uploads.Length >= 1)
                {
                    product.Photos.Clear();
                    foreach (var item in Uploads)
                    {
                        if (item != null && item.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(item.FileName);
                            var extension = Path.GetExtension(fileName).ToLower();
                            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                            {
                                var path = Path.Combine(ConfigurationManager.AppSettings["uploadPath"], fileName);
                                item.SaveAs(path);
                                var file = new Photo();
                                file.Id = Guid.NewGuid();
                                file.Name = fileName;
                                file.CreatedAt = DateTime.Now;
                                file.CreatedBy = User.Identity.Name;
                                file.UpdatedAt = DateTime.Now;
                                file.UpdatedBy = User.Identity.Name;
                                product.Photos.Add(file);
                                //var file = new Photo();
                                //file.Id = Guid.NewGuid();
                                //photoService.Insert(file);
                            }
                        }
                    }
                }
                productService.Insert(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }

            //    if (ModelState.IsValid)
            //    {
            //        if (uploads != null && uploads.ContentLength >= 0)
            //        {
            //            string fileName = Path.GetFileName(uploads.FileName);
            //            string extension = Path.GetExtension(fileName).ToLower();
            //            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
            //            {
            //                string path = Path.Combine(ConfigurationManager.AppSettings["uploadPath"], fileName);
            //                upload.SaveAs(path);
            //                product.Photo = fileName;

            //                productService.Insert(product);
            //                return RedirectToAction("index");
            //            }
            //            else
            //            {
            //                ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");
            //            }
            //        }
            //        else
            //        {
            //            productService.Insert(product);
            //            return RedirectToAction("index");
            //        }

            //    }
            //    ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            //    return View(product);
            //}

            //
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


            public ActionResult Edit(Guid id)
        {
            var post = productService.Find(id);
            if (post == null)
            {
                return HttpNotFound();

            }
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", post.CategoryId);
            return View(post);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product product, HttpPostedFileBase[] Uploads)
        {
            if (ModelState.IsValid)
            {
                var model = productService.Find(product.Id);
                if (Uploads != null && Uploads.Length >= 1)
                {
                    model.Photos.Clear();
                    foreach (var item in Uploads)
                    {
                        if (item != null && item.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(item.FileName);
                            var extension = Path.GetExtension(fileName).ToLower();
                            if (extension == ".jpg" || extension == ".gif" || extension == ".png" || extension == ".pdf" || extension == ".doc" || extension == ".docx")
                            {
                                var path = Path.Combine(ConfigurationManager.AppSettings["uploadPath"], fileName);
                                item.SaveAs(path);
                                var file = new Photo();
                                file.Id = Guid.NewGuid();
                                file.Name = fileName;
                                file.CreatedAt = DateTime.Now;
                                file.CreatedBy = User.Identity.Name;
                                file.UpdatedAt = DateTime.Now;
                                file.UpdatedBy = User.Identity.Name;                             
                                model.Photos.Add(file);
                            }
                        }
                    }
                }

                model.Name = product.Name;
                model.Description = product.Description;
                model.CategoryId = product.CategoryId;
                model.Price = product.Price;
                model.Stock = product.Stock;
                productService.Update(model);
               
                return RedirectToAction("Index");


            }
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
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