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
        public ActionResult Create()
        {
            var pageContent = new PageContent();          
            return View(pageContent);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(PageContent pageContent, HttpPostedFileBase Upload, HttpPostedFileBase Upload2)
        {
            if (ModelState.IsValid)
            {
                if (Upload != null && Upload.ContentLength > 0  && Upload2 != null && Upload2.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(Upload.FileName);
                    string extension = Path.GetExtension(fileName).ToLower();
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                    {
                        string path = Path.Combine(ConfigurationManager.AppSettings["uploadPath"], fileName);
                        Upload.SaveAs(path);
                        pageContent.CategoryPagePhoto = fileName;
                        //pageContentService.Insert(pageContent);
                        //return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");
                    }

                    string fileName2 = Path.GetFileName(Upload2.FileName);
                    string extension2 = Path.GetExtension(fileName2).ToLower();
                    if (extension2 == ".jpg" || extension2 == ".jpeg" || extension2 == ".png" || extension2 == ".gif")
                    {
                        string path2 = Path.Combine(ConfigurationManager.AppSettings["uploadPath"], fileName2);
                        Upload2.SaveAs(path2);
                        pageContent.AboutPagePhoto = fileName2;
                        pageContentService.Insert(pageContent);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");
                    }
                }
                else
                {
                    pageContentService.Insert(pageContent);
                    return RedirectToAction("index");
                }
            }
            return View(pageContent);
        }


        public ActionResult Edit(Guid id)
        {
            var pageContent = pageContentService.Find(id);
            if (pageContent == null)
            {
                return HttpNotFound();
            }           
            return View(pageContent);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(PageContent pageContent, HttpPostedFileBase Upload, HttpPostedFileBase Upload2)
        {
            if (ModelState.IsValid)
            {
                var model = pageContentService.Find(pageContent.Id);

                if (Upload != null && Upload.ContentLength > 0 && Upload2 != null && Upload2.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(Upload.FileName);
                    string extension = Path.GetExtension(fileName).ToLower();
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                    {
                        string path = Path.Combine(ConfigurationManager.AppSettings["uploadPath"], fileName);
                        Upload.SaveAs(path);
                        pageContent.CategoryPagePhoto = fileName;                       
                    }
                    else
                    {
                        ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");
                    }
                    string fileName2 = Path.GetFileName(Upload2.FileName);
                    string extension2 = Path.GetExtension(fileName2).ToLower();
                    if (extension2 == ".jpg" || extension2 == ".jpeg" || extension2 == ".png" || extension2 == ".gif")
                    {
                        string path2 = Path.Combine(ConfigurationManager.AppSettings["uploadPath"], fileName2);
                        Upload2.SaveAs(path2);
                        pageContent.AboutPagePhoto = fileName2;
                        pageContentService.Update(pageContent);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");
                    }
                }
                else
                {
                    pageContentService.Update(pageContent);
                    return RedirectToAction("index");
                }                
                model.CategoryPageHeader = pageContent.CategoryPageHeader;
                model.CategoryPageDescription = pageContent.CategoryPageDescription;
                model.AboutPageHeader = pageContent.AboutPageHeader;
                model.AboutPageDescription = pageContent.AboutPageDescription;               
                pageContentService.Update(model);                
                return RedirectToAction("Index");
            }           
            return View(pageContent);
        }
        public ActionResult Delete(Guid id)
        {
            pageContentService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            var pageContent = pageContentService.Find(id);
            if (pageContent == null)
            {
                return HttpNotFound();
            }
            return View(pageContent);
        }
    }
}