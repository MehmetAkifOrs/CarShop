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
    public class ContactPageController : Controller
    {
        private readonly IContactPageService contactpageService;

        public ContactPageController(IContactPageService contactpageService) : base()
        {
            this.contactpageService = contactpageService;

        }

        // GET: MainPage
        public ActionResult Index()
        {
            var contactpage = contactpageService.GetAll();
            return View(contactpage);
        }
        public ActionResult Create()
        {
            var contactpage = new ContactPage();
            return View(contactpage);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ContactPage contactpage, HttpPostedFileBase Upload)
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
                        contactpage.ContactPagePhoto = fileName;
                        contactpageService.Insert(contactpage);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");
                    }

                }
                else
                {
                    contactpageService.Insert(contactpage);
                    return RedirectToAction("index");
                }
            }
            return View(contactpage);
        }

        public ActionResult Edit(Guid id)
        {
            var contactpage = contactpageService.Find(id);
            if (contactpage == null)
            {
                return HttpNotFound();
            }
            return View(contactpage);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ContactPage contactpage, HttpPostedFileBase Upload)
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
                        contactpage.ContactPagePhoto = fileName;
                        contactpageService.Update(contactpage);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");
                    }

                }
                else
                {
                    contactpageService.Insert(contactpage);
                    return RedirectToAction("index");
                }
            }
            return View(contactpage);
        }

        public ActionResult Delete(Guid id)
        {
            contactpageService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            var contactpage = contactpageService.Find(id);
            if (contactpage == null)
            {
                return HttpNotFound();
            }
            return View(contactpage);
        }
    }
}