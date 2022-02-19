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
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading()  // Kullanıcının açtığı başlıkları listelemek için kullandık.
        {
        
            var values = hm.GetListByWriter();
            return View(values);

        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valuecategory = (from i in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.CategoryName,
                                                      Value = i.CategoryID.ToString()
                                                  }

                                              ).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }

        [HttpPost]
         public ActionResult NewHeading(Heading p )
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString()); // p parametresine bugünün kısa tarihini gönder.
            p.WriterID = 2;
            p.HeadingStatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");

            
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
            return RedirectToAction("MyHeading");
        }



    }
}

// HATA KODLARI İÇİN WEB CONFİG TARAFINDA YAZILACAK KOD
/*  
 <customErrors mode="On">
      <error statusCode="404" redirect="/ErrorPage/Page404/" />
      <!-- 404 veya diğer hatalar için bir sayfaya oluşturduğumuz sayfaya yönlendirme işlemini yaptık.-->
    </customErrors>
 */