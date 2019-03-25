﻿using CarShop.Model;
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
    public class CategoryController : ControllerBase
    {
        // GET: Category
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService) : base()
        {
            this.categoryService = categoryService;
        }

        // GET: Categoryler burada olacak//
        public ActionResult Index()
        {
            var category = categoryService.GetAll();
            return View(category);
        }
        public ActionResult Create()
        {
            var category = new Category();
            return View(category);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Category category, HttpPostedFileBase upload)
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
                        category.IconPhoto = fileName;

                        categoryService.Insert(category);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");
                    }
                }
                else
                {

                    categoryService.Insert(category);
                    return RedirectToAction("index");
                }

            }

            //ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", postViewModel.CategoryId);
            return View(category);
        }
        public ActionResult Edit(Guid id)
        {

            var category = categoryService.Find(id);
            if (category == null)
            {
                return HttpNotFound();

            }
            return View(category);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Category category, HttpPostedFileBase upload)
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
                        category.IconPhoto = fileName;
                        categoryService.Update(category);
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
                    categoryService.Update(category);
                    return RedirectToAction("index");
                }


            }
            //ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", postViewModel.CategoryId);
            return View(category);
        }
        public ActionResult Delete(Guid id)
        {
            categoryService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            var category = categoryService.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
    }
}