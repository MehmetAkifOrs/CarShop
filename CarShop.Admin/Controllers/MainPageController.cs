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
    public class MainPageController : Controller
    {
        private readonly IMainPageService mainpageService;

        public MainPageController(IMainPageService mainpageService) : base()
        {
            this.mainpageService = mainpageService;

        }

        // GET: MainPage
        public ActionResult Index()
        {
            var mainpage = mainpageService.GetAll();
            return View(mainpage);
        }
        public ActionResult Create()
        {
            var mainpage = new MainPage();
            return View(mainpage);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(MainPage mainpage, HttpPostedFileBase Upload)
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
                        mainpage.MainPagePhoto = fileName;
                        mainpageService.Insert(mainpage);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");
                    }

                }
                else
                {
                    mainpageService.Insert(mainpage);
                    return RedirectToAction("index");
                }
            }
            return View(mainpage);
        }

        public ActionResult Edit(Guid id)
        {
            var mainpage = mainpageService.Find(id);
            if (mainpage == null)
            {
                return HttpNotFound();
            }
            return View(mainpage);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(MainPage mainpage, HttpPostedFileBase Upload)
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
                        mainpage.MainPagePhoto = fileName;
                        mainpageService.Update(mainpage);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");
                    }

                }
                else
                {
                    mainpageService.Insert(mainpage);
                    return RedirectToAction("index");
                }
            }
            return View(mainpage);
        }

        public ActionResult Delete(Guid id)
        {
            mainpageService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            var mainpage = mainpageService.Find(id);
            if (mainpage == null)
            {
                return HttpNotFound();
            }
            return View(mainpage);
        }
    }
}