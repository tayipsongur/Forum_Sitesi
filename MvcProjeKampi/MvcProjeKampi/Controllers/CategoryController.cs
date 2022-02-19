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
    public class CategoryController : Controller
    {
        // GET: Category

        CategoryManager cm = new CategoryManager(new EfCategoryDal()); // Busines Layer'daki CategoryManager'den bir cm isminde bir nesne türettik.
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetList();  // cm.GetList diyerek listelemeyi yaptık. GetList CategoryManager içerisinde bulunuyor...
            return View(categoryvalues);   // Geriye değerimizi döndür dedik.
            
        }



        [HttpGet]

        public ActionResult AddCategory()
        {
            return View();   // Hiçbir işlem yapılmadığı zaman sadece bana sayfayı geri döndür.
        }

        [HttpPost] // Post işlemi yapılacağı zaman çalışacak olan komut...Yani biz ekle butonuna tıkladığımız zaman burası çalışacak.
        public ActionResult AddCategory(Category p)
        {
            //  cm.CategoryAddBL(p);  // Ekleme işlemini yapıyoruz.

            CategoryValidatior categoryValidator = new CategoryValidatior();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)  // Bütün kurallar uygunsa ekleme işlemini gerçekleştir.
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage); // Modelin durumuna, Hataları ekle. Bu hatalarda önce ilgili alanlar sonra da mesajları ekle.
                }
            }

            return View();

        }
    }
}