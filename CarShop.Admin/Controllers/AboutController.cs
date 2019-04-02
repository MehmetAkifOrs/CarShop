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
    public class AboutController : ControllerBase
    {
        private readonly IAboutService aboutService;

        public AboutController(IAboutService aboutService) : base()
        {
            this.aboutService = aboutService;

        }

        // GET: PageContent
        public ActionResult Index()
        {
            var about = aboutService.GetAll();
            return View(about);
        }
        public ActionResult Create()
        {
            var about = new About();
            return View(about);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(About about, HttpPostedFileBase Upload)
        {
            if (ModelState.IsValid)
            {
                if (Upload != null && Upload.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(Upload.FileName);
                    string extension = Path.GetExtension(fileName).ToLower();
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                    {
                        string path = Path.Combine(ConfigurationManager.AppSettings["uploadPath"], fileName);
                        Upload.SaveAs(path);
                        about.AboutPagePhoto = fileName;
                        aboutService.Insert(about);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");
                    }

                }
                else
                {
                    aboutService.Insert(about);
                    return RedirectToAction("index");
                }
            }
            return View(about);
        }


        public ActionResult Edit(Guid id)
        {
            var about = aboutService.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(About about, HttpPostedFileBase Upload)
        {
            if (ModelState.IsValid)
            {
                if (Upload != null && Upload.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(Upload.FileName);
                    string extension = Path.GetExtension(fileName).ToLower();
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                    {
                        string path = Path.Combine(ConfigurationManager.AppSettings["uploadPath"], fileName);
                        Upload.SaveAs(path);
                        about.AboutPagePhoto = fileName;
                        aboutService.Update(about);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");
                    }

                }
                else
                {
                    aboutService.Update(about);
                    return RedirectToAction("index");
                }
                
            }
            return View(about);
        }
        public ActionResult Delete(Guid id)
        {
            aboutService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            var about = aboutService.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

    }
}