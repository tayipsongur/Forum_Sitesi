using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminCategoryController : Controller
    {

        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        [Authorize( Roles ="A")]   // Roles kısmı: Sadece veritabanında rolü B olan kişiler bu sayfayı görebilsin.
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();


            return View(categoryvalues);
        }

        [HttpGet] 

        public ActionResult AddCategory()
        {

            return View();
        }
        [HttpPost]
         public ActionResult AddCategory(Category p)
        {
            CategoryValidatior categoryvalidator = new CategoryValidatior();
            ValidationResult results = categoryvalidator.Validate(p);

            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                   
                }
            }

            return View();
        }


        public ActionResult DeleteCategory(int id)
        {
            var categoryvalues = cm.GetByID(id);
            cm.CategoryDelete(categoryvalues);


            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalues = cm.GetByID(id);

            return View(categoryvalues);
        }

        [HttpPost]

        public ActionResult EditCategory(Category category)
        {
            CategoryValidatior categoryvalidator = new CategoryValidatior();
            ValidationResult results = categoryvalidator.Validate(category);

            if (results.IsValid)
            {
                cm.CategoryUpdate(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                   
                }
            }

            return View();
        }

        

    }
}