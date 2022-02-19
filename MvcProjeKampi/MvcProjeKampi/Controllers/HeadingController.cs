using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingvalues = hm.GetList();

            return View(headingvalues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            // Kategori ID'sine göre Kategori Adını Getirmemiz Gerekiyor. Bunu Controllerden ViewBag yardımı ile View'e taşıyacağız.

            List<SelectListItem> valuecategory = (from i in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.CategoryName,
                                                      Value = i.CategoryID.ToString()
                                                  }

                                                ).ToList();

            List<SelectListItem> valuewriter = (from i in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text=i.WriterName +" "+ i.WriterSurname,
                                                    Value=i.WriterID.ToString()
                                                }
                                              ).ToList();

            ViewBag.vlw = valuewriter; // Burada da view tarafına yazarı taşıdık.
            ViewBag.vlc = valuecategory;  // Burada da view tarafına taşıma işlemini yapıyoruz.
            return View();

        }
        [HttpPost]

        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString()); // p parametresine bugünün kısa tarihini gönder.
            hm.HeadingAdd(p);
            return RedirectToAction("Index");


        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from i in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.CategoryName,
                                                      Value = i.CategoryID.ToString()
                                                  }

                                               ).ToList();
            ViewBag.vlc = valuecategory;
            var headingvalues = hm.GetByID(id);
            return View(headingvalues);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingvalues = hm.GetByID(id);
            hm.HeadingDelete(headingvalues);     // Silme işlemi yerine manager sınıfında güncelleme yaptık ve durumu pasif yani false yaptık.
            return RedirectToAction("Index");
        }


    }
}